using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Global
    {
        public static string pilote = "server=127.0.0.1; uid=root ; pwd=caribou; database=sio ";
        public static MySqlConnection conn = new MySqlConnection(pilote);
    }
}
