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
                date = date.ConvertToEnglishNumber();
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

        private static Dictionary<char, char> persianToEnglishDigits = new Dictionary<char, char>
            {
                {'۰', '0'},
                {'۱', '1'},
                {'۲', '2'},
                {'۳', '3'},
                {'۴', '4'},
                {'۵', '5'},
                {'۶', '6'},
                {'۷', '7'},
                {'۸', '8'},
                {'۹', '9'}
            };
        public static string ConvertToEnglishNumber(this string var)
        {
            try
            {
                char[] englishDigits = new char[var.Length];

                for (int i = 0; i < var.Length; i++)
                {
                    if (persianToEnglishDigits.ContainsKey(var[i]))
                    {
                        englishDigits[i] = persianToEnglishDigits[var[i]];
                    }
                    else
                    {
                        englishDigits[i] = var[i];
                    }
                }

                return new string(englishDigits);
            }
            catch (Exception)
            {

                return null;
            }
            
        }


        private static Dictionary<char, char> englishToPersianDigits = new Dictionary<char, char>
            {
                {'0','۰'},
                {'1','۱'},
                {'2','۲'},
                {'3','۳'},
                {'4','۴'},
                {'5','۵'},
                {'6','۶'},
                {'7','۷'},
                {'8','۸'},
                {'9','۹'}
            };
        public static string ConvertToPersianNumber(this string var)
        {
            char[] persianDigits = new char[var.Length];

            for (int i = 0; i < var.Length; i++)
            {
                if (englishToPersianDigits.ContainsKey(var[i]))
                {
                    persianDigits[i] = englishToPersianDigits[var[i]];
                }
                else
                {
                    persianDigits[i] = var[i];
                }
            }

            return new string(persianDigits);
        }

    }
}
