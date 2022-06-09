using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace PPE_Salons
{
    public class Contact
    {

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public void Save()
        {
            if (Id > 0)
                UpdateParticipant();
            else AddParticipant();
        }

        public bool Supprimer()
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
                    String sqlString = "DELETE FROM utilisateur WHERE Id = ?id_P";
                    sqlString = Tools.PrepareLigne(sqlString, "?id_P", Tools.PrepareChamp(Id.ToString(), "Nombre"));
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }

        }

        private void UpdateParticipant()
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
                    String sqlString = "UPDATE utilisateur SET nom = ?nom_P,prenom = ?prenom_P,email = ?email_P WHERE id = ?id_P";
                    sqlString = Tools.PrepareLigne(sqlString, "?id_P", Tools.PrepareChamp(Id.ToString(), "Nombre"));
                    sqlString = Tools.PrepareLigne(sqlString, "?nom_P", Tools.PrepareChamp(Nom, "Chaine"));
                    sqlString = Tools.PrepareLigne(sqlString, "?prenom_P", Tools.PrepareChamp(Prenom, "Chaine"));
                    sqlString = Tools.PrepareLigne(sqlString, "?email_P", Tools.PrepareChamp(Email, "Chaine"));
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.ExecuteNonQuery();
                    dbCon.Close();
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }

            private void AddParticipant()
            {
                try
                {
                 Id = AppelerProcedureStockee();
                DBConnection dbCon = new DBConnection();
                dbCon.Server = "127.0.0.1";
                dbCon.DatabaseName = "salon";
                dbCon.UserName = "root";
                dbCon.Password = Crypto.Decrypt("O2Hp8L98TD3dR6vTnWIcIg==");//Pour éviter d'afficher le mot de passe en clair dans le code
                if (dbCon.IsConnect())
                {
                    String sqlString = "INSERT INTO Contact(id,nom,prenom,email) VALUES(?id_P,?nom_P,?prenom_P,?Email_P)";
                    sqlString = Tools.PrepareLigne(sqlString, "?id_P", Tools.PrepareChamp(Id.ToString(), "Nombre"));
                    sqlString = Tools.PrepareLigne(sqlString, "?nom_P", Tools.PrepareChamp(Nom, "Chaine"));
                    sqlString = Tools.PrepareLigne(sqlString, "?prenom_P", Tools.PrepareChamp(Prenom, "Chaine"));
                    sqlString = Tools.PrepareLigne(sqlString, "?Email_P", Tools.PrepareChamp(Email, "Chaine"));
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.ExecuteNonQuery();
                    dbCon.Close();
                }

            }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                
                }

            }

        public int AppelerProcedureStockee()
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
                        sqlString = Tools.PrepareLigne(sqlString, "?nom_P", Tools.PrepareChamp(Nom, "Chaine"));
                        var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                        cmd.CommandType = CommandType.StoredProcedure; //Il faut System.Data pour cette ligne

                        cmd.Parameters.Add("@TheID", MySqlDbType.Int32);
                        cmd.Parameters["@TheID"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        Identifiant = (int)cmd.Parameters["@TheID"].Value;
                        Console.WriteLine(Identifiant);
                        dbCon.Close();
                        return Identifiant + 1;
                    }
                dbCon.Close();
                return -1;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    Console.WriteLine("Exception found:   "+ ex);
                    return -1;
                }
            }

        }
    }
