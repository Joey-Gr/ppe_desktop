using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PPE_Salons
{
    public partial class Login : Form
    {
        public string StrLevel { get; set; }
        public string NomUtilisateur { get; set; }
        public string Mdp { get; set; }
        public int Niveau;
        public int IdUtilisateur;
        public int Counter = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void btnEnr_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection dbCon = new DBConnection();
                dbCon.Server = "127.0.0.1";
                dbCon.DatabaseName = "salon";
                dbCon.UserName = "root";
                dbCon.Password = Crypto.Decrypt("O2Hp8L98TD3dR6vTnWIcIg==");//Pour éviter d'afficher le mot de passe en clair dans le code
                int Identifiant = -1;
                if (dbCon.IsConnect())
                {
                    String sqlString = "ChercherUtilisateur";
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.CommandType = CommandType.StoredProcedure; //Il faut System.Data pour cette ligne

                    var mdpHash = SHA.MakeMD5Hash(tbMdp.Text);

                    cmd.Parameters.Add("@NomEntree", MySqlDbType.VarChar);
                    cmd.Parameters["@NomEntree"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@NomEntree"].Value = tbLogin.Text;
                    cmd.Parameters.Add("@LePass", MySqlDbType.Text);
                    cmd.Parameters["@LePass"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@LePass"].Value = tbMdp.Text;

                    cmd.Parameters.Add("@IdSortie", MySqlDbType.Int32);
                    cmd.Parameters["@IdSortie"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@NivSortie", MySqlDbType.Int32);
                    cmd.Parameters["@NivSortie"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    Identifiant = (int)cmd.Parameters["@IdSortie"].Value;
                    Niveau = (int)cmd.Parameters["@NivSortie"].Value;
                    IdUtilisateur = Identifiant;
                    if (Identifiant > 0)
                    {
                        labelResponse.Text = "Bienvenue";
                        MessageBox.Show("Bienvenue");
                        this.DialogResult = DialogResult.OK;//Modale est validée par OK
                    }

                    else
                    {
                        labelResponse.Text = "Nom ou Mot de passe incorrecte.";
                        MessageBox.Show("Je ne vous connais pas");
                        Counter = Counter + 1;
                        if (Counter >= 5)
                        {
                            this.DialogResult = DialogResult.Cancel;
                        }
                    }
                    dbCon.Close();
                }
                else
                {
                    dbCon.Close();
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Erreur");
            }
        }

        private void btnAnu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ConnectUser(String user)
        {
            DBConnection dbCon = new DBConnection();
            dbCon.Server = "127.0.0.1";
            dbCon.DatabaseName = "salon";
            dbCon.UserName = "root";
            dbCon.Password = Crypto.Decrypt("O2Hp8L98TD3dR6vTnWIcIg==");
            if (dbCon.IsConnect())
            {
                String sqlString = "SELECT id FROM utilisateur WHERE nom = ?nom_P";
                sqlString = Tools.PrepareLigne(sqlString, "?nom_P", Tools.PrepareChamp(user, "Chaine"));
                var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows == true)
                {
                    MessageBox.Show("Bienvenue: " + reader.GetValue(0).ToString());
                    reader.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Erreur login, utilisateur non-existant: " + user);
                    reader.Close();
                    return false;
                }
            }
            else
            {
                Console.WriteLine("erreur de connexion");
                return false;
            }
        }
    }
}
