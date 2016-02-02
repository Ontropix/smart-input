using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace EntryXamlControlXamarinForms.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                RaisePropertyChanged(() => Phone);
            }
        }

        private bool isValidPhone;
        public bool IsValidPhone
        {
            get { return isValidPhone; }
            set
            {
                isValidPhone = value;
                RaisePropertyChanged(() => IsValidPhone);
            }
        }

        private bool isEmailValid;
        public bool IsEmailValid
        {
            get { return isEmailValid; }
            set
            {
                isEmailValid = value;
                RaisePropertyChanged(() => IsEmailValid);
            }
        }
    }
}
