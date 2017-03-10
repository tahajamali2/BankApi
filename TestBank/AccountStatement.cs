using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBank
{
    public class AccountStatement
    {
        public AccountStatement()
        {

        }

        public double OpeningBalance { get; set; }
        public double ClosingBalance { get; set; }

        public IList<AccountActivity> Activities { get; set; }


    }
}
