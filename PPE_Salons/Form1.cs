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
    public partial class Form1 : Form
    {
        public int Niveau { get; set; }
        public int IdUtilisateur { get; set; }
        public string NomUtilisateur { get; set; }
        public string PortChoix { get; set; }

        public Form1(int niv, int id, string nom, string port)
        {
            Niveau = niv;
            IdUtilisateur = id;
            NomUtilisateur = nom;
            PortChoix = port;
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeTableau();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in MaGrid.SelectedRows)
            {
                Participant UnParticipant = row.DataBoundItem as Participant;
                UnParticipant.Port = PortChoix;
                PageParticipant MonFormParticipant = new PageParticipant(UnParticipant);
                MonFormParticipant.ShowDialog();
                if (MonFormParticipant.DialogResult == DialogResult.OK)
                {
                    InitializeTableau();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Participant UnParticipant = new Participant();
            UnParticipant.Id = 0;//Pour être sur qu'il soit inséré
            UnParticipant.Port = PortChoix;
            PageParticipant MonFormParticipant = new PageParticipant(UnParticipant);
            MonFormParticipant.ShowDialog();
            if (MonFormParticipant.DialogResult == DialogResult.OK)
            {
                InitializeTableau();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in MaGrid.SelectedRows)
            {
                Participant UnParticipant = row.DataBoundItem as Participant;
                if (UnParticipant.Supprimer()) 
                {
                    MessageBox.Show("Participant Supprimé !");
                    InitializeTableau(); 
                }
                else { MessageBox.Show("Impossible de Supprimer !"); }

            }
        }


        private void FormaterListe()
        {
            MaGrid.Columns["Id"].Visible = false;
            MaGrid.Columns["Port"].Visible = false;
            MaGrid.Columns["Nom"].HeaderText = "Nom du participant";
            MaGrid.Columns["Nom"].Width = 150;
            MaGrid.MultiSelect = false;
            MaGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MaGrid.ReadOnly = true;
        }

        private void InitializeTableau()
        {
            DBConnection dbCon = new DBConnection();
            if (PortChoix == "Distant")
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
                string query = "SELECT id, nom, prenom, email, qrcode FROM participant ORDER BY nom";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();//Remplissage du curseur
                List<Participant> Participants = new List<Participant>();
                while (reader.Read())
                {
                    Participant Participant = new Participant
                    {
                        Id = (int)reader["id"],
                        Nom = (string)reader["nom"],
                        Prenom = (string)reader["prenom"],
                        Email = (string)reader["email"],
                    };
                    if ((string)reader["qrcode"].ToString() != null && (string)reader["qrcode"].ToString() != "")
                    { Participant.QrChecked = true; }
                    else { Participant.QrChecked = false; }
                    Participants.Add(Participant);
                }

                MaGrid.DataSource = null;
                MaGrid.DataSource = Participants;
                FormaterListe();
                reader.Close();
                dbCon.Close();
                MaGrid.Visible = true;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DBConnection dbCon = new DBConnection();
            if (PortChoix == "Distant")
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
                string query = "SELECT id, nom, prenom, email, qrcode FROM participant WHERE nom =?nom_P OR prenom =?nom_P ORDER BY nom";
                query = Tools.PrepareLigne(query, "?nom_P", Tools.PrepareChamp(tbNom.Text, "Chaine"));

                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();//Remplissage du curseur
                List<Participant> Participants = new List<Participant>();
                while (reader.Read())
                {
                    Participant Participant = new Participant
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Prenom = (string)reader["Prenom"],
                        Email = (string)reader["Email"],
                    };
                    if ((string)reader["qrcode"].ToString() != null && (string)reader["qrcode"].ToString() != "") 
                        { Participant.QrChecked = true; }
                    else { Participant.QrChecked = false; }
                    Participants.Add(Participant);
                }

                MaGrid.DataSource = null;
                MaGrid.DataSource = Participants;
                FormaterListe();
                reader.Close();
                dbCon.Close();
                MaGrid.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaGrid.Visible = false;
            if (Niveau == 1)
            {
                btnAdmin.Visible = true;
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            UserLoad AdminForm = new UserLoad();
            AdminForm.ShowDialog();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Participant Participant = new Participant();
            Participant.Nom = NomUtilisateur;
            Participant.Id = IdUtilisateur;
            int id = Participant.AppelerProcedureStockee();
            Console.WriteLine(id);
        }
    }
}