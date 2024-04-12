using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaDBCRUD
{
    internal class Global
    {
        public static string pilote = "server=127.0.0.1; uid=root ; pwd=caribou;";
        public static MySqlConnection conn = new MySqlConnection(pilote);
    }
}