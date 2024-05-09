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
using UI_Prototype.BUS;
using UI_Prototype.GUI.DangKiTuyenDung;

namespace UI_Prototype
{
    /// <summary>
    /// Interaction logic for TaoHDTuyenDung.xaml
    /// </summary>
    public partial class TaoHDTuyenDung : Window
    {
        public TaoHDTuyenDung()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = false;
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run( () => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;
            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));
            MessageBox.Show("Tạo hợp đồng thành công!", "Thành công", MessageBoxButton.OK);
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ThemSuaViTriDangTuyen();
            screen.ShowDialog();
        }

        private void XoaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SuaButton_Click(object sender, RoutedEventArgs e)
        {
            var data = new BUS_ViTriTuyenDung();
            var screen = new ThemSuaViTriDangTuyen(data);
            screen.ShowDialog();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
