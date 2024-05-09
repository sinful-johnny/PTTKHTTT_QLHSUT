using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuyTrinhDuyetHoSo
{
    /// <summary>
    /// Interaction logic for DanhSachHoSo.xaml
    /// </summary>
    public partial class DanhSachHoSo : UserControl
    {
        SqlConnection _conn;
        public DanhSachHoSo(SqlConnection conn)
        {
            InitializeComponent();
            _conn = conn;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DSHoSoChuaDuyet_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DSHoSoDaDuyet_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DSHoSoDaGui_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
