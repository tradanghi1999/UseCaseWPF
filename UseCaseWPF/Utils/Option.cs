using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Option<T>
    {
        internal Option()
        {}
        protected T optionValue;
        public T GetPrimeValue()
        {
            return optionValue;
        }
        public static Option<T> Create(T t)
        {
            if(t != null)
            {
                return new Some<T>() { optionValue = t };
            }
            return new None<T>();
        }
    }

    public class Some<T> : Option<T>
    {
        internal Some()
        { }
    }

    public class None<T>:Option<T>
    {
        internal None()
        { }
        public static None<T> Create()
        {
            return new None<T>();
        }
    }
}
