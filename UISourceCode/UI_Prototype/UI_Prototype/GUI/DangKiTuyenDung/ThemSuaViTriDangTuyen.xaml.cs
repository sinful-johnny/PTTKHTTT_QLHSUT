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

namespace UI_Prototype.GUI.DangKiTuyenDung
{
    /// <summary>
    /// Interaction logic for ThemSuaViTriDangTuyen.xaml
    /// </summary>
    public partial class ThemSuaViTriDangTuyen : Window
    {
        BUS_ViTriTuyenDung _DataContext;
        public ThemSuaViTriDangTuyen(BUS_ViTriTuyenDung data)
        {
            InitializeComponent();
            _DataContext = data;
            IDViTriTextBox.IsEnabled = false;
        }
        public ThemSuaViTriDangTuyen()
        {
            InitializeComponent();
            _DataContext = new BUS_ViTriTuyenDung();
        }
    }
}
