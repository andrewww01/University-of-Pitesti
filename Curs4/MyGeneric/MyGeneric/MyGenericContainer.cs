

using System;

namespace MyGeneric
{
    
    //container de obiecte de tip T, tip referinta!
    public class MyGenericContainer<T> where T : class, IComparable<T>, new()
    {
        private T[] _values;
        private int _size;

        public MyGenericContainer()
        {
            _size = 0;
            _values = new T[_size];
        }

        public MyGenericContainer<T> Add(T value)
        {
            if (!Contains(value))
            {
                T[] temp = new T[_size + 1];
                for(int i = 0; i < _size; i++)
                {
                    temp[i] = _values[i];
                }

                temp[_size] = value;

                _values = temp;
                _size++;
            }

            //var newValue = new T();

            return this;
        }

        public MyGenericContainer<T> Remove(T value)
        {
            if (!Contains(value))
            {
                return this;
            }

            //aici value exista!

            //gasiti in array pe value (pozitia!)

            //deplasati elementele la dreapta cu o pozitie
            //scade _size cu o unitate!!

            return this;
        }

        public bool Contains(T value)
        {
            foreach(var item in _values)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }

            return false;
            
            //return _values.Contains(value);
        }

    }
}
