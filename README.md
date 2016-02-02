# smart input xamarin forms with behaviors 
Smart input for Xamarin.Forms

Smart input control try validate enty field and give advice to you to improve text.

### Screenshot

![screenshots](https://raw.githubusercontent.com/Ontropix/smart-input/master/src/Sreenshots/inputGif1.gif)

![screenshots](https://raw.githubusercontent.com/Ontropix/smart-input/master/src/Sreenshots/inputGif2.gif)

### Control

```
<controls:EntryPromptControl
  HorizontalOptions="FillAndExpand"
  Placeholder="example@mail.com"
  Text="{Binding Email, Mode=TwoWay}"
  IsValid="{Binding IsEmailValid, Mode=TwoWay}"
  Keyboard="Email">
  
  <controls:EntryPromptControl.BehaviorEntry>
    <behaviors:EmailValidatorBehavior/>
  </controls:EntryPromptControl.BehaviorEntry>
  
</controls:EntryPromptControl>
```

You can add your own behavior with some adice and regex expression. 

```
public class EmailValidatorBehavior : BaseValidatorBehavior
    {
        private const string adviceText = "Enter a valid email";
        private const string emailRegex =  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public EmailValidatorBehavior()
            : base(adviceText, emailRegex)
        {     
        }
    }
```

### Platforms
0. iOS
0. Android
0. Windows Phone

### TODO:
0. Mutli-behaviors(add many behaviors for entry)
0. Add piority for notications

