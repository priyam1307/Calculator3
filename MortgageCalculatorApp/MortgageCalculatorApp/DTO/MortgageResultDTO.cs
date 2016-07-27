using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculatorApp.DTO
{
   public class MortgageResultDTO
    {
        public decimal EstimatedPayment { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal TotalInterest { get; set; }
    }
}
