
using MortgageCalculatorApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculatorApp.DTO
{
    public class MortgageInputDTO
    {
        public int TermInYear { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }      
        public PeriodType PeriodType { get; set; }
    }
}
