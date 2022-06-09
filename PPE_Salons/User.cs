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
    public partial class UserLoad : Form
    {
        public UserLoad()
        {
            InitializeComponent();
        }

        private void UserLoad_Load(object sender, EventArgs e)
        {
            var ComboLevelSource = new List<ComboValue>();
            ComboLevelSource.Add(new ComboValue() { Name = "Admin", Value = "1" });
            ComboLevelSource.Add(new ComboValue() { Name = "Utilisateur", Value = "0" });
            comboLevel.DataSource = ComboLevelSource;
            comboLevel.DisplayMember = "Name";
            comboLevel.ValueMember = "Value";
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
                if (dbCon.IsConnect())
                {
                    ComboValue MaComboValue = (ComboValue)comboLevel.SelectedItem;

                    String sqlString = "AjouterUtilisateur";
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.CommandType = CommandType.StoredProcedure; //Il faut System.Data pour cette ligne

                    cmd.Parameters.Add("@NomEntree", MySqlDbType.VarChar);
                    cmd.Parameters["@NomEntree"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@NomEntree"].Value = tbName.Text;
                    cmd.Parameters.Add("@LePass", MySqlDbType.Text);
                    cmd.Parameters["@LePass"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@LePass"].Value = SHA.petitsha(tbMdp.Text);
                    cmd.Parameters.Add("@NivEntree", MySqlDbType.Int32);
                    cmd.Parameters["@NivEntree"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@NivEntree"].Value = MaComboValue.Value;

                    cmd.Parameters.Add("@Ok", MySqlDbType.Int32);
                    cmd.Parameters["@Ok"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    int Ok = (int)cmd.Parameters["@Ok"].Value;
                    if (Ok == 1)
                    {
                        MessageBox.Show("Utilisateur '"+ tbName.Text +"' A bien été inserée dans la base de données");
                        this.DialogResult = DialogResult.OK;//Modale est validée par OK
                    } else
                    {
                        MessageBox.Show("Utilisateur '" + tbName.Text + "' Est déjà existant dans la base de donnée," +
                            "veuiller ajouter un autre nom pour l'utilisateur.");
                    }
                    dbCon.Close();


                    /*
                    String sqlString = "INSERT INTO utilisateur(nom,pass,niveau) VALUES(?nom_P,?mdp_P,?niv_P)";
                    sqlString = Tools.PrepareLigne(sqlString, "?nom_P", Tools.PrepareChamp(tbName.Text, "Chaine"));
                    sqlString = Tools.PrepareLigne(sqlString, "?mdp_P", Tools.PrepareChamp(tbMdp.Text, "Chaine"));
                    sqlString = Tools.PrepareLigne(sqlString, "?niv_P", Tools.PrepareChamp(MaComboValue.Value, "Nombre"));
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    */
                } else
                {
                    dbCon.Close();
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error, exception found: " + ex);
            }
        }
    }
}
