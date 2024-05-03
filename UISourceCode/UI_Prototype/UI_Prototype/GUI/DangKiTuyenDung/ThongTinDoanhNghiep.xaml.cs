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
    /// Interaction logic for ThongTinDoanhNghiep.xaml
    /// </summary>
    public partial class ThongTinDoanhNghiep : Window
    {
        public ThongTinDoanhNghiep()
        {
            InitializeComponent();
        }

        void LoadData()
        {

        }

        private void HDTuyenDungDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TTDoanhNghiepDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DangKiButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TaoMoiHDButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new TaoHDTuyenDung();
            var result = screen.ShowDialog();
            if(result == true)
            {
                
                LoadData();
            }
        }

        private void ChinhSuaHDButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ChinhSuaHDTuyenDung();
            var result = screen.ShowDialog();
            if (result == true)
            {
                LoadData();
            }
        }

        private void ThanhToanButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ThanhToan();
            var result = screen.ShowDialog();
            if (result == true)
            {
                LoadData();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
