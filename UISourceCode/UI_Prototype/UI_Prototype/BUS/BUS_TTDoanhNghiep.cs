﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Prototype.DAO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        static public List<BUS_TTDoanhNghiep> LoadData(SqlConnection conn)
        {
            return DAO_TTDoanhNghiep.getTTDoanhNghiep(conn);
        }
        static public List<BUS_TTDoanhNghiep> searchByNameKeywords(SqlConnection conn,string TenDN)
        {
            if(TenDN == null || TenDN == "" || TenDN == " ") {  
                return DAO_TTDoanhNghiep.getTTDoanhNghiep(conn);
            }
            return DAO_TTDoanhNghiep.getByNameKeywords(conn, TenDN);
        }
        static public BindingList<BUS_TTDoanhNghiep> LoadDSDoanhNghiep(SqlConnection connection)
        {
            var result = new BindingList<BUS_TTDoanhNghiep>();

            var dt = DAO_TTDoanhNghiep.getDSTTDoanhNghiep(connection);
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

        static public BindingList<BUS_TTDoanhNghiep> searchByName(SqlConnection connection, string searchName)
        {
            var result = new BindingList<BUS_TTDoanhNghiep>();

            var dt = DAO_TTDoanhNghiep.getByName(connection, searchName);
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

        static public void deleteDNList(SqlConnection connection, List<string> IdDoanhNghiepList)
        {
            DAO_TTDoanhNghiep.deleteTTDoanhNghiep(connection, IdDoanhNghiepList);
        }

        static public void updateDNSelected(SqlConnection connection, BUS_TTDoanhNghiep dataDoanhNghiep)
{
    DAO_TTDoanhNghiep.updateTTDoanhNghiep(connection, dataDoanhNghiep);
}

public static List<BUS_TTDoanhNghiep> LoadDSDoanhNghiepByTiemNang(SqlConnection connection, string tiemNang)
{
    return DAO_TTDoanhNghiep.LoadDSDoanhNghiepByTiemNang(connection, tiemNang);
}
public static void updateTiemNangDoanhNghiep(SqlConnection connection, string idDoanhNghiep, string tiemNang)
{
    if (string.IsNullOrEmpty(idDoanhNghiep) || string.IsNullOrEmpty(tiemNang))
    {
        throw new ArgumentException("ID doanh nghiệp and tiềm năng cannot be null or empty");
    }

    try
    {
        DAO_TTDoanhNghiep.updateTiemNangDoanhNghiep(connection, idDoanhNghiep, tiemNang);
    }
    catch (Exception ex)
    {
        throw new Exception("Failed to update tiềm năng doanh nghiệp: " + ex.Message);
    }
}

    }
}
