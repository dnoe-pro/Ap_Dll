using MariaDBCRUD;
using MySql.Data.MySqlClient;




try
{
    MySqlConnection Connect = new MySqlConnection();
    Connect.Open();

    
    Console.WriteLine("==========================");
    Console.ReadLine();


}
catch (Exception e)
{
    Console.WriteLine("Erreur", e);
}



