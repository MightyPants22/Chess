using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Threading;

namespace mychess
{
    public class BaseClientServer
    {

        protected bool newmove;
        protected bool hasdefeat;
        protected Side defeatside;
        protected bool hasclosed;
        protected bool hassuperiority;
        Position from;
        Position to;
        protected FigureTypes superiorityfigtype;
        protected Position superioritypos;
        protected const string commov = "Move";
        protected const string comend = "End";
        protected const string comdef = "Defeat";
        protected const string comsuperiority = "Superiority";
        protected object lockobj = new object();
        protected BaseClientServer(){
            newmove = false;
            hasdefeat = false;
            hasclosed = false;
            hassuperiority = false;
        }

        protected void CommandLoop(NetworkStream ns, View view, Game game)
        {
            bool docycle = true;
            string command;
            while (docycle)
            {
                if (ns.DataAvailable)
                {// command
                    command = ReadString(ns);
                    switch (command)
                    {
                        case commov:
                            {
                                GetMove(ns, view, game);
                                break;
                            }
                        case comend:
                            {
                                docycle = false;
                                break;
                            }
                        case comdef:
                            {
                                GetDefeat(ns, view, game);
                                docycle = false;
                                break;
                            }
                        case comsuperiority:
                            {
                                GetSuperiority(ns, view, game);
                                break;
                            }
                    }
                }
                lock (lockobj)
                {
                    if (newmove)
                    {
                        SendMove(ns, view, game);
                    }
                    if (hasdefeat)
                    {
                        SendDefeat(ns, defeatside);
                        docycle = false;
                    }
                    if (hassuperiority)
                    {
                        SendSuperiority(ns, superiorityfigtype, superioritypos);
                    }
                    if (hasclosed)
                    {
                        docycle = false;
                    }
                }
                Thread.Sleep(100);
            }
        }

        protected string ReadString(NetworkStream ns)
        {
            byte[] buffer = new byte[4];
            int len;
            ns.Read(buffer, 0, 4);
            len = BitConverter.ToInt32(buffer, 0);
            buffer = new byte[len];
            ns.Read(buffer, 0, len);
            return Encoding.UTF8.GetString(buffer);
        }

        protected void WriteString(NetworkStream ns, string s)
        {
            int len;
            byte[] buffer;
            buffer = Encoding.UTF8.GetBytes(s);
            len = buffer.Length;
            ns.Write(BitConverter.GetBytes(len), 0, 4);
            ns.Write(buffer, 0, len);
        }

        protected void WriteInt(NetworkStream ns, int n)
        {
            byte[] buffer;
            buffer = BitConverter.GetBytes(n);
            ns.Write(buffer, 0, 4);
        }

        protected int ReadInt(NetworkStream ns)
        {
            byte []buffer = new byte[4];
            ns.Read(buffer, 0, 4);
            return BitConverter.ToInt32(buffer, 0);
        }

        public void NewMove(Position from, Position to)
        {
            //MessageBox.Show("new move");
            lock (lockobj)
            {
                newmove = true;
                this.from = from;
                this.to = to;
            }
        }

        public void GetMove(NetworkStream ns, View view, Game game )
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Position from = (Position)formatter.Deserialize(ns);
            Position to = (Position)formatter.Deserialize(ns);
            // view 
            view.Invoke(new Action(
                () => { game.Cell_Click(from); Thread.Sleep(100); game.Cell_Click(to); }));
        }

        public void SendMove(NetworkStream ns, View view, Game game)
        {
            //MessageBox.Show("Send move");
            lock (from)
            {
                WriteString(ns, commov);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ns, from);
                formatter.Serialize(ns, to); 
                newmove = false;
            }
        }
        public void NewDefeat(Side side)
        {
            lock (lockobj)
            {
                hasdefeat = true;
                defeatside = side;
            }

        }


        public void NewSuperiority(FigureTypes figtype, Position pos)
        {
            lock (lockobj)
            {
                hassuperiority = true;
                superiorityfigtype = figtype;
                superioritypos = pos;
            }

        }

        protected void SendDefeat(NetworkStream ns,Side side)
        {
            hasdefeat = false;
            WriteString(ns, comdef);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ns, side);
        }

        protected void SendSuperiority(NetworkStream ns, FigureTypes figtype,Position pos)
        {
            hassuperiority = false;
            WriteString(ns, comsuperiority);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ns, figtype);
            formatter.Serialize(ns, pos);
        }

        protected void GetSuperiority(NetworkStream ns, View view, Game game)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FigureTypes figtype = (FigureTypes)formatter.Deserialize(ns);
            Position pos = (Position)formatter.Deserialize(ns);
            view.Invoke(new Action(
                () => 
                {
                    game.DirectStateCycle();
                    game.Field.TransformPawn(pos, figtype); 
                    view.DrawField();
                    game.Field.ShahCheck(game.Field.GetFigureAt(pos));
                    view.SetTurnText();
                    view.WhiteCount(game.Player1.GetCount());
                    view.BlackCount(game.Player2.GetCount());
                 }));
        }

        protected void GetDefeat(NetworkStream ns, View view, Game game)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            Side side = (Side)formatter.Deserialize(ns);

            view.Invoke(new Action(
            () =>{game.EndGame(game.Field.SideToPlayer(side).King);}));
        }

        public void Close()
        {
            lock (lockobj)
            {
                hasclosed = true;
            }
        }
    }
}
