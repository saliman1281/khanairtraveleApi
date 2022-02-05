using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace DBCore
{
    public class ListConverter : IListConverter
    {
        public List<T> ConvertDataTable<T>(DataTable dt)
        {
            try
            {
                List<T> data = new List<T>();
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem1<T>(row);
                    data.Add(item);
                }
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public T GetItem<T>(DataRow dr)
        {
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)
                            pro.SetValue(obj, dr[column.ColumnName].ToString(), null);
                        else
                            continue;
                    }
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public T GetItem1<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
