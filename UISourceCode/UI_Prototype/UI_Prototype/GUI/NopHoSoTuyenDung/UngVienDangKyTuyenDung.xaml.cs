﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using UI_Prototype.GUI.DangKiThanhVien;

namespace UI_Prototype.GUI.NopHoSoTuyenDung
{
    /// <summary>
    /// Interaction logic for UngVienDangKyTuyenDung.xaml
    /// </summary>
    public partial class UngVienDangKyTuyenDung : UserControl
    {
        private SqlConnection _connection;
        public UngVienDangKyTuyenDung(SqlConnection con)
        {
            InitializeComponent();
            _connection = con;
        }
        private void DangKiButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new DSViTriUngTuyen(_connection);
            var result = screen.ShowDialog();
        }
    }
}
