using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using QRCoder;

namespace PPE_Salons
{
    public class Participant
    {
        public int Id { get; set; }
        public bool QrChecked { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Port { get; set; }
        public bool Save()
        {
            bool success = false;
            if (Id > 0)
                success = UpdateParticipant();
            else success = AddParticipant();
            return success;
        }

        public bool Supprimer()
        {
            try
            {
                DBConnection dbCon = new DBConnection();
                if (Port == "Distant")
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
                    String sqlString = "DELETE FROM participant WHERE Id = ?id_P";
                    sqlString = Tools.PrepareLigne(sqlString, "?id_P", Tools.PrepareChamp(Id.ToString(), "Nombre"));
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.ExecuteNonQuery();
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Erreur: " + ex);
                return false;
            }

        }

        private bool UpdateParticipant()
        {
            try
            {
                DBConnection dbCon = new DBConnection();
                if (Port == "Distant")
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
                    if (QrChecked == true)
                    {
                        String sqlString = "UPDATE participant SET nom = ?nom_P, prenom = ?prenom_P, email = ?email_P, qrcode = ?qr_P WHERE id = ?id_P";
                        sqlString = Tools.PrepareLigne(sqlString, "?id_P", Tools.PrepareChamp(Id.ToString(), "Nombre"));
                        sqlString = Tools.PrepareLigne(sqlString, "?nom_P", Tools.PrepareChamp(Nom, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?prenom_P", Tools.PrepareChamp(Prenom, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?email_P", Tools.PrepareChamp(Email, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?qr_P", Tools.PrepareChamp(Prenom + " " + Nom, "Chaine"));
                        var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                        dbCon.Close();
                        return true;
                    } 
                    else
                    {
                        String sqlString = "UPDATE participant SET nom = ?nom_P, prenom = ?prenom_P, email = ?email_P, qrcode = ?qr_P WHERE id = ?id_P";
                        sqlString = Tools.PrepareLigne(sqlString, "?id_P", Tools.PrepareChamp(Id.ToString(), "Nombre"));
                        sqlString = Tools.PrepareLigne(sqlString, "?nom_P", Tools.PrepareChamp(Nom, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?prenom_P", Tools.PrepareChamp(Prenom, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?email_P", Tools.PrepareChamp(Email, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?qr_P", Tools.PrepareChamp(null, "Chaine"));
                        var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                        dbCon.Close();
                        return true;
                    }
                } else
                {
                    return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }
        }

        private bool AddParticipant()
        {
            try
            {
                // Id = AppelerProcedureStockee();
                DBConnection dbCon = new DBConnection();
                if (Port == "Distant")
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
                    if (QrChecked == true)
                    {
                        String sqlString = "INSERT INTO participant(nom,prenom,email,qrcode) VALUES(?nom_P,?prenom_P,?email_P,?qr_P)";
                        sqlString = Tools.PrepareLigne(sqlString, "?nom_P", Tools.PrepareChamp(Nom, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?prenom_P", Tools.PrepareChamp(Prenom, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?email_P", Tools.PrepareChamp(Email, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?qr_P", Tools.PrepareChamp(Prenom + " " + Nom, "Chaine"));
                        var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                        dbCon.Close();
                        return true;
                    } else
                    {
                        String sqlString = "INSERT INTO participant(nom,prenom,email) VALUES(?nom_P,?prenom_P,?email_P)";
                        sqlString = Tools.PrepareLigne(sqlString, "?nom_P", Tools.PrepareChamp(Nom, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?prenom_P", Tools.PrepareChamp(Prenom, "Chaine"));
                        sqlString = Tools.PrepareLigne(sqlString, "?email_P", Tools.PrepareChamp(Email, "Chaine"));
                        var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                        cmd.ExecuteNonQuery();
                        dbCon.Close();
                        return true;
                    }
                } else
                {
                    return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }

        }

        public string GetQRCode()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            String QRBrut = Prenom + " " + Nom;
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRBrut, QRCodeGenerator.ECCLevel.Q);

            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20);

            StreamWriter monStreamWriter = new StreamWriter(@"C:\Temp\BadgeSalon.html");//Necessite using System.IO;

            String strImage = " <img src = \"data:image/png;base64," + qrCodeImageAsBase64 + "\">";
            monStreamWriter.WriteLine("<html>");
            monStreamWriter.WriteLine("<body>");
            monStreamWriter.Write(Prenom + " ");
            monStreamWriter.WriteLine(Nom);

            monStreamWriter.WriteLine(strImage);    //Ecriture de l'image base 64 dans le fichier
            monStreamWriter.WriteLine("</body>");
            monStreamWriter.WriteLine("</html>");

            // Fermeture du StreamWriter (Très important) 
            monStreamWriter.Close();
            System.Diagnostics.Process.Start("Chrome", @"C:\Temp\BadgeSalon.html");
            MessageBox.Show("Badge généré pour: " + Prenom + " " + Nom);
            return qrCodeImageAsBase64;
        }

        public int AppelerProcedureStockee()
        {
            try
            {
                DBConnection dbCon = new DBConnection();
                if (Port == "Distant")
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
                int Identifiant = -1;
                if (dbCon.IsConnect())
                {
                    String sqlString = "ChercherUtilisateur";
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.CommandType = CommandType.StoredProcedure; //Il faut System.Data pour cette ligne
                    
                    var mdpHash = SHA.MakeMD5Hash("toto");

                    cmd.Parameters.Add("@NomEntree", MySqlDbType.VarChar);
                    cmd.Parameters["@NomEntree"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@NomEntree"].Value = "Toto";
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
                    Identifiant = (int)cmd.Parameters["@IdSortie"].Value;
                    Console.WriteLine(Identifiant);
                    dbCon.Close();
                    return Identifiant + 1;
                }
                dbCon.Close();
                return -1;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Exception found:   " + ex);
                return -1;
            }
        }
    }
}
