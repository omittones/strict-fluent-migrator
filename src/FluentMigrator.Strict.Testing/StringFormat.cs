using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMigrator.Strict.Testing
{
    class StringFormat
    {
        public static string FormatMoney (string value)
        {
            int money;
            string result;

            if (value != "")
            {
                money = int.Parse(value);
                result = (string.Format("£{0:0,0}", money)).PadRight(15);
            }
            else
            {
                result = "No Pension";
            }

            return result;
        }
    }
}
