using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unity2017csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            printyearcalendar(year);


        }
        /// <summary>
        /// 根据年月日来判断星期几
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        private static int getweekbyday(int year,int month,int day)
        {
            DateTime da = new DateTime(year, month, day);
            return (int)da.DayOfWeek;
        }


        /// <summary>
        /// 判断是否闰年
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private static bool isleep(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) && year % 400 == 0)
                return true;
            else
                return false;
            
        }

        /// <summary>
        /// 判断每月有多少天
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        private static int getdaybymonth(int year,int month)
        {
            if (month < 1 || month > 12)
                return 0;
                switch (month)
                {
                    case 2:
                        return isleep(year) ? 29 : 28;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        return 30;
                    default:
                        return 31;

                }
        }

        /// <summary>
        /// 显示月历表
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        private static void printmonthcalendar(int year,int month)
        {
            //表头
            Console.WriteLine("{0}年{1}月",year,month);
            Console.WriteLine("日\t一\t二\t三\t四\t五\t六");
            //根据1日星期数，显示空白
           int week= getweekbyday(year, month, 1);
            for (int i = 0; i < week; i++)
            {
                Console.Write("\t");

            }   
            //根据当月总天数，显示日
            int days = getdaybymonth(year, month);
            for (int i = 1; i <= days; i++)
            {
                Console.Write(i + "\t");
                //每周六换行
                if (getweekbyday(year, month, i) == 6)
                    Console.WriteLine();
            }
        }

        /// <summary>
        /// 打印年历
        /// </summary>
        /// <param name="year"></param>
        private static void printyearcalendar(int year)
        {
            for (int i = 1; i <= 12; i++)
            {
                printmonthcalendar(year, i);
            }
        }
    }
}
