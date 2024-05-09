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
using System.Windows.Shapes;

namespace QuyTrinhDuyetHoSo
{
    /// <summary>
    /// Interaction logic for ChonViTriXetDuyen.xaml
    /// </summary>
    public partial class ChonViTriXetDuyen : Window
    {
        SqlConnection _conn;
        public ChonViTriXetDuyen(SqlConnection conn)
        {
            InitializeComponent();
            _conn = conn;
        }

        private void MainDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
