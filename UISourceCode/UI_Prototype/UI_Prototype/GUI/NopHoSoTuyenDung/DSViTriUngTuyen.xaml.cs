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
using System.Data.SqlClient;
using System.Drawing;
using UI_Prototype.BUS;
using UI_Prototype.DAO;

namespace UI_Prototype.GUI.NopHoSoTuyenDung
{
    /// <summary>
    /// Interaction logic for DSViTriUngTuyen.xaml
    /// </summary>
    public partial class DSViTriUngTuyen : Window
    {
        private SqlConnection _connection;
        public DSViTriUngTuyen(SqlConnection con)
        {
            InitializeComponent();
            _connection = con;
        }

        private void XemDSButton_Click(object sender, RoutedEventArgs e)
        {
            DSVITRIUNGTUYENDataGrid.ItemsSource = BUS_DSVITRIUNGTUYEN.LoadData(_connection);
        }
        private void NopHoSoButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new NopHoSoTuyenDung(_connection);
            var result = screen.ShowDialog();
        }
    }
}
