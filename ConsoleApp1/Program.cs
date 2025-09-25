using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine(DrawLeftTriangle(4));

            Console.WriteLine(DrawRightTriangle(4));

            Console.WriteLine(DrawHallowTriangle(4));

            PrintCalendar(10);

        }

        

        ///<summary> 
        /// Нарисовать равнобедренный треугольник с левым основанием с длиной сторон N.
        /// </summary>
        static string DrawLeftTriangle(int n) 
        {
            return CreateTriangle(n);
        }

        ///<summary> 
        /// Нарисовать равнобедренный треугольник с правым основанием с длиной сторон N.
        /// </summary>
        static string DrawRightTriangle(int n)
        {
            var triangleString = CreateTriangle(n);
            return string.Join("",triangleString.Reverse());
        }

        ///<summary> 
        /// Создает левосторонний равнобедренный треугольник с длиной ребер равной N.
        /// </summary>
        static string CreateTriangle(int n) 
        {
            var starString = String.Empty;
            for (var i = 1; i < n * 2; i++)
            {
                // выполнение умножения на (i / n) выполняет роль флага, т.е. пока пирамида растет выражение дает 0, когда падает, то 1
                var starCount = i + (n - i) * (i / n) - (i % n) * (i / n);
                starString += new string('*',starCount) 
                    + new string(' ',n * 2 - starCount)
                    + '\n';
            }

            return starString;
        }

        ///<summary> 
        /// Нарисовать пустотелый равнобедренный треугольник с длиной сторон N.
        /// </summary>
        static string DrawHallowTriangle(int n)
        {
            var starString = string.Empty;
            for (var i = 1; i < n * 2; i++)
            {
                var starCount = i < n
                    ? i
                    : n - (i - n);

                var spaceCount = starCount - 2 > 0
                    ? starCount - 2
                    : 0;

                starString += new string('*', starCount >= 1 ? 1 : 0)
                    + new string(' ', spaceCount)
                    + new string('*', starCount >= 2 ? 1 : 0)
                    + '\n';
            }

            return starString;
        }

        ///<summary> 
        /// Получить календарь указанного месяца и года.
        /// </summary>
        static Dictionary<string, List<int>> GetCalendar(int month, int year)
        {
            Dictionary<string, List<int>> calendar = new Dictionary<string, List<int>>();
            var daysCount = DateTime.DaysInMonth( year, month);
            for (var day = 1; day <= daysCount; day++)
            {
                var dayOfMonth = new DateTime(year,month, day);
                var dayOfWeek = dayOfMonth.ToString("ddd",new CultureInfo("RU"));
                if (calendar.ContainsKey(dayOfWeek))
                {
                    calendar[dayOfWeek].Add(day);
                }
                else 
                {
                    calendar[dayOfWeek] = new List<int>() {day};
                }
            }
            
            return calendar;
        }

        ///<summary> 
        /// Вывести на экран календарь указанного месяца и года.
        /// </summary>
        static void PrintCalendar(int month, int year = 2025)
        {
            var calendar = GetCalendar(month, year);
            var keyList = calendar
                .Keys
                .ToList();

            // mondayIndexOffset необходим, чтобы показ календаря всегда начинался с понедельника, а не с того дня недели, которое имело 1 число
            var mondayIndexOffset = keyList.IndexOf("Пн");

            for (var i = 0; i < 7; i++)
            {
                var dayIndex = (i + mondayIndexOffset) % 7;
                Console.Write(keyList[dayIndex].ToString() + '\t');
                var daysOfWeek = calendar[keyList[dayIndex]];
                foreach (var date in daysOfWeek)
                {
                    Console.Write(date.ToString("D") + ' ');
                }
                Console.WriteLine();
            }
        }
    }
}
