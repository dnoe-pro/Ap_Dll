using MySql.Data.MySqlClient;

namespace MariaDBCRUD
{
    public class Requete
    {
        public static void Main()
        {
            Console.WriteLine("test");
        }

        //-------------------
        // Database
        //-------------------

        // Retrieve/récuperation database
        private static List<string> Get_AllDatabases(Connexion connexion)
        {
            List<string> databases = new List<string>();
            string query = "SELECT schema_name AS database FROM information_schema.schemata";
            using (MySqlCommand cmd = new MySqlCommand(query, connexion.get_Connection()))
            {
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        databases.Add(rdr["database"].ToString());
                    }
                }
            }
            return databases;
        }
        // Select database (ne marche pas tres bien) 
        private static List<Dictionary<string, object>> SelectDatabase(string query, Connexion connexion)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            using (MySqlCommand cmd = new MySqlCommand(query, connexion.get_Connection()))
            {
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            
                            row.Add(rdr.GetName(i), rdr.GetValue(i));
                        }
                        results.Add(row);
                    }
                }
            }
            return results;
        }
        //-------------------
        // Table
        //-------------------

        // Retrieve all tables 
        private static List<string> Get_AllTables(string databaseName, Connexion connexion)
        {
            List<string> tables = new List<string>();
            string query = "SELECT table_name AS tables FROM information_schema.tables WHERE table_schema = @dbName";
            using (MySqlCommand cmd = new MySqlCommand(query, connexion.get_Connection()))
            {
                cmd.Parameters.AddWithValue("@dbName", databaseName);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        tables.Add(rdr["tables"].ToString());
                    }
                }
            }
            return tables;
        }
        // select table
        private static List<Dictionary<string, object>> SelectTable(string databaseName, string query, Connexion connexion)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            using (MySqlCommand cmd = new MySqlCommand(query, connexion.get_Connection()))
            {
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            row.Add(rdr.GetName(i), rdr.GetValue(i));
                        }
                        results.Add(row);
                    }
                }
            }
            return results;
        }

        // Insert table 
        private static void InsertTable(string tableName, Dictionary<string, object> data, Connexion connexion)
        {
            string columns = string.Join(", ", data.Keys);
            string values = string.Join(", ", data.Values);
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
            using (MySqlCommand cmd = new MySqlCommand(query, connexion.get_Connection()))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // Update table 
        private static void UpdateTable(string tableName, Dictionary<string, object> newData, string condition, Connexion connexion)
        {
            List<string> updateList = new List<string>();
            foreach (var kvp in newData)
            {
                updateList.Add($"{kvp.Key} = '{kvp.Value}'");
            }
            string updates = string.Join(", ", updateList);
            string query = $"UPDATE {tableName} SET {updates} WHERE {condition}";
            using (MySqlCommand cmd = new MySqlCommand(query, connexion.get_Connection()))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // Delete table
        private static void DeleteTable(string tableName, string condition, Connexion connexion)
        {
            string query = $"DELETE FROM {tableName} WHERE {condition}";
            using (MySqlCommand cmd = new MySqlCommand(query, connexion.get_Connection()))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}