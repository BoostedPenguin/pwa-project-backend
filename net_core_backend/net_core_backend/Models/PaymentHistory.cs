using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Models
{
    public class PaymentHistory
    {
        public static int PaymentGlobalID { get; set; } = 0;
        public int HistoryID { get; set; }
        public int ContactID { get; set; }
        public string Title { get; set; }
        public string PaymentDate { get; set; }
        public bool Paid { get; set; } = true;
        public int Amount { get; set; }

        public PaymentHistory(string title, string paymentdate, int amount)
        {
            this.HistoryID = PaymentGlobalID++;
            this.Title = title;
            this.PaymentDate = paymentdate;
            this.Amount = amount;
        }

        public PaymentHistory(string title, string paymentdate, int amount, bool paid)
        {
            this.HistoryID = PaymentGlobalID++;
            this.Title = title;
            this.Amount = amount;
            this.PaymentDate = paymentdate;
            this.Paid = paid;
        }
    }
}
