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
        internal class Mode
        {
            static public int Insert => 1;
            static public int Update => 2;
        }
        public BUS_ViTriTuyenDung? _originalData;
        public BUS_ViTriTuyenDung _DataContext;
        int _mode = Mode.Insert;
        public ThemSuaViTriDangTuyen(BUS_ViTriTuyenDung data)
        {
            InitializeComponent();
            _originalData = (BUS_ViTriTuyenDung)data.Clone();
            _DataContext = data;
            IDViTriTextBox.IsEnabled = false;
            _mode = Mode.Update;
            DataContext = _DataContext;
        }
        public ThemSuaViTriDangTuyen()
        {
            InitializeComponent();
            _DataContext = new BUS_ViTriTuyenDung();
            _mode = Mode.Update;
            DataContext = _DataContext;
        }
        

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
