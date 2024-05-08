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
    /// Interaction logic for DuyetHoSo.xaml
    /// </summary>
    public partial class DuyetHoSo : UserControl
    {
        SqlConnection _conn;
        public DuyetHoSo(SqlConnection conn)
        {
            InitializeComponent();
            _conn = conn;
        }

        private void DSHoSoUngTuyenDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChonViTriXetDuyetButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ChonViTriXetDuyen(_conn);
        }

        private void DSHoSoUngTuyenDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void GuiDSHoSoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DuyetDSHoSoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
