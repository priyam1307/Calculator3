using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MortgageCalculatorApp.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Btn.IsEnabled = false;
            Navigation.PushAsync(new MortgageCalculatorPage());           
        }

       
        private async void OnOpenPopup(object sender, EventArgs e)
        {
            var page = new PopupContentPage();
            await Navigation.PushPopupAsync(page);
        }

        protected override void OnAppearing()
        {
            Btn.IsEnabled = true;
        }
    }
}
