using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DBCore
{
    public class DBConnection: IDBConnection
    {
        private IConfiguration _config;
        public string DefaultConnectionString { get; set; }
        public DBConnection(IConfiguration config)
        {
            _config = config;
            DefaultConnectionString = _config.GetSection("ConnectionStrings:KAS").Value;
        }

  
        public async Task<string> IUD(string QUERY, Hashtable PARAM, string ServerId = "")
        {
            try
            {

                using (SqlConnection SQL_CONNETION = new SqlConnection(DefaultConnectionString))
                {
                    using (SqlCommand SQL_COMMAND = SQL_CONNETION.CreateCommand())
                    {
                        using (SqlDataAdapter DbAdapter = new SqlDataAdapter())
                        {
                            if (SQL_CONNETION != null && SQL_CONNETION.State == 0)
                            {
                                await SQL_CONNETION.OpenAsync();
                            }
                            else if (SQL_CONNETION != null && (SQL_CONNETION.State.Equals(ConnectionState.Connecting)))
                            {
                                SQL_CONNETION.Dispose();
                                await SQL_CONNETION.OpenAsync();
                            }
                            SQL_COMMAND.Connection = SQL_CONNETION;
                            SQL_COMMAND.CommandText = QUERY;
                            SQL_COMMAND.CommandType = CommandType.StoredProcedure;
                            SQL_COMMAND.Parameters.Clear();
                            SQL_COMMAND.CommandTimeout = 60;
                            foreach (string para in PARAM.Keys)
                            {
                                SQL_COMMAND.Parameters.AddWithValue(para, PARAM[para]);
                            }
                            int result = await SQL_COMMAND.ExecuteNonQueryAsync();
                            if (result > 0)
                            {
                                return await Task.FromResult("SUCCESS");
                            }
                            else
                            {
                                return await Task.FromResult("NO ROW EFFECTED");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<DataTable> SELECT_QUERY(string QUERY, Hashtable PARAM, string ServerId = "")
        {
            DataTable obj = new DataTable();
            try
            {

                using (SqlConnection SQL_CONNETION = new SqlConnection(DefaultConnectionString))
                {
                    using (SqlCommand SQL_COMMAND = SQL_CONNETION.CreateCommand())
                    {
                        using (SqlDataAdapter DbAdapter = new SqlDataAdapter())
                        {
                            if (SQL_CONNETION != null && SQL_CONNETION.State == 0)
                            {
                                await SQL_CONNETION.OpenAsync();
                            }
                            else if (SQL_CONNETION != null && (SQL_CONNETION.State.Equals(ConnectionState.Connecting)))
                            {
                                SQL_CONNETION.Dispose();
                                await SQL_CONNETION.OpenAsync();
                            }
                            SQL_COMMAND.Connection = SQL_CONNETION;
                            SQL_COMMAND.CommandText = QUERY;
                            SQL_COMMAND.CommandType = CommandType.StoredProcedure;
                            SQL_COMMAND.Parameters.Clear();
                            SQL_COMMAND.CommandTimeout = 99999;
                            foreach (string para in PARAM.Keys)
                            {
                                SQL_COMMAND.Parameters.AddWithValue(para, PARAM[para]);
                            }
                            DbAdapter.SelectCommand = (SQL_COMMAND);
                            await Task.Run(() => DbAdapter.Fill(obj));
                            DbAdapter.Dispose();
                            await SQL_CONNETION.CloseAsync();
                            return obj;

                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> SELECT_QUERY_V1(string QUERY, Hashtable PARAM, string ServerId = "")
        {
            DataTable obj = new DataTable();
            try
            {

                using (SqlConnection SQL_CONNETION = new SqlConnection(DefaultConnectionString))
                {
                    using (SqlCommand SQL_COMMAND = SQL_CONNETION.CreateCommand())
                    {
                        using (SqlDataAdapter DbAdapter = new SqlDataAdapter())
                        {
                            if (SQL_CONNETION != null && SQL_CONNETION.State == 0)
                            {
                                await SQL_CONNETION.OpenAsync();
                            }
                            else if (SQL_CONNETION != null && (SQL_CONNETION.State.Equals(ConnectionState.Connecting)))
                            {
                                SQL_CONNETION.Dispose();
                                await SQL_CONNETION.OpenAsync();
                            }
                            SQL_COMMAND.Connection = SQL_CONNETION;
                            SQL_COMMAND.CommandText = QUERY;
                            SQL_COMMAND.CommandType = CommandType.Text;
                            SQL_COMMAND.Parameters.Clear();
                            SQL_COMMAND.CommandTimeout = 99999;
                            foreach (string para in PARAM.Keys)
                            {
                                SQL_COMMAND.Parameters.AddWithValue(para, PARAM[para]);
                            }
                            DbAdapter.SelectCommand = (SQL_COMMAND);
                            await Task.Run(() => DbAdapter.Fill(obj));
                            DbAdapter.Dispose();
                            return obj;

                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataSet> EXECUTE_STOREDPROCEDURE_DATASET(string SP_NAME, Hashtable PARAM, string DataSetName, string ServerId = "")
        {
            DataSet ds = new DataSet(DataSetName);
            try
            {

                using (SqlConnection SQL_CONNETION = new SqlConnection(DefaultConnectionString))
                {
                    using (SqlCommand SQL_COMMAND = SQL_CONNETION.CreateCommand())
                    {
                        using (SqlDataAdapter DbAdapter = new SqlDataAdapter())
                        {
                            if (SQL_CONNETION != null && SQL_CONNETION.State == 0)
                            {
                                await SQL_CONNETION.OpenAsync();
                            }
                            else if (SQL_CONNETION != null && (SQL_CONNETION.State.Equals(ConnectionState.Connecting)))
                            {
                                await SQL_CONNETION.DisposeAsync();
                                await SQL_CONNETION.OpenAsync();
                            }
                            SQL_COMMAND.Connection = SQL_CONNETION;
                            SQL_COMMAND.CommandText = SP_NAME;
                            SQL_COMMAND.CommandType = CommandType.StoredProcedure;//CommandType.StoredProcedure;
                            SQL_COMMAND.Parameters.Clear();
                            SQL_COMMAND.CommandTimeout = 60;
                            foreach (string para in PARAM.Keys)
                            {
                                SQL_COMMAND.Parameters.AddWithValue(para, PARAM[para]);
                            }
                            DbAdapter.SelectCommand = (SQL_COMMAND);
                            await Task.Run(() => DbAdapter.Fill(ds));
                            DbAdapter.Dispose();
                            SQL_COMMAND.Dispose();
                            return await Task.FromResult(ds);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<DataTable> EXECUTE_SELECT_QUERY(string SELECTQUERY, Hashtable PARAM)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection SQL_CONNETION = new SqlConnection(_config.GetSection("ConnectionStrings:talkPHRConnectionString14").Value))
                {
                    using (SqlCommand SQL_COMMAND = SQL_CONNETION.CreateCommand())
                    {
                        using (SqlDataAdapter DbAdapter = new SqlDataAdapter())
                        {
                            if (SQL_CONNETION != null && SQL_CONNETION.State == 0)
                            {
                                await SQL_CONNETION.OpenAsync();
                            }
                            else if (SQL_CONNETION != null && (SQL_CONNETION.State.Equals(ConnectionState.Connecting)))
                            {
                                SQL_CONNETION.Dispose();
                                await SQL_CONNETION.OpenAsync();
                            }
                            SQL_COMMAND.Connection = SQL_CONNETION;
                            SQL_COMMAND.CommandText = SELECTQUERY;
                            SQL_COMMAND.CommandType = CommandType.StoredProcedure;
                            SQL_COMMAND.Parameters.Clear();
                            SQL_COMMAND.CommandTimeout = 99999;
                            foreach (string para in PARAM.Keys)
                            {
                                SQL_COMMAND.Parameters.AddWithValue(para, PARAM[para]);
                            }
                            DbAdapter.SelectCommand = (SQL_COMMAND);
                            await Task.Run(() => DbAdapter.Fill(dt));
                            DbAdapter.Dispose();
                            return dt;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> CreateBackupDB()
        {
            string backupDestination = @"D:\SQLBackUpFolder\";
            // check if backup folder exist, otherwise create it.
            if (!System.IO.Directory.Exists(backupDestination))
            {
                System.IO.Directory.CreateDirectory(@"D:\SQLBackUpFolder");
            }
            try
            {

                using (SqlConnection SQL_CONNETION = new SqlConnection(DefaultConnectionString))
                {
                    using (SqlCommand SQL_COMMAND = SQL_CONNETION.CreateCommand())
                    {
                        using (SqlDataAdapter DbAdapter = new SqlDataAdapter())
                        {
                            if (SQL_CONNETION != null && SQL_CONNETION.State == 0)
                            {
                                await SQL_CONNETION.OpenAsync();
                            }
                            else if (SQL_CONNETION != null && (SQL_CONNETION.State.Equals(ConnectionState.Connecting)))
                            {
                                SQL_CONNETION.Dispose();
                                await SQL_CONNETION.OpenAsync();
                            }
                            SQL_COMMAND.Connection = SQL_CONNETION;
                            SQL_COMMAND.CommandText = "backup database KhanAirServiceDB to disk='" + backupDestination + "KAS.Bak'";
                            SQL_COMMAND.CommandType = CommandType.Text;
                            SQL_COMMAND.Parameters.Clear();
                            SQL_COMMAND.CommandTimeout = 60;
                            int result = await SQL_COMMAND.ExecuteNonQueryAsync();
                            if (result == -1)
                            {
                                return await Task.FromResult("SUCCESS");
                            }
                            else
                            {
                                return await Task.FromResult("NO ROW EFFECTED");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }
        //public async Task<string> CreateBackupDB()
        //{
        //    SqlConnection sqlconn = new SqlConnection(DefaultConnectionString);
        //    SqlCommand sqlcmd = new SqlCommand();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    // Backup destibation
        //    string backupDestination = @"D:\SQLBackUpFolder\";
        //    // check if backup folder exist, otherwise create it.
        //    if (!System.IO.Directory.Exists(backupDestination))
        //    {
        //        System.IO.Directory.CreateDirectory(@"D:\SQLBackUpFolder");
        //    }
        //    try
        //    {
        //        sqlconn.Open();
        //        sqlcmd = new SqlCommand("backup database TutorialsPanel to disk='" + backupDestination + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'", sqlconn);
        //        sqlcmd.ExecuteNonQuery();
        //        //Close connection
        //        sqlconn.Close();
        //        return "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Fail";
        //    }
        //}
    }
}
