using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MortgageCalculatorApp.ValidatorBehavior
{
    public class RequiredValidator : Behavior<Entry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(RequiredValidator), false);
        static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
            //bindable.Unfocused += HandleFocusChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = !string.IsNullOrEmpty(((Entry)sender).Text);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
            //bindable.Unfocused -= HandleFocusChanged;
        }
        void HandleFocusChanged(object sender, FocusEventArgs e)
        {
            IsValid = !string.IsNullOrEmpty(((Entry)sender).Text);
        }
    }
}
