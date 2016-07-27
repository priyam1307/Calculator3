using MortgageCalculatorApp.DTO;
using MortgageCalculatorApp.Helper;
using Rg.Plugins.Popup.Extensions;
using System;
using Xamarin.Forms;

namespace MortgageCalculatorApp.Pages
{
 
    public partial class MortgageCalculatorPage : ContentPage
    {
        public MortgageCalculatorPage()
        {
            InitializeComponent();
            lblTermInYear.IsVisible = false;
            lblinterestRate.IsVisible = false;
            lblloanAmount.IsVisible = false;
        }

        MortgageInputDTO mortgageInputDTO = new MortgageInputDTO();    


        public void MonthlyClicked(object sender, EventArgs e)
        {
            mortgageInputDTO.PeriodType = PeriodType.Monthly;
        }

        public void WeeklyClicked(object sender, EventArgs e)
        {
            mortgageInputDTO.PeriodType = PeriodType.BiWeekly;
            Navigation.PushAsync(new NavigationPage(new sample()));
        }

        public void CalculateClicked(object sender, EventArgs e)
        {
            bool isValid = loanAmountValidator.IsValid && termInYearValidator.IsValid && interestRateValidator.IsValid;
            if (lblinterestRate.IsVisible == false && lblloanAmount.IsVisible == false && lblTermInYear.IsVisible == false)
            {
                if (isValid)
                {
                    if (CheckIsNumber(termInYear.Text))
                    {
                        if (CheckIsNumber(loanAmount.Text))
                        {
                            MortgageResultDTO mortgageResultDTO = new MortgageResultDTO();
                            MortgageCalc mortgageCalc = new MortgageCalc();

                            mortgageInputDTO.LoanAmount = Convert.ToDecimal(loanAmount.Text);
                            mortgageInputDTO.InterestRate = Convert.ToDecimal(interestRate.Text);
                            mortgageInputDTO.TermInYear = Convert.ToInt32(termInYear.Text);
                         

                            mortgageResultDTO = mortgageCalc.CalculateEMI(mortgageInputDTO);

                            estPaymentAmount.Text = mortgageResultDTO.EstimatedPayment.ToString();
                            totalInterest.Text = mortgageResultDTO.TotalInterest.ToString();
                            totalPayment.Text = mortgageResultDTO.TotalPayment.ToString();
                        }
                        else
                        {
                            lblTermInYear.Text = "Invalid mortgage amount.";
                            lblTermInYear.IsVisible = true;
                        }
                    }
                    else
                    {
                        lblTermInYear.Text = "Invalid term in year.";
                        lblTermInYear.IsVisible = true;
                    }
                }
                else
                {
                    lblTermInYear.Text = "All fields are required.";
                    lblTermInYear.IsVisible = true;
                }
            }           
           
        }

        void TermInYearUnfocused(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(termInYear.Text))
            {
                var isNumeric = CheckIsNumber(termInYear.Text);
                if (!isNumeric)
                {
                    lblTermInYear.Text = "Invalid term in year.";
                    lblTermInYear.IsVisible = true;
                }
            }
            else
            {
                lblTermInYear.Text = "Required.";
                lblTermInYear.IsVisible = true;
            }

        }
        void InterestRateUnfocused(object sender, EventArgs e)
        {           
            if (!string.IsNullOrEmpty(interestRate.Text))
            {
                decimal n;
                bool isDecimal = decimal.TryParse(interestRate.Text, out n);
                if(!isDecimal)
                {
                    lblinterestRate.Text = "Invalid interest rate.";
                    lblinterestRate.IsVisible = true;
                }
            }
            else
            {
                lblinterestRate.Text = "Required.";
                lblinterestRate.IsVisible = true;
            }
        }

        void LoanAmountUnfocused(object sender, EventArgs e)
        {            
            if (!string.IsNullOrEmpty(loanAmount.Text))
            {
                var isNumeric = CheckIsNumber(loanAmount.Text);
                if (!isNumeric)
                {
                    lblloanAmount.Text = "Invalid mortgage amount.";
                    lblloanAmount.IsVisible = true;
                }
            }
            else
            {
                lblloanAmount.Text = "Required.";
                lblloanAmount.IsVisible = true;
            }

        }
        void TermInYearFocused(object sender, EventArgs e)
        {
            lblTermInYear.IsVisible = false;
        }
        void InterestRateFocused(object sender, EventArgs e)
        {
            if (lblTermInYear.Text == "All fields are required.")
            {
                lblTermInYear.IsVisible = false;
            }
            lblinterestRate.IsVisible = false;
        }

        void LoanAmountFocused(object sender, EventArgs e)
        {
            if (lblTermInYear.Text == "All fields are required.")
            {
                lblTermInYear.IsVisible = false;
            }
            lblloanAmount.IsVisible = false;
        }

        public bool CheckIsNumber(string input)
        {
            int n;
            bool isNumeric = int.TryParse(input, out n);
            return isNumeric;
        }

        //private double width = 0;
        //private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ( width > height)
            {
                
            }

        }
        //protected override bool OnBackButtonPressed()
        //{
        //    return true;
        //}
    }
}
