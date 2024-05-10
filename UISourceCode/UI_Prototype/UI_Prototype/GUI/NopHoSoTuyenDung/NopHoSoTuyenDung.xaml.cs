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

namespace UI_Prototype.GUI.NopHoSoTuyenDung
{
    /// <summary>
    /// Interaction logic for NopHoSoTuyenDung.xaml
    /// </summary>
    public partial class NopHoSoTuyenDung : Window
    {
        private SqlConnection _connection;
        public NopHoSoTuyenDung(SqlConnection con)
        {
            InitializeComponent();

        _connection = con;
        }

        private void HopLeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
