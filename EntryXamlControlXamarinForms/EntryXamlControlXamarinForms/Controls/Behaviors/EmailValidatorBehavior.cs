using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryXamlControlXamarinForms.Controls.Behaviors
{
    public class EmailValidatorBehavior : BaseValidatorBehavior
    {
        private const string adviceText = "Enter a valid email";
        private const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public EmailValidatorBehavior()
            : base(adviceText, emailRegex)
        {     
        }
    }
}
