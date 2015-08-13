using EntryXamlControlXamarinForms.Controls.Behaviors;
using EntryXamlControlXamarinForms.Converters;
using Xamarin.Forms;

namespace EntryXamlControlXamarinForms.Controls
{
    public partial class EntryPromptControl : ContentView
    {
        public static readonly BindableProperty InputBehaviorProperty =
            BindableProperty.Create<EntryPromptControl, Behavior<Entry>>(p => p.BehaviorEntry, null);

        public Behavior<Entry> BehaviorEntry
        {
            get { return (Behavior<Entry>) GetValue(InputBehaviorProperty); }
            set
            {
                SetValue(InputBehaviorProperty, value);
                if (Input.Behaviors.Count != null)
                {
                    Input.Behaviors.Add(value);

                    Input.SetBinding(Entry.TextProperty, "Text", BindingMode.TwoWay);
                    Input.SetBinding(Entry.PlaceholderProperty, "Placeholder", BindingMode.TwoWay);
                    Input.SetBinding(Entry.IsPasswordProperty, "IsPassword", BindingMode.TwoWay);
                    Input.SetBinding(Entry.TextColorProperty, "TextColor", BindingMode.TwoWay);
                    Input.SetBinding(Entry.KeyboardProperty, "Keyboard", BindingMode.TwoWay);
                    Input.BindingContext = this;

                    Advice.SetBinding(Label.TextProperty, "Advice");
                    Advice.BindingContext = value;

                    BadStatus.SetBinding(Image.IsVisibleProperty,
                        new Binding("IsValid", BindingMode.OneWay, new NullableBoolToVisibility(), false));
                    BadStatus.BindingContext = value;

                    GoodStatus.SetBinding(Image.IsVisibleProperty,
                        new Binding("IsValid", BindingMode.OneWay, new NullableBoolToVisibility(), true));
                    GoodStatus.BindingContext = value;

                    (value as BaseValidatorBehavior).SetBinding(BaseValidatorBehavior.IsValidProperty, "IsValid",
                        BindingMode.TwoWay);
                    (value as BaseValidatorBehavior).BindingContext = this;
                }
            }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<EntryPromptControl, string>(p => p.Text, string.Empty, BindingMode.TwoWay);

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create<EntryPromptControl, string>(p => p.Placeholder, string.Empty, BindingMode.TwoWay);

        public string Placeholder
        {
            get { return (string) GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create<EntryPromptControl, bool>(p => p.IsPassword, false, BindingMode.TwoWay);

        public bool IsPassword
        {
            get { return (bool) GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create<EntryPromptControl, Color>(p => p.TextColor, Color.Black, BindingMode.TwoWay);

        public Color TextColor
        {
            get { return (Color) GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create<EntryPromptControl, Keyboard>(p => p.Keyboard, Keyboard.Text, BindingMode.TwoWay);

        public Keyboard Keyboard
        {
            get { return (Keyboard) GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create<EntryPromptControl, bool>(p => p.IsValid, false, BindingMode.TwoWay);

        public bool IsValid
        {
            get { return (bool) GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        public EntryPromptControl()
        {
            InitializeComponent();
        }
    }
}
