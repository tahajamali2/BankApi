using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBank
{
    public class AccountActivity
    {
        public AccountActivity()
        {

        }

        public DateTime TransactionDate { get; set; }
        public DateTime ValueDate { get; set; }
        public string TransactionReferenceNo { get; set; }
        public string Description { get; set; }
        public Double Debit { get; set; }
        public Double Credit { get; set; }
        public Double Balance { get; set; }

    }
}
