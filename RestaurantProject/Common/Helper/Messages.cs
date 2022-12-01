using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
   public static class Messages
    {
        public static string Successed { get { return "با موفقیت انجام شد"; } }
        public static string Error { get { return " متاسفانه انجام نشد"; } }
        public static string UnexpectedError { get { return " خطای پیش بینی نشده"; } }
        public static string NotFund { get { return "موجودیت یافت نشد"; } }
       public static string NullMassages { get { return "داده ای برای نمایش وجود ندارد"; } }
    }
}
