using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MariaDBCRUD
{
    public class Connexion
    {
        private MySqlConnection _connection;
        private string serveur;
        private string id;
        private string mdp;
        private string bdd;


        public void Connect()
        {
            string pilote = "server=" + this.serveur + "; uid=" + this.id + " ; pwd=" + this.mdp + ";";
            _connection = new MySqlConnection(pilote);
            _connection.Open();     // _connection.Close();
        }

        public Connexion() { }
        public Connexion(string serveur, string id, string mdp, string bdd)
        {
            this.serveur = serveur;
            this.id = id;
            this.mdp = mdp;
            this.bdd = bdd;
        }
        public MySqlConnection get_Connection() { return this._connection; }
        public string get_serveur() { return this.serveur; }
        public string get_id() { return this.id; } 
        public string get_mdp() {  return this.mdp; }
        public string get_bdd() {  return this.bdd; }

        public void set_serveur(string serveur) {  this.serveur = serveur; }
        public void set_id(string id) { this.id = id; }
        public void set_mdp(string mdp) {  this.mdp = mdp; }
        public void set_bdd(string bdd) { this.bdd = bdd; }


      /*  public void create()
        {
            string req = "INSERT INTO connexion values('" + this.serveur + "','" + this.id + "','" + this.mdp + "','" + this.bdd + "');";
            MySqlCommand cmd = new MySqlCommand(req, this._connection);
            cmd.ExecuteNonQuery();
        }*/
        public void retrieve(string id)
        {
            string req = "SELECT * from * where id=" + id;
            MySqlCommand cmd = new MySqlCommand(req, this._connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            this.serveur = rdr["serveur"].ToString();
            this.id = rdr["id"].ToString();
            this.mdp = rdr["mdp"].ToString();
            this.bdd = rdr["bdd"].ToString();
        }

        // Methode
        // 


    }
}
