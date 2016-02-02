using EntryXamlControlXamarinForms.ViewModels;
using Xamarin.Forms;

namespace EntryXamlControlXamarinForms.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
