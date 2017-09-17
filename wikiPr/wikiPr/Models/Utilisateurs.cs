using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace wikiPr.Models {

    public class Utilisateurs {

        public static bool Add(Utilisateur u) { //bool
                                                //using (SqlConnection connexion = new SqlConnection(ConnectionString)) {
                                                //    connexion.Open();

            //    //Création d'une commande
            //    SqlCommand commande = new SqlCommand("AddUtilisateur", connexion);
            //    commande.CommandType = CommandType.StoredProcedure;
            //    commande.Parameters.Add("mdp", SqlDbType.NVarChar).SqlValue = u.MDP;
            //    commande.Parameters.Add("prenom", SqlDbType.NVarChar).SqlValue = u.Prenom;
            //    commande.Parameters.Add("nomFamille", SqlDbType.NVarChar).SqlValue = u.NomFamille;
            //    commande.Parameters.Add("courriel", SqlDbType.NVarChar).SqlValue = u.Courriel;
            //    commande.Parameters.Add("langue", SqlDbType.NVarChar).SqlValue = u.Langue;

            //    try {
            //        u.Id = Convert.ToInt32(commande.ExecuteScalar());
            //    }
            //    catch (Exception e) {
            //        throw new Exception("Erreur d'ajout", e);
            //    }
            //}

            //////////////

            bool TEST = true;
            byte[] hashPassword = new UTF8Encoding().GetBytes(u.MDP);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hashPassword);
            string hashString = BitConverter.ToString(hash);

            string chConnexion = ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
            string requete = //"INSERT INTO Utilisateurs (Nom, Courriel, Mot) VALUES ('" + u.Nom + "', '" + u.Courriel + "', '" + hashString + "')";
           "INSERT INTO Utilisateurs(MDP, Prenom, NomFamille, Courriel, Langue) VALUES ('" + hashString + "', '" + u.Prenom + "', '" + u.NomFamille +
           "', '" + u.Courriel + "', '" + u.Langue + "')";
            SqlConnection connexion = new SqlConnection(chConnexion);
            SqlCommand commande = new SqlCommand(requete, connexion);
            commande.CommandType = System.Data.CommandType.Text;
            try {
                connexion.Open();
                commande.ExecuteNonQuery();
            }
            catch (Exception e) {
                string msg = e.Message;
                TEST = false;
            }
            finally {
                connexion.Close();
            }
            return TEST;
        }

        public static bool Update(Utilisateur u) {
            using (SqlConnection connexion = new SqlConnection(ConnectionString)) {
                //byte[] hashPassword = new UTF8Encoding().GetBytes(u.MDP);
                //byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hashPassword);
                //string hashString = BitConverter.ToString(hash);

                string requete = "UPDATE Utilisateurs SET Prenom = '" + u.Prenom + "', NomFamille = '" 
                    + u.NomFamille + "', Langue = '" + u.Langue + "' WHERE Courriel = '" + u.Courriel + "'"; 

                SqlCommand cmd = new SqlCommand(requete, connexion);
                cmd.CommandType = System.Data.CommandType.Text;
                try {
                    connexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception e) {
                    string Message = e.Message;
                    return false;
                }
                finally {
                    connexion.Close();
                }

            }
        }

        public static bool update(Utilisateur u) {
            using (SqlConnection connexion = new SqlConnection(ConnectionString)) {
                byte[] hashPassword = new UTF8Encoding().GetBytes(u.MDP);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hashPassword);
                string hashString = BitConverter.ToString(hash);

                string requete = "UPDATE Utilisateurs SET MDP = '" + hashString + "' WHERE Courriel = '" + u.Courriel + "'";

                SqlCommand cmd = new SqlCommand(requete, connexion);
                cmd.CommandType = System.Data.CommandType.Text;
                try {
                    connexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception e) {
                    string Message = e.Message;
                    return false;
                }
                finally {
                    connexion.Close();
                }

            }
        }

        //Création d'une commande
        //SqlCommand commande = new SqlCommand("UpdateUtilisateur", connexion);
        //commande.CommandType = CommandType.StoredProcedure;
        //commande.Parameters.Add("prenom", SqlDbType.NVarChar).SqlValue = u.Prenom;
        //commande.Parameters.Add("nomFamille", SqlDbType.NVarChar).SqlValue = u.NomFamille;
        ////  commande.Parameters.Add("courriel", SqlDbType.NVarChar).SqlValue = u.Courriel;
        //commande.Parameters.Add("langue", SqlDbType.NVarChar).SqlValue = u.Langue;

        //    try {
        //        commande.ExecuteNonQuery();
        //    }
        //    catch (Exception e) {
        //        throw new Exception("Erreur de modification", e);
        //    }
        //}
        // }



        //public static void Update(string courriel, string ancienMdP, string nouveauMdP) {
        //    using (SqlConnection connexion = new SqlConnection(ConnectionString)) {
        //        connexion.Open();

        //        //Création d'une commande
        //        SqlCommand commande = new SqlCommand("UpdateMotDePasse", connexion);
        //        commande.CommandType = CommandType.StoredProcedure;
        //        commande.Parameters.Add("courriel", SqlDbType.NVarChar).SqlValue = courriel;
        //        commande.Parameters.Add("ancienMdp", SqlDbType.NVarChar).SqlValue = ancienMdP;
        //        commande.Parameters.Add("nouveauMdp", SqlDbType.NVarChar).SqlValue = nouveauMdP;

        //        try {
        //            if (commande.ExecuteNonQuery() != 1)
        //                throw new Exception("Erreur de modification");
        //        }
        //        catch (Exception e) {
        //            throw new Exception("Erreur de modification", e);
        //        }
        //    }
        //}

        public void Remove(int id) {
            using (SqlConnection connexion = new SqlConnection(ConnectionString)) {
                connexion.Open();

                //Création d'une commande
                SqlCommand commande = new SqlCommand("DeleteUtilisateur", connexion);
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("Id", SqlDbType.Int).SqlValue = id;

                try {
                    commande.ExecuteNonQuery();
                }
                catch (Exception e) {
                    throw new Exception("Erreur de suppression", e);
                }
            }

        }

        /*

        string chConnexion = ConfigurationManager.ConnectionStrings["maCon"].ConnectionString;
                    SqlConnection connexion = new SqlConnection(chConnexion);
                    string requete = "SELECT * FROM Commentaire WHERE idCommentaire = " + id;
                    SqlCommand commande = new SqlCommand(requete, connexion);
                    commande.CommandType = System.Data.CommandType.Text;
                    try
                    {
                        connexion.Open();
                        SqlDataReader dr = commande.ExecuteReader();
                        dr.Read();
                        Commentaire c = new Commentaire
                        {
                            idCommentaire = (int)dr["idCommentaire"],
                            auteur = (string)dr["auteur"],
                            idArt = (int)dr["idArt"],
                            datePublication = (DateTime)dr["datePublication"],
                            contenu = (string)dr["contenu"]
                        };

                        return c;
                    }
                    catch (Exception e)
                    {
                        string Message = e.Message;
                    }
                    finally
                    {
                        connexion.Close();
                    }
                    return null;
                }

        */


        public static Utilisateur FindByCourriel(string courriel) {
            //Utilisateur u = null;
            //using (SqlConnection connexion = new SqlConnection(ConnectionString)) {
            //    connexion.Open();

            //    //Création d'une commande
            //    SqlCommand commande = new SqlCommand("FindUtilisateurByCourriel", connexion);
            //    commande.CommandType = CommandType.StoredProcedure;
            //    commande.Parameters.Add("Courriel", SqlDbType.NVarChar).SqlValue = courriel;

            //    //Traitement du DataReader
            //    SqlDataReader dr = commande.ExecuteReader();
            //    dr.Read();
            //    u = ExtraireUtilisateur(dr);
            //    dr.Close();
            //}

            //return u;


            ///////

            string chConnexion = ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
            SqlConnection connexion = new SqlConnection(chConnexion);
            string requete = "SELECT * FROM Utilisateurs WHERE Courriel = '" + courriel + "';";
            SqlCommand commande = new SqlCommand(requete, connexion);
            commande.CommandType = System.Data.CommandType.Text;
            try {
                connexion.Open();
                SqlDataReader dr = commande.ExecuteReader();
                dr.Read();
                Utilisateur u = new Utilisateur {
                    Id = (int)dr["Id"],
                    Prenom = (string)dr["Prenom"],
                    NomFamille = (string)dr["NomFamille"],
                    Courriel = (string)dr["Courriel"],
                    MDP = (string)dr["MDP"],
                    Langue = (string)dr["Langue"]
                };

                return u;
            }
            catch (Exception e) {
                string Message = e.Message;
            }
            finally {
                connexion.Close();
            }
            return null;
        }


      public Utilisateur FindById(int id) {
        Utilisateur u = null;
        using (SqlConnection connexion = new SqlConnection(ConnectionString)) {
            connexion.Open();

            //Création d'une commande
            SqlCommand commande = new SqlCommand("FindUtilisateurById", connexion);
            commande.CommandType = CommandType.StoredProcedure;
            commande.Parameters.Add("Id", SqlDbType.Int).SqlValue = id;

            //Traitement du DataReader
            SqlDataReader dr = commande.ExecuteReader();
            dr.Read();
            u = ExtraireUtilisateur(dr);
            dr.Close();
        }

        return u;
    }

    private static Utilisateur ExtraireUtilisateur(IDataReader dr) {//     IDataReader    SqlDataReader
        Utilisateur u = new Utilisateur();
        u.Id = (int)dr["Id"];
        u.Courriel = (string)dr["Courriel"];
        u.MDP = (string)dr["MDP"];
        u.NomFamille = (string)dr["NomFamille"];
        u.Prenom = (string)dr["Prenom"];
        u.Courriel = (string)dr["courriel"];
        u.Langue = (string)dr["Langue"];
        return u;
    }

        //now
        public static bool Authentifie(string login, string passwd) {
            //using (SqlConnection cnx = new SqlConnection(ConnectionString)) {
            string cStr = ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
            using (SqlConnection cnx = new SqlConnection(cStr)) {
                string requete = "SELECT * FROM Utilisateurs WHERE Courriel = '" + login + "'";

                SqlCommand cmd = new SqlCommand(requete, cnx);
                cmd.CommandType = System.Data.CommandType.Text;
                try {
                    cnx.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (!dataReader.HasRows) {
                        dataReader.Close();
                        return false;
                    }
                    dataReader.Read();
                   //  string p = (string)dataReader["MDP"];
                    var encodedPasswordOnServer = (string)dataReader["MDP"];

                    byte[] encodedPassword = new UTF8Encoding().GetBytes(passwd);
                    byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                    string encodedPasswordSentToForm = BitConverter.ToString(hash);

                    dataReader.Close();
                    return encodedPasswordSentToForm.Trim() == encodedPasswordOnServer.Trim();
                   // return passwd.Trim() == p.Trim();
                }

                catch (Exception e) {
                    // string msg = e.Message;
                    return false;
                }

                finally {
                    cnx.Close();
                }
            }
        }


        //public static bool Authentifie(string login, string passwd) {
        //    string cStr =
        //   ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
        //    using (SqlConnection cnx = new SqlConnection(cStr)) {
        //        string requete = "SELECT * FROM Utilisateurs WHERE Courriel = '" +
        //       login + "'";
        //        SqlCommand cmd = new SqlCommand(requete, cnx);
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        try {
        //            cnx.Open();
        //            SqlDataReader dataReader = cmd.ExecuteReader();
        //            if (!dataReader.HasRows) {
        //                dataReader.Close();

        //             return false;
        //            }
        //            dataReader.Read();
        //            var encodedPasswordOnServer = (string)dataReader["MDP"];
        //            byte[] encodedPassword = new UTF8Encoding().GetBytes(passwd);
        //            byte[] hash =
        //           ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
        //            string encodedPasswordSentToForm =
        //           BitConverter.ToString(hash);
        //            dataReader.Close();
        //            //return encodedPasswordSentToForm ==
        //            //encodedPasswordOnServer.Trim();
        //            return passwd.Trim() == encodedPasswordOnServer.Trim();
        //        }
        //        finally {
        //            cnx.Close();
        //        }
        //    }
        //}

        //public static bool Authentifie(string login, string passwd) {
        //    string cStr = ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
        //    using (SqlConnection cnx = new SqlConnection(cStr)) {
        //        string requete = "SELECT * FROM Utilisateurs WHERE Courriel = '" + login + "'";

        //        SqlCommand cmd = new SqlCommand(requete, cnx);
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        try {
        //            cnx.Open();
        //            SqlDataReader dataReader = cmd.ExecuteReader();
        //            if (!dataReader.HasRows) {
        //                dataReader.Close();
        //                return false;
        //            }
        //            dataReader.Read();
        //            var encodedPasswordOnServer = (string)dataReader["MDP"];
        //            //byte[] encodedPassword = new UTF8Encoding().GetBytes(passwd);
        //            //byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
        //            //string encodedPasswordSentToForm = BitConverter.ToString(hash);
        //            dataReader.Close();
        //            //return encodedPasswordSentToForm == encodedPasswordOnServer.Trim();
        //            return encodedPasswordOnServer == passwd;
        //        }

        //        catch (Exception e) {
        //            string msg = e.Message;
        //            return false;
        //        }

        //        finally {
        //            cnx.Close();
        //        }
        //    }
        //}

        //public static bool Authentifie(string username, string password) {
        //    string chConnexion = ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
        //    SqlConnection connexion = new SqlConnection(chConnexion);
        //    string requete = "SELECT * FROM [Utilisateurs] WHERE Courriel = " + username; // + "'";
        //    SqlCommand commande = new SqlCommand(requete, connexion);
        //    commande.CommandType = System.Data.CommandType.Text;
        //    try {
        //        connexion.Open();
        //        SqlDataReader dr = commande.ExecuteReader();
        //        if (!dr.HasRows) {
        //            dr.Close();
        //            return false;
        //        }
        //        dr.Read();
        //        var passwd = (string)dr["MDP"];
        //        byte[] hashPassword = new UTF8Encoding().GetBytes(password);

        //    byte[] hash =
        //    ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hashPassword);

        //        string hashString = BitConverter.ToString(hash);
        //        dr.Close();
        //        return hashString == passwd;
        //    }
        //    finally {
        //        connexion.Close();
        //    }
        //}

        private static string ConnectionString {
        get { return ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString; }
    }
}
}
    
