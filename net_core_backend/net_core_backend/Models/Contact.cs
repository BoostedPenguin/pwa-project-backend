using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Models
{
    public class Contact
    {


        private static Random random = new Random();

        public static int GlobalContactID { get; set; } = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int OverdueExpenses { get; set; }
        public string OverdueExpensesDate { get; set; }
        public int ProjectedExpenses { get; set; }
        public string ProjectedExpensesDate { get; set; }

        public List<PaymentHistory> Payments { get; set; } = new List<PaymentHistory>();

        public Contact(string name, string email, string phone, string overdueExpensesDate, int projectedExpenses, string projectedexpensesDate)
        {
            this.Id = GlobalContactID++;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.OverdueExpensesDate = overdueExpensesDate;
            this.ProjectedExpenses = projectedExpenses;
            this.ProjectedExpensesDate = projectedexpensesDate;
        }

        public void AddPayment(PaymentHistory payment)
        {
            this.Payments.Add(payment);
            if(!payment.Paid)
            {
                this.OverdueExpenses += payment.Amount;
            }
        }
    }
}
