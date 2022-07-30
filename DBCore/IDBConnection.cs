using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DBCore
{
    public  interface IDBConnection
    {
        Task<string> IUD(string QUERY, Hashtable PARAM, string ServerId = "");
        Task<DataTable> SELECT_QUERY(string QUERY, Hashtable PARAM, string ServerId = "");
        Task<string> CreateBackupDB();
    }
}
