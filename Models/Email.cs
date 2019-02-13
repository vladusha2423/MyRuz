using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRUZ.Models
{
    public class Email
    {
        public static string GettingEmail(string email, string emailTemp)
        {
            if (email != null)
                return email;
            else if (emailTemp != null)
                return emailTemp;
            else
                return email;
        }
    }
}
