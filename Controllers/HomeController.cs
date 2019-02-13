using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyRUZ.Models;
using MyRUZ.Servise;
using System.Web;
using System.Linq;
using System.IO;

namespace MyRUZ.Controllers
{
    public class HomeController : Controller
    {

        private readonly MyRUZDbContext _context;
        private readonly Timetable _timetable;
        public HomeController(MyRUZDbContext context, Timetable timetable)
        {
            _context = context;
            _timetable = timetable;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(string name, string date, string beginLesson, string status, string email, int num, int id = 0)
        {
            ViewData["Date"] = date;
            ViewData["Num"] = num;
            ViewData["Email"] = email;
            if (status == "Add")
            {
                var lesson = _context.Lessons.Find(id);
                if (lesson != null)
                {
                    _context.Lessons.Remove(lesson);
                    _context.SaveChanges();
                    return View(lesson);
                }
            }
            List<Lesson> Lessons = Mapper.Mapper.LessonRuzToLesson(_timetable.GetLessons(DateTime.Parse(GettingDate.MondayDate(date)), DateTime.Parse(GettingDate.MondayDate(date)).AddDays(6), email).Result);
            foreach(var i in Lessons)
                if (name == i.Name && beginLesson == i.BeginLesson && date == i.Date)
                {
                    _context.Lessons.Add(new Lesson
                    {
                        Name = name,
                        Date = date,
                        Email = email,
                        BeginLesson = beginLesson,
                        Status = "Delete"
                    });
                    _context.SaveChanges();
                    Console.WriteLine();
                    return View(i);
                }
            return View();
        }
        [HttpPost]
        public IActionResult Update(Lesson lesson)
        {
            if (lesson.Status == "FromJson")
            {
                lesson.Status = "Add";
                _context.Lessons.Add(lesson);
            }
            else
                _context.Lessons.Update(lesson);
            _context.SaveChanges();
            return RedirectToAction("Timetable");
        }

        [HttpGet]
        public IActionResult Delete(string name, string date, string email, string time, string status, int id = 0)
        {
            if (status == "Add")
            {
                var lesson = _context.Lessons.Find(id);
                if (lesson != null)
                {
                    _context.Lessons.Remove(lesson);
                    _context.SaveChanges();
                    return RedirectToAction("Timetable");
                }
                return RedirectToAction("Timetable");
            }
            _context.Lessons.Add(new Lesson
            {
                Name = name,
                Date = date,
                Email = email,
                BeginLesson = time,
                Status = "Delete"
            });
            _context.SaveChanges();
            return RedirectToAction("Timetable");
        }

        [HttpGet]
        public IActionResult Create(string date, int numLesson, int dayOfWeek, string email) {
            ViewData["Date"] = DateTime.Parse(date).AddDays(dayOfWeek - 1).ToString("d");
            ViewData["NumLesson"] = numLesson;
            ViewData["DayOfWeek"] = dayOfWeek;
            ViewData["Email"] = email;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Lessons.Add(lesson);
                _context.SaveChanges();
            }
            return RedirectToAction("Timetable");
        }

        public IActionResult Timetable(string email, string date)
        {
            string emailTemp = HttpContext.Request.Cookies["email"];
            string dateTemp = HttpContext.Request.Cookies["date"];
            if (email != null)
                HttpContext.Response.Cookies.Append("email", email);
            if (date != null)
            {
                date = GettingDate.MondayDate(date, dateTemp);
                HttpContext.Response.Cookies.Append("date", date);
            }
            List<Lesson> deleted = _context.Lessons.Where(l => l.Status == "Delete").ToList(), lessonsUse = new List<Lesson>(), lessons = new List<Lesson>();
            lessons = Mapper.Mapper.LessonRuzToLesson(_timetable.GetLessons(DateTime.Parse(GettingDate.MondayDate(date, dateTemp)), DateTime.Parse(GettingDate.MondayDate(date, dateTemp)).AddDays(6), Email.GettingEmail(email, emailTemp)).Result);
            ViewData["date"] = GettingDate.MondayDate(date, dateTemp);
            ViewData["email"] = Email.GettingEmail(email, emailTemp);
            lessonsUse = List.EditList(lessons, deleted, Email.GettingEmail(email, emailTemp));
            lessonsUse.AddRange(_context.Lessons.Where(l => l.Status == "Add"));
            return View(lessonsUse);
                    
        }
        public IActionResult NextWeek()
        {
            HttpContext.Response.Cookies.Append("date", DateTime.Parse(GettingDate.MondayDate(HttpContext.Request.Cookies["date"])).AddDays(7).ToString("d"));
            return RedirectToAction("Timetable");
        }
        public IActionResult PreviousWeek()
        {
            HttpContext.Response.Cookies.Append("date", DateTime.Parse(GettingDate.MondayDate(HttpContext.Request.Cookies["date"])).AddDays(-7).ToString("d"));
            return RedirectToAction("Timetable");
        }

        public IActionResult ListLessons()
        {
            string emailTemp = HttpContext.Request.Cookies["email"];
            string dateTemp = HttpContext.Request.Cookies["date"];
            ViewData["date"] = GettingDate.MondayDate(dateTemp);
            List<Lesson> deleted = _context.Lessons.Where(l => l.Status == "Delete").ToList(), lessons = new List<Lesson>();
            lessons = Mapper.Mapper.LessonRuzToLesson(_timetable.GetLessons(DateTime.Parse(GettingDate.MondayDate(dateTemp)), DateTime.Parse(GettingDate.MondayDate(dateTemp)).AddDays(6), emailTemp).Result);
            return View(List.EditList(lessons, deleted, emailTemp));
        }
    }
}
