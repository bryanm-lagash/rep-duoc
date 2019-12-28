using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;

namespace OnTourWPF2._0
{
    public class SystemException
    {
        public enum Buttons { Si_No, OK, OK2 }



        public static string Show(string ex, string Text)
        {
            return Show(ex, Text, Buttons.OK);
        }

        public static string Show(string ex, string Text, Buttons buttons)
        {
            MessBoxes messageBox = new MessBoxes(ex, Text, buttons);
            messageBox.Show();
            return messageBox.ReturnString;

        }


        public static string ShowDialog(string ex, string Text, Buttons buttons)
        {
            ShowBlurEffectAllWindow();
            MessBoxes messageBox = new MessBoxes(ex, Text, buttons);
            messageBox.ShowDialog();
            StopBlurEffectAllWindow();
            return messageBox.ReturnString;
        }

        static BlurEffect MyBlur = new BlurEffect();
        public static void ShowBlurEffectAllWindow()
        {
            MyBlur.Radius = 20;
            foreach (Window window in Application.Current.Windows)
                window.Effect = MyBlur;
        }

        public static void StopBlurEffectAllWindow()
        {
            MyBlur.Radius = 0;
        }
    }
}
