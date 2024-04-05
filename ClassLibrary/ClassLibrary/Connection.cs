using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Connection
    {
        //(serveur, identifiant, mot de passe, base de données)
        private string serveur;
        private string id;
        private string mdp;
        private string bdd;

        public Connection() { }
        public Connection(string serveur, string id, string mdp, string bdd)
        {
            this.serveur = serveur;
            this.id = id;
            this.mdp = mdp;
            this.bdd = bdd;
        }
        public string get_serveur() { return this.serveur; }
        public string get_id() { return this.id; } 
        public string get_mdp() {  return this.mdp; }
        public string get_bdd() {  return this.bdd; }

        public void set_serveur(string serveur) {  this.serveur = serveur; }
        public void set_id(string id) { this.id = id; }
        public void set_mdp(string mdp) {  this.mdp = mdp; }
        public void set_bdd(string bdd) { this.bdd = bdd; }

        // Methode CRUD 
        public void CREATE()
        {
            string req = "bla;";
            MySqlCommand cmd = new MySqlCommand(req, Global.conn);
            cmd.ExecuteNonQuery();
        }
        public void RETRIEVE(string id)
        {
            string req =""; 
        }
    }
}
