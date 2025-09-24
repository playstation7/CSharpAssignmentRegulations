using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(DrawLeftTriangle(4));

            Console.WriteLine(DrawRightTriangle(4));

            Console.WriteLine(DrawHallowTriangle(4));

            foreach (var calendarDays in GetCalendar(4)) 
            {
                Console.Write(calendarDays.Key.ToString() + '\t');
                Console.WriteLine(string.Join(" ",calendarDays.Value
                    .Select(x => x.ToString())
                    .ToList()));
            }


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
            for (var i = 1; i <= n * 2; i++)
            {
                int starCount = i < n
                    ? i
                    : n - (i - n);
                starString += new string('*', starCount) + new string(' ', n - starCount) + '\n';
            }

            return starString;
        }

        ///<summary> 
        /// Нарисовать пустотелый равнобедренный треугольник с длиной сторон N.
        /// </summary>
        static string DrawHallowTriangle(int n)
        {
            var starString = string.Empty;
            for (var i = 1; i <= n * 2; i++)
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
        /// Вывести на экран календарь месяца вашего рождения в текущем году.
        /// </summary>
        static Dictionary<DayOfWeek, List<int>> GetCalendar(int month, int year = 2025)
        {
            Dictionary<DayOfWeek, List<int>> calendar = new Dictionary<DayOfWeek, List<int>>();

            var daysCount = DateTime.DaysInMonth( year, month);

            for (var day = 1; day <= daysCount; day++)
            {
                var dayOfMonth = new DateTime(year,month, day);
                var dayOfWeek = dayOfMonth.DayOfWeek;
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



        
    }
}
