using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Common
{
    public static class Extensions
    {
        public static string ToShamsi(this DateTime date)
        {
            try
            {
                var d = date;
                PersianCalendar pc = new PersianCalendar();
                return string.Format("{0}/{1}/{2}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d));
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public static string ToShamsi(this DateTime? date)
        {
            try
            {
                return date == null ? null : ToShamsi(date.Value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime? ToMiladi(this string date)
        {
            try
            {
                var d = date.Split("/").ToList();
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = new DateTime(d[0].ToInt(), d[1].ToInt(), d[2].ToInt(), pc);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static int ToInt(this string var)
        {
            try
            {

                return Convert.ToInt32(var);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static bool IsNullOrEmpty(this string var)
        {
            try
            {

                if (var == null || var.Length == 0 || var.Replace(" ", "").Length == 0)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
