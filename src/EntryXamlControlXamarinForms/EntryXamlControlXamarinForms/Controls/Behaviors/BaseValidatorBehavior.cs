using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace EntryXamlControlXamarinForms.Controls.Behaviors
{
    public class BaseValidatorBehavior : Behavior<Entry>
    {
        private readonly string adviceText;
        private bool isCurrentError;
        private bool isValid;
        private readonly string regex;

        // Creating BindableProperties with Limited write access: http://iosapi.xamarin.com/index.aspx?link=M%3AXamarin.Forms.BindableObject.SetValue(Xamarin.Forms.BindablePropertyKey%2CSystem.Object) 

        public BaseValidatorBehavior(string advice, string regex)
        {
            this.adviceText = advice;
            this.regex = regex;
        }

        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool?), typeof(EmailValidatorBehavior), null);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool? IsValid
        {
            get { return (bool?)base.GetValue(IsValidProperty); }
            private set
            {
                base.SetValue(IsValidPropertyKey, value);
                if (value == null || value.Value)
                {
                    Advice = String.Empty;
                }
                else
                {
                    Advice = adviceText;
                }
            }
        }

        static readonly BindablePropertyKey AdvicePropertyKey = BindableProperty.CreateReadOnly("Advice", typeof(string), typeof(EmailValidatorBehavior), String.Empty);
        public static readonly BindableProperty AdviceProperty = AdvicePropertyKey.BindableProperty;

        public string Advice
        {
            get { return (string)base.GetValue(AdviceProperty); }
            private set { base.SetValue(AdvicePropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            bindable.Unfocused += BindableOnUnfocused;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            bindable.Unfocused -= BindableOnUnfocused;
        }

        private void BindableOnUnfocused(object sender, FocusEventArgs focusEventArgs)
        {
            IsValid = isValid;
            isCurrentError = !isValid;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != null)
            {
                isValid =
                    (Regex.IsMatch(e.NewTextValue, regex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                if (isCurrentError || isValid)
                {
                    IsValid = isValid;
                    isCurrentError = true;
                }
                if (e.NewTextValue == String.Empty)
                {
                    IsValid = null;
                    isCurrentError = false;
                }
            }
        }
    }
}
