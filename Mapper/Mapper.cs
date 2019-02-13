using MyRUZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRUZ.Mapper
{
    public class Mapper
    {
        public static Lesson LessonRuzToLesson(RuzLesson lessonRuz)
        {
            return new Lesson
            {
                Auditorium = lessonRuz.auditorium,
                BeginLesson = lessonRuz.beginLesson,
                Building = lessonRuz.building,
                Date = DateTime.Parse(lessonRuz.date).ToString("d"),
                EndLesson = lessonRuz.endLesson,
                Lecturer = lessonRuz.lecturer,
                Name = lessonRuz.discipline,
                Status = "FromJson",
                Stream = lessonRuz.stream,
                Type = lessonRuz.kindOfWork
            };
        }

        public static List<Lesson> LessonRuzToLesson(List<RuzLesson> lessonRuz)
        {
            List<Lesson> lessons = new List<Lesson>();
            foreach (var i in lessonRuz)
            {
                lessons.Add(LessonRuzToLesson(i));
            }
            return lessons;
        }
    }
}
