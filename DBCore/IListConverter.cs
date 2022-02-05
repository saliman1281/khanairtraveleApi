using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DBCore
{
   public interface IListConverter
    {
        List<T> ConvertDataTable<T>(DataTable dt);
        T GetItem<T>(DataRow dr);
        T GetItem1<T>(DataRow dr);
    }
}
