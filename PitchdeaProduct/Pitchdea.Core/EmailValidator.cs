﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pitchdea.Core
{
    public static class EmailValidator
    {
        /// <summary>
        /// Checks that the email address is a valid email address.
        /// </summary>
        /// <param name="email">Email address to be checked.</param>
        /// <returns>True if the email address is valid, otherwise false.</returns>
        public static bool Validate(string email)
        {
            if (email.Length > 150)
                return false;

            var regex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
