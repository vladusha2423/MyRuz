using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRUZ.Models
{
    public class GettingDate
    {
        public static string MondayDate(string date, string dateTemp)
        {
            if (date == null && dateTemp == null) {
                DateTime today = DateTime.Now;
                int weekDay = (int)today.DayOfWeek;
                if (weekDay >= 1)
                    return today.AddDays(1 - weekDay).ToString("d");
                else
                    return today.AddDays(1).ToString("d");
            }
            else if(date == null && dateTemp != null)
            {
                int weekDay = (int)DateTime.Parse(dateTemp).DayOfWeek;
                if (weekDay >= 1)
                    return DateTime.Parse(dateTemp).AddDays(1 - weekDay).ToString("d");
                else
                    return DateTime.Parse(dateTemp).AddDays(1).ToString("d");
            }
            else
            {
                int weekDay = (int)DateTime.Parse(date).DayOfWeek;
                if (weekDay >= 1)
                    return DateTime.Parse(date).AddDays(1 - weekDay).ToString("d");
                else
                    return DateTime.Parse(date).AddDays(1).ToString("d");
            }
                
        }

        public static string MondayDate(string date)
        {
            if (date == null)
            {
                DateTime today = DateTime.Now;
                int weekDay = (int)today.DayOfWeek;
                if (weekDay >= 1)
                    return today.AddDays(1 - weekDay).ToString("d");
                else
                    return today.AddDays(1).ToString("d");
            }
            else
            {
                int weekDay = (int)DateTime.Parse(date).DayOfWeek;
                if (weekDay >= 1)
                    return DateTime.Parse(date).AddDays(1 - weekDay).ToString("d");
                else
                    return DateTime.Parse(date).AddDays(1).ToString("d");
            }

        }
    }
}
