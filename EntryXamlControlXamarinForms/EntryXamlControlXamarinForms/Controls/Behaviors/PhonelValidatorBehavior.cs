using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryXamlControlXamarinForms.Controls.Behaviors
{
    public class PhonelValidatorBehavior : BaseValidatorBehavior
    {
        private const string adviceText = "Enter a valid phone";
        private const string phoneRegex = @"^[0-9]\d{11}$";

        public PhonelValidatorBehavior()
            : base(adviceText, phoneRegex)
        {
        }
    }
}
