using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBank
{
    public static class HelpingClass
    {
        public static Double ToDouble(string value)
        {
            try
            {
                return Convert.ToDouble(value.Replace(",", ""));
            }
            catch
            {
                return 0.0;
            }
        }
    }
}
