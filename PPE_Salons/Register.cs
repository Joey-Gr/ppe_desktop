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
    public partial class Register : Form
    {
        public string NomUtilisateur { get; set; }
        public Register()
        {
            InitializeComponent();
        }

        private void btnEnr_Click(object sender, EventArgs e)
        {
            try
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

                    String sqlString = "AjouterUtilisateur";
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.CommandType = CommandType.StoredProcedure; //Il faut System.Data pour cette ligne

                    var mdpHash = SHA.MakeMD5Hash(tbMdp.Text);

                    cmd.Parameters.Add("@NomEntree", MySqlDbType.VarChar);
                    cmd.Parameters["@NomEntree"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@NomEntree"].Value = tbName.Text;
                    cmd.Parameters.Add("@LePass", MySqlDbType.Text);
                    cmd.Parameters["@LePass"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@LePass"].Value = mdpHash;
                    cmd.Parameters.Add("@NivEntree", MySqlDbType.Int32);
                    cmd.Parameters["@NivEntree"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@NivEntree"].Value = 0;
                    cmd.Parameters.Add("@ActifEntree", MySqlDbType.Int32);
                    cmd.Parameters["@ActifEntree"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@ActifEntree"].Value = 1;

                    cmd.Parameters.Add("@Ok", MySqlDbType.Int32);
                    cmd.Parameters["@Ok"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    int Ok = (int)cmd.Parameters["@Ok"].Value;
                    if (Ok == 1)
                    {
                        MessageBox.Show("Utilisateur '" + tbName.Text + "' A bien été inserée dans la base de données");
                        NomUtilisateur = tbName.Text;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Un utilisateur portant le même nom existe déjà. " +
                            "veuiller ajouter un autre nom pour l'utilisateur.");
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
                MessageBox.Show("Erreur: " + ex);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            NomUtilisateur = tbName.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            var ComboPort = new List<ComboValue>();
            ComboPort.Add(new ComboValue() { Name = "Locale", Value = "0" });
            ComboPort.Add(new ComboValue() { Name = "Distant", Value = "1" });
            portChoix.DataSource = ComboPort;
            portChoix.DisplayMember = "Name";
            portChoix.ValueMember = "Value";
        }
    }
}
