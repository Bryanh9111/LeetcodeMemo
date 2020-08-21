using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace LeetcodeMemoApp_V1.Utility
{
    public static class Helper
    {
        /// <summary>
        /// DealWithCSV
        /// </summary>
        /// <param name="path"></param>
        public static void DealWithCSV(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            try
            {
                if (Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var files = Directory.GetFiles(path);
                foreach(var file in files)
                {
                    var dt = GetXlsxDataTable(file);
                    BulkCopyToServer(dt);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// GetXlsxDataTable
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataTable GetXlsxDataTable(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var ds = reader.AsDataSet();
                    var dt = ds.Tables[0];
                    reader.Close();

                    //remove unuseful rows
                    var rowNumberToRemove = AppSettings.NumberOfRowToRemove;
                    for (int i = 0; i < rowNumberToRemove; i++)
                        dt.Rows.RemoveAt(0);

                    return dt;
                }
            }
        }
        /// <summary>
        /// BulkCopyToServer
        /// </summary>
        /// <param name="dt"></param>
        public static void BulkCopyToServer(DataTable dt)
        {
            try
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString);
                bulkCopy.DestinationTableName = AppSettings.TempTableName;
                bulkCopy.WriteToServer(dt);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
