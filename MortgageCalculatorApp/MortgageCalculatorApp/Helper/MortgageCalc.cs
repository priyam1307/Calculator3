using MortgageCalculatorApp.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculatorApp.Helper
{
    public enum PeriodType
    {
        Monthly,
        SemiMonthly,
        BiWeekly
    }


    public class MortgageCalc
    {
        public MortgageResultDTO CalculateEMI(MortgageInputDTO mortgageInputDTO)
        {
            //int termInYear = 15;//years
            //decimal loanAmount = 100000;
            //decimal interestRate = 3.5m;//percentage
            MortgageResultDTO mortgageResultDTO = new MortgageResultDTO();

            int termInYear = mortgageInputDTO.TermInYear;
            decimal loanAmount = mortgageInputDTO.LoanAmount;
            decimal interestRate = mortgageInputDTO.InterestRate;

            decimal totalInterest = 0;
            decimal emi = 0;
            decimal lastPayment = 0;
            int numberOfPayments = termInYear * 12; //times 26 for biweekly, 24 for semi monthly
            CalculateInstallmentPayments(mortgageInputDTO.PeriodType, loanAmount, interestRate, termInYear * 12, out totalInterest, out emi, out lastPayment);
            decimal totalPayments = (emi * (numberOfPayments - 1)) + lastPayment;

            mortgageResultDTO.EstimatedPayment = emi;
            mortgageResultDTO.TotalInterest = totalInterest;
            mortgageResultDTO.TotalPayment = totalPayments;
            //loanAmount=principal,interestRate=apr,totalInterest=fee,payment=emi
            return mortgageResultDTO;
        }



        decimal Truncate(decimal d)
        {
            int t = (int)(d * 100.0m);
            return ((decimal)t) / 100.0m;
        }



        bool CalculateInstallmentPayments(PeriodType payPeriodType, decimal principal, decimal apr, decimal numPayments, out decimal fee, out decimal payment, out decimal lastPayment)
        {
            fee = 0;
            payment = 0;
            lastPayment = 0;
            int loanDays = 30;
            try
            {
                decimal balance = principal;
                decimal factor = 1200;
                switch (payPeriodType)
                {
                    case PeriodType.Monthly:
                        factor = 1200;
                        loanDays = 30;
                        break;
                    case PeriodType.SemiMonthly:
                        factor = 2400;
                        loanDays = 15;
                        break;
                    case PeriodType.BiWeekly:
                        factor = 2600;
                        loanDays = 14;
                        break;
                }

                decimal periodicRate = apr / factor;
                decimal temp1 = (1 - ((decimal)Math.Pow((double)(1 + periodicRate), (double)-(numPayments)))) / periodicRate;
                decimal amount = Truncate(balance / temp1);
                decimal totalPayment = 0;
                int days = loanDays;

                for (int i = 0; i < numPayments; i++)
                {
                    decimal interestEarned = balance * ((periodicRate / days) * loanDays);
                    decimal interestEarned2 = interestEarned;
                    interestEarned = Truncate(interestEarned);
                    decimal prin = amount - interestEarned;
                    balance -= prin;
                    totalPayment += amount;
                    if (balance < 0)
                    {
                        totalPayment += balance;
                    }
                }

                lastPayment = Truncate(amount + balance);
                payment = amount;
                fee = Truncate(totalPayment - principal);
                decimal tempFee = payment * (numPayments - 1) + lastPayment;
                tempFee -= principal;
                fee = tempFee;
                fee = Truncate(fee);


                return true;
            }

            catch (Exception ex)
            {
            }
            return false;

        }



    }
}
