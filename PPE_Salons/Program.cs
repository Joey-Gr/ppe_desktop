using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace PPE_Salons
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// Mot de passe haché en quoi?
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login MonFormLogin = new Login();
            MonFormLogin.ShowDialog();
            if (MonFormLogin.DialogResult == DialogResult.OK)
            {
                String LeNomUtilisateur = MonFormLogin.NomUtilisateur;
                String MdpUtilisateur = MonFormLogin.Mdp;

                int NiveauUtilisateur = MonFormLogin.Niveau;
                int IdNomUtilisateur = MonFormLogin.IdUtilisateur;
                string NomUtilisateur = MonFormLogin.NomUtilisateur;
                string PortChoix = MonFormLogin.PortChoix;

                MonFormLogin.Close();
                Application.Run(new Form1(NiveauUtilisateur, IdNomUtilisateur, NomUtilisateur, PortChoix));
            }
            else
            {
                MonFormLogin.Close();
                MessageBox.Show("Au revoir");
            }

            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
        }


        /*
        static int checkUserLevel(String nom)
        {
            DBConnection dbCon = new DBConnection();
            dbCon.Server = "ppebelletablecerfal.chaisgxhr4z6.eu-west-3.rds.amazonaws.com";
            dbCon.DatabaseName = "PPE_Joey";
            dbCon.UserName = "admin";
            dbCon.Password = Crypto.Encrypt("renard2020");

            Login MonFormLogin = new Login();

            if (dbCon.IsConnect())
            {
                String sqlString = "SELECT niveau FROM utilisateur WHERE nom = ?nom_p";
                sqlString = Tools.PrepareLigne(sqlString, "?nom_p", Tools.PrepareChamp(nom, "Chaine"));
                var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                reader.Read();
                int niv = (int)reader["niveau"];
                reader.Close();
                Console.WriteLine(niv);
                return niv;
            }
            else
            {
                Console.WriteLine("erreur de connexion");
                return -1;
            }
        }
        */
    }
}
