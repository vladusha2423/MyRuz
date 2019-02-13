using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRUZ.Models
{
    public class List
    {
        public static List<Lesson> EditList(List<Lesson> lessons, List<Lesson> deleted, string email)
        {
            List<Lesson> lessonsUse = new List<Lesson>();
            bool flag;
            foreach (var item in lessons)
            {
                flag = true;
                foreach (var itemDel in deleted)
                    if (Lesson.IsEq(item, itemDel) && flag && itemDel.Email == email)
                        flag = false;
                if (flag)
                    lessonsUse.Add(item);
            }
            return lessonsUse;
        }
    }
}
