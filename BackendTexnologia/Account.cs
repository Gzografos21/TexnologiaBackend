using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class Account
    {
        private bool upgraded;
        private string dateOfUpgrade;
        private string dateOfExpiration;
        private double price;

        public bool checkForUpgradedAccount()// bazoume bool giati logika auti i methodos tha epistrefei true i false an exei Upgraded Account
        {
            //endeiktikes entoles gia to pws tha mporouse na ginei enas elegxos sti vasi na exei ginei upgrade to account
            bool check = false;
            try
            {
                string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=leafletdb"; 
                MySqlConnection cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sql = "Select name from users where username='" + InsertedName + "'";
                MySqlCommand command = new MySqlCommand(sql, cnn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader[0].ToString() == InsertUserName)
                    {
                        check = true;
                    }
                }
            }

            catch
            {
                check = true;
            }
            return check;

        }

        public bool saveUpgrade()
        {
           //otan tha kanei anabathmisi logariasmou apothikeuei tin anabathmisi
        }

        public static void pay()
        {
            //otan thelei na plirwsei ton pigenei sto exwteriko sustima tis trapezas 
        }

    }

}


