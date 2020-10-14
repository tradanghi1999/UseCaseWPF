using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class FP
    {
        public static bool IsNotNone<T>(this Option<T> opt)
        {
            return opt is Some<T>;
        }

        public static bool VerifyWithConditions<T>(this Option<T> opt, params Predicate<T>[] predicates)
        {
            if (!opt.IsNotNone())
                return false;

            bool[] conditions = new bool[predicates.Length];
            foreach(Predicate<T> predicate in predicates)
            {
                conditions.Append(predicate(opt.GetPrimeValue()));
            }

            if (conditions.All(x => x == true))
                return true;
            return false;
        }
    }
}
