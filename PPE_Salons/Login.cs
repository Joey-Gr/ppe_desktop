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
        public string PortChoix { get; set; }
        public int Niveau { get; set; }
        public int IdUtilisateur { get; set; }

        public int Counter = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void btnEnr_Click(object sender, EventArgs e)
        {
            try
            {
                int Identifiant = -1;
                DBConnection dbCon = new DBConnection();
                ComboValue ComboActive = (ComboValue)portChoix.SelectedItem;
                if (ComboActive.Value == "1")
                {
                    dbCon.Server = "ppebelletablecerfal.chaisgxhr4z6.eu-west-3.rds.amazonaws.com";
                    dbCon.DatabaseName = "PPE_Joey";
                    dbCon.UserName = "admin";
                    dbCon.Password = Crypto.Decrypt("tr9y0URXywxHt1XgTEn4yg==");
                }
                else
                {
                    dbCon.Server = "127.0.0.1";
                    dbCon.DatabaseName = "salon";
                    dbCon.UserName = "root";
                    dbCon.Password = Crypto.Decrypt("O2Hp8L98TD3dR6vTnWIcIg==");
                }
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
                    cmd.Parameters["@LePass"].Value = mdpHash;

                    cmd.Parameters.Add("@IdSortie", MySqlDbType.Int32);
                    cmd.Parameters["@IdSortie"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@NivSortie", MySqlDbType.Int32);
                    cmd.Parameters["@NivSortie"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@ActifSortie", MySqlDbType.Int32);
                    cmd.Parameters["@ActifSortie"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@NbConsSortie", MySqlDbType.Int32);
                    cmd.Parameters["@NbConsSortie"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@PassSortie", MySqlDbType.Text);
                    cmd.Parameters["@PassSortie"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    if ((int)cmd.Parameters["@IdSortie"].Value != -1)
                    {

                        Identifiant = (int)cmd.Parameters["@IdSortie"].Value;
                        Niveau = (int)cmd.Parameters["@NivSortie"].Value;
                        NomUtilisateur = tbLogin.Text;
                        IdUtilisateur = Identifiant;
                        PortChoix = ComboActive.Name;
                        var actifSortie = (int)cmd.Parameters["@ActifSortie"].Value;
                        var nbConSortie = (int)cmd.Parameters["@NbConsSortie"].Value;
                        var mdpSortie = (string)cmd.Parameters["@PassSortie"].Value;
                        if (Identifiant > 0 && mdpHash == mdpSortie)
                        {
                            if (actifSortie == 1)
                            {
                                labelResponse.Text = "Connexion reussi";
                                nbConSortie = nbConSortie + 1;
                                String insertIncrement = "UPDATE utilisateur SET nbCons = ?nbCons_P WHERE id = ?int_P";
                                insertIncrement = Tools.PrepareLigne(insertIncrement, "?nbCons_P", Tools.PrepareChamp(nbConSortie.ToString(), "Nombre"));
                                insertIncrement = Tools.PrepareLigne(insertIncrement, "?int_P", Tools.PrepareChamp(Identifiant.ToString(), "Nombre"));
                                var insertIncr = new MySqlCommand(insertIncrement, dbCon.Connection);
                                insertIncr.ExecuteNonQuery();
                                MessageBox.Show("Bienvenue");
                                this.DialogResult = DialogResult.OK;//Modale est validée par OK
                            } else
                            {
                                labelResponse.Text = "Connexion utilisateur non actif";
                                MessageBox.Show("L'utilisateur est existant mais il n'est pas encore actif");
                            }
                        }
                        else
                        {
                            labelResponse.Text = "Erreur de connexion.";
                        }
                        dbCon.Close();
                    } else
                    {
                        labelResponse.Text = "Nom d'utilisateur ou mot de passe incorrect";
                        labelResponse.Visible = true;
                        Counter = Counter + 1;
                        if (Counter >= 5)
                        {
                            this.DialogResult = DialogResult.Cancel;
                        }
                        dbCon.Close();
                    }
                }
                else
                {
                    dbCon.Close();
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Erreur: "+ ex);
            }
        }

        private void btnAnu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        // Fonction remplacée par procédure stoquée
        private bool ConnectUser(String user)
        {
            DBConnection dbCon = new DBConnection();
            ComboValue ComboActive = (ComboValue)portChoix.SelectedItem;
            if (ComboActive.Value == "1")
            {
                dbCon.Server = "ppebelletablecerfal.chaisgxhr4z6.eu-west-3.rds.amazonaws.com";
                dbCon.DatabaseName = "PPE_Joey";
                dbCon.UserName = "admin";
                dbCon.Password = Crypto.Decrypt("tr9y0URXywxHt1XgTEn4yg==");
            }
            else
            {
                dbCon.Server = "127.0.0.1";
                dbCon.DatabaseName = "salon";
                dbCon.UserName = "root";
                dbCon.Password = Crypto.Decrypt("O2Hp8L98TD3dR6vTnWIcIg==");
            }
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

        private void portChoix_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            var ComboPort = new List<ComboValue>();
            ComboPort.Add(new ComboValue() { Name = "Locale", Value = "0" });
            ComboPort.Add(new ComboValue() { Name = "Distant", Value = "1" });
            portChoix.DataSource = ComboPort;
            portChoix.DisplayMember = "Name";
            portChoix.ValueMember = "Value";
        }

        private void btnInscr_Click(object sender, EventArgs e)
        {
            Register MonFormRegister = new Register();
            MonFormRegister.ShowDialog();
            if (MonFormRegister.DialogResult == DialogResult.OK)
            {
                if (MonFormRegister.NomUtilisateur != null)
                {
                    tbLogin.Text = MonFormRegister.NomUtilisateur;
                    MonFormRegister.Close();
                } else
                {
                    MonFormRegister.Close();
                }
            }
        }
    }
}
