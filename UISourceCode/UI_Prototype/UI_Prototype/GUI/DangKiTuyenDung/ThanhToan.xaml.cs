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

namespace UI_Prototype
{
    /// <summary>
    /// Interaction logic for ThanhToan.xaml
    /// </summary>
    public partial class ThanhToan : Window
    {
        public ThanhToan()
        {
            InitializeComponent();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {

            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;
            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));
            MessageBox.Show("Thanh toán thành công!", "Thành công", MessageBoxButton.OK);
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
            DialogResult= false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
