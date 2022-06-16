using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using System.IO;

namespace PPE_Salons
{
    public partial class PageParticipant : Form
    {
        Participant LeParticipant;
        public PageParticipant(Participant unParticipant)
        {
            InitializeComponent();
            LeParticipant = unParticipant;
            tbNom.Text = unParticipant.Nom;
            tbPrenom.Text = unParticipant.Prenom;
            tbemail.Text = unParticipant.Email;
        }

        private void PageParticipant_Load(object sender, EventArgs e)
        {
            Error1.Text = "";
            Error2.Text = "";
            Error3.Text = "";
        }

        private void Enregistrer_Click(object sender, EventArgs e)
        {
            Error1.Text = "";
            Error2.Text = "";
            Error3.Text = "";
            bool IsOK = true;
            if (tbNom.Text.Length == 0)
            {
                Error1.Text = "Le Nom ne peut être vide";
                IsOK = false;
            }
            else { LeParticipant.Nom = tbNom.Text; }

            if (tbPrenom.Text.Length == 0)
            {
                Error2.Text = "Le Prénom ne peut être vide";
                IsOK = false;
            }
            else { LeParticipant.Prenom = tbPrenom.Text; }

            if (MesOutils.VeriferMail(tbemail.Text) != true)
            {
                Error3.Text = "email incorrect";
                IsOK = false;
            }
            else { LeParticipant.Email = tbemail.Text; }

            if (qrCheck.Checked == true) { LeParticipant.QrChecked = true; }
            else { LeParticipant.QrChecked = false; }

            if (IsOK == true)
            {
                if (LeParticipant.Save() == true)
                {
                    if (LeParticipant.QrChecked == true)
                    {
                        Error3.Text = "Enregistrement effectué avec le QRcode!";
                        LeParticipant.GetQRCode();
                        this.DialogResult = DialogResult.OK;
                    } else
                    {
                        Error3.Text = "Enregistrement effectué!";
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    Error3.Text = "Erreur d'enregistrement";
                }
            }
        }
    }
}
