using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MyRUZ.Models;
using Newtonsoft.Json;

namespace MyRUZ.Servise
{
    public class Timetable
    {
        private string API { get; set; } = "https://www.hse.ru/api/timetable/lessons?";

        public async Task<List<RuzLesson>> GetLessons(DateTime fromDate, DateTime toDate,
            string email)
        {
            RootObject obj = new RootObject();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(API + "fromdate=" +
                fromDate.ToString("yyyy.MM.dd") + "&todate=" + toDate.ToString("yyyy.MM.dd")
                + "&email=" + email);
            var a = API + "fromdate=" +
                fromDate.ToString("yyyy.MM.dd") + "&todate=" + toDate.ToString("yyyy.MM.dd")
                + "&email=" + email;
            if (response.IsSuccessStatusCode)
            {
                obj = await response.Content.ReadAsAsync<RootObject>();
            }
            return obj.Lessons;
        }
    }
}
