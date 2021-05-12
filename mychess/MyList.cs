using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace mychess
{
    public class MyList<T> :IList<T>
    {
        private T[] _contents = new T[8];
        private int _count;

        
        public MyList(){
            _count = 0;
    }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T this[int index]
        {
            get
            {
                return _contents[index];
            }
            set
            {
                _contents[index] = value;
            }
        }

        public void Add(T value)
        {
            if (_count < _contents.Length)
            {
                _contents[_count] = value;
            }
            else
            {
               // change size
                T []tmp = new T[_contents.Length * 2];
                for (int i = 0; i < _contents.Length; i++)
                    tmp[i] = _contents[i];
                tmp[_contents.Length] = value;
                // delete old array
                _contents = null;
                _contents = tmp;
            }
            _count++;
        }


        public void Clear()
        {
            _count = 0;
            _contents = new T[8];
        }
        


        public bool Contains(T value)
        {
            bool found = false;
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i].Equals(value))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public void CopyTo(T[] array, int index)
        {
            int j = index;
            for (int i = 0; i < _count; i++)
            {
                array.SetValue(_contents[i], j);
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            // Refer to the IEnumerator documentation for an example of
            // implementing an enumerator.

            // Fix it
            T []list = new T[_count];
            CopyTo(list, 0);
            return new MyEnum<T>(list);
        }

         IEnumerator IEnumerable.GetEnumerator()
 {
 return GetEnumerator();
 }

        public int IndexOf(T value)
        {
            int itemIndex = -1;
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i].Equals(value))
                {
                    itemIndex = i;
                    break;
                }
            }
            return itemIndex;

        }

       public void Insert(int index, T value)
       {
        if ((_count + 1 <= _contents.Length) && (index < Count) && (index >= 0))
        {
            _count++;

            for (int i = Count - 1; i > index; i--)
            {
                _contents[i] = _contents[i - 1];
            }
            _contents[index] = value;
        }
    }

       public bool Remove(T value)
       {
           int index = IndexOf(value);
           if (index >= 0)
           {
               RemoveAt(index);
               return true;
           }
           return false;
       }

       public void RemoveAt(int index)
       {
           if ((index >= 0) && (index < Count))
           {
               for (int i = index; i < Count - 1; i++)
               {
                   _contents[i] = _contents[i + 1];
               }
               _count--;
           }
       }
       public void AddRange(IEnumerable<T> collection)
       {
           foreach (T value in collection)
               Add(value);

       }
    }


}
