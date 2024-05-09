using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using UI_Prototype.DAO;
using System.ComponentModel;

namespace UI_Prototype.BUS
{
    public class BUS_TTDoanhNghiep
    {
        public string? IDDoanhNghiep { get; set; }
        public string? TenCongTy { get; set; }
        public string? IDThue { get; set; }
        public string? NguoiDaiDien { get; set; }
        public string? DiaChi { get; set; }
        public string? Email { get; set; }
        public string? TinhTrangXacThuc { get; set; }
        public string? TiemNangDoanhNghiep { get; set; }
        public string? ChinhSachUuDai { get; set; }

        public BindingList<BUS_TTDoanhNghiep> LoadDSDoanhNghiep(SqlConnection connection)
        {
            var result = new BindingList<BUS_TTDoanhNghiep>();

            var daoTTDN = new DAO_TTDoanhNghiep();
            var dt = daoTTDN.getDSTTDoanhNghiep(connection);
            foreach (DataRow row in dt.Rows)
            {
                var newTTDN = new BUS_TTDoanhNghiep
                {
                    IDDoanhNghiep = (string)row["ID_DOANHNGHIEP"],
                    TenCongTy = (string)row["TEN_CONGTY"],
                    IDThue = (string)row["ID_THUE"],
                    NguoiDaiDien = (string)row["NGUOIDAIDIEN"],
                    DiaChi = (string)row["DIACHI"],
                    Email = (string)row["EMAIL"],
                    TinhTrangXacThuc = (string)row["TINHTRANG_XACTHUC"]
                };
                result.Add(newTTDN);
            }

            return result;
        }

        public BindingList<BUS_TTDoanhNghiep> searchByName(SqlConnection connection, string searchName)
        {
            var result = new BindingList<BUS_TTDoanhNghiep>();

            var daoTTDN = new DAO_TTDoanhNghiep();
            var dt = daoTTDN.getByName(connection, searchName);
            foreach (DataRow row in dt.Rows)
            {
                var newTTDN = new BUS_TTDoanhNghiep
                {
                    IDDoanhNghiep = (string)row["ID_DOANHNGHIEP"],
                    TenCongTy = (string)row["TEN_CONGTY"],
                    IDThue = (string)row["ID_THUE"],
                    NguoiDaiDien = (string)row["NGUOIDAIDIEN"],
                    DiaChi = (string)row["DIACHI"],
                    Email = (string)row["EMAIL"],
                    TinhTrangXacThuc = (string)row["TINHTRANG_XACTHUC"]
                };
                result.Add(newTTDN);
            }

            return result;
        }

    }
}
