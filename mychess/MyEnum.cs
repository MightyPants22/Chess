using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace mychess
{
    public class MyEnum<T> : IEnumerator<T>
    {
            public T[] _values;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public MyEnum(T[] list)
            {
               _values = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _values.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            void IDisposable.Dispose() { }
            public T Current
            {
                get
                {
                    try
                    {
                        return _values[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
}
