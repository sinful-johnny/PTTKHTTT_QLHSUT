using QuyTrinhDuyetHoSo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UI_Prototype.GUI.QuyTrinhDuyetHoSo
{
    /// <summary>
    /// Interaction logic for QuyTrinhDuyetHoSoMainWindow.xaml
    /// </summary>
    public partial class QuyTrinhDuyetHoSoMainWindow : Window
    {
        SqlConnection _conn;
        public QuyTrinhDuyetHoSoMainWindow()
        {
            InitializeComponent();
            var tabItems = new ObservableCollection<TabItem>() {
                new TabItem(){Header = "Danh sách hồ sơ", Content = new DanhSachHoSo(_conn)},
                new TabItem(){Header = "Duyệt hồ sơ ứng tuyển", Content = new DuyetHoSo(_conn)},
            };

            MainTabControl.ItemsSource = tabItems;
        }
    }
}
