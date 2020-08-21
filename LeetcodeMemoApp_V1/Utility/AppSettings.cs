using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeMemoApp_V1.Utility
{
    public class AppSettings
    {
        private AppSettings() { }
        public static int NumberOfRowToRemove { get { return Convert.ToInt32(ConfigurationManager.AppSettings["numberOfRowToRemove"]); } }
        public static string TempTableName { get { return ConfigurationManager.AppSettings["tempTableName"]; } }
        public static string FolderLoction { get { return ConfigurationManager.AppSettings["folderLoction"]; } }
    }
}
