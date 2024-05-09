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
        int _mode = 1;
        public ThemSuaViTriDangTuyen(BUS_ViTriTuyenDung data)
        {
            InitializeComponent();
            _DataContext = data;
            IDViTriTextBox.IsEnabled = false;
            _mode = Mode.Update;
        }
        public ThemSuaViTriDangTuyen()
        {
            InitializeComponent();
            _DataContext = new BUS_ViTriTuyenDung();
            _mode = Mode.Update;
        }
        internal class Mode
        {
            static public int Insert => 1;
            static public int Update => 2;
        }
    }
}
