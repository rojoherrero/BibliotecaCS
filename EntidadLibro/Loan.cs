using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesApi
{
    public class Loan
    {
        public long LoanId { get; set; }
        public string ISBN { get; set; }
        public long UserId { get; set; }
        public DateTime InitalDate { get; set; }
        public DateTime FinalDate { get; set; }

        //Constructor vacio
        public Loan() { }

        //Constructor con argumentos
        public Loan(long loanId, string isbn, long userId, DateTime initialDate, DateTime finalDate)
        {
            LoanId = loanId;
            ISBN = isbn;
            UserId = userId;
            InitalDate = initialDate;
            FinalDate = finalDate;
        }

        public string ShowTabulatedInfo()
        {
            StringBuilder message = new StringBuilder();
            message.Append(LoanId);
            message.Append("\t\t");
            message.Append(UserId);
            message.Append("\t\t");
            message.Append(ISBN);
            message.Append("\t\t");
            message.Append(InitalDate.ToShortDateString());
            message.Append("\t\t");
            message.Append(FinalDate.ToShortDateString());
            
            return message.ToString();
        }

    }
}
