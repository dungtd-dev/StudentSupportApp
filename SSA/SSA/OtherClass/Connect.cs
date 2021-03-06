﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentSupportApp
{
    class Connect
    {
        SqlConnection Connection;
        public Connect()
        {
            String connString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
            //String connString = @"Server=LAPTOP-SJVI7FIS;Database=SSADATABASE;User Id=sa;Password=Dung2406";
            this.Connection = new SqlConnection(connString);
        }
        public void OpenConnection()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi, vui lòng liên hệ đội ngũ phát triển!");
                ReportError rp = new ReportError(ex);
                rp.Show();
            }
        }
        public SqlCommand CreateSQLCmd(string args)
        {
            String sqlQuery = args;
            SqlCommand command = new SqlCommand(sqlQuery, Connection);
            return command;
        }
        public void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi, vui lòng liên hệ đội ngũ phát triển!");
                ReportError rp = new ReportError(ex);
                rp.Show();
            }
        }
    }
}
