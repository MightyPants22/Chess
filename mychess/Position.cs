using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    [Serializable]
    public class Position
    {
        private byte x;
        private byte y;

        public Position(int x, int y)
        {
            if (x>8 | x <1 | y>8 | y<1)
                throw new InvalidPositionException();
            this.x =(byte) x;
            this.y =(byte) y;
        }

        public byte GetX()
        {
            return x;
        }

        public byte GetY()
        {
            return y;
        }

        public byte GetX0()
        {
            return (byte) (GetX()-1);
        }

        public byte GetY0()
        {
            return (byte) (GetY() - 1);
        }

        public void SetPosition(Position pos)
        {
            if (x > 8 | x < 1 | y > 8 | y < 1)
                throw new ArgumentException();
            x = pos.x;
            y = pos.y;
        }

        public override string ToString()
        {
            char s = 'a';
            s += (char) (GetX() - 1);
            return s + GetY().ToString();
        }

        public static bool operator ==(Position pos1, Position pos2)
        {
            if (ReferenceEquals(pos1, null) || ReferenceEquals(pos2, null))
                return ReferenceEquals(pos1, pos2);
            return pos1.Equals(pos2);
        }

        public static bool operator !=(Position pos1, Position pos2)
        {

            return !(pos1 == pos2);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override bool Equals(object obj)
        {

            if (this.GetX() == ((Position)obj).GetX() && this.GetY() == ((Position)obj).GetY())
                return true;
            else
                return false;
        }

    }
}
