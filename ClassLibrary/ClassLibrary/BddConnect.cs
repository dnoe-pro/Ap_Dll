using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    internal class BddConnect
    {
        public static string driver = "";
        public static MySqlConnection conn = new MySqlConnection(driver);
    }
}
