using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utils;

namespace Entites
{
    public class VerifiedUser
    {
        User user;
        internal VerifiedUser(User userToVerify)
        {
            user = userToVerify;
        }
        public static Func<User, Option<VerifiedUser>> VerifyUserService =
            (User user) =>
            {
                if (!verifyEmail(user.Email))
                    return None<VerifiedUser>.Create();
                if (!verifyPhoneNumber(user.PhoneNumber) ||
                    !veryfyPIN(user.PIN))
                    return None<VerifiedUser>.Create();
                return Option<VerifiedUser>
                        .Create( 
                            new VerifiedUser(user)
                        );
            };

        private static bool verifyEmail(Option<string> email)
        {

            Predicate<string> hasNotMoreThan1A = str => str.Count(c => c == '@') == 1;
            Predicate<string> hasHostName = str => str.Contains(".");

            return email
                    .VerifyWithConditions(
                            hasNotMoreThan1A, 
                            hasHostName);
        }

        static bool verifyPhoneNumber(Option<string> phone)
        {
            Predicate<string> hasNotMoreThan1Plus = str => str.Count(c => c == '+') == 1;
            return phone
                .VerifyWithConditions(hasNotMoreThan1Plus);
        }

        static bool veryfyPIN(Option<int> pin)
        {
            Predicate<int> hasMoreThan5Digit = (p) => p >= 100000;
            return pin
                    .VerifyWithConditions(hasMoreThan5Digit);
        }
        static bool verifyPassword(Option<string> password)
        {
            //Predicate<Option<string>> isNotNone = (opt) => opt is Some<string>; 
            Predicate<string> hasUpperCase = (str) => !str.Equals(str.ToLower());
            Predicate<string> hasLowerCase = (str) => !str.Equals(str.ToUpper());
            Predicate<string> hasNumber = (str) => str.Any(char.IsDigit);
            Predicate<string> hasSpecialChr = (str) => (new Regex("^[a-zA-Z0-9 ]*$")).IsMatch(str);
            Predicate<string> hasOver8Char = (str) => str.Length > 8;

            return password
                    .VerifyWithConditions(
                        hasLowerCase,
                        hasNumber,
                        hasOver8Char,
                        hasSpecialChr,
                        hasUpperCase
                );
        }

    }
}
