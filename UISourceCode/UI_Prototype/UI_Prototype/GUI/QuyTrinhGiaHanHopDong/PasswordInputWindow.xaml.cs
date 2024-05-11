using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI_Prototype.GUI.QuyTrinhGiaHanHopDong
{
    /// <summary>
    /// Interaction logic for PasswordInputWindow.xaml
    /// </summary>
    public class PasswordInputWindow : Window
    {
        public string Password { get; private set; }

        public PasswordInputWindow()
        {
            var label = new Label { Content = "Enter Password:" };
            var passwordBox = new PasswordBox();
            var button = new Button { Content = "OK" };

            button.Click += (sender, e) =>
            {
                Password = passwordBox.Password;
                this.Close();
            };

            var stackPanel = new StackPanel();
            stackPanel.Children.Add(label);
            stackPanel.Children.Add(passwordBox);
            stackPanel.Children.Add(button);

            this.Content = stackPanel;
            this.Width = 200;
            this.Height = 100;
        }
    }
}
