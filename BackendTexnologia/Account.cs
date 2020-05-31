using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class Account
    {
        private bool upgraded;
        private DateTime dateOfUpgrade;
        private double price;

        //Tha uparxei allo ena table to opoio opoio tha onomazetai accounts. Mesa tha exei accountID(primary key) userID(foreign key), upgraded, student dateOfUpgrade, dateOfExpiration
        public bool checkForUpgradedAccount(int userID)// bazoume bool giati auti i methodos tha epistrefei true i false an exei Upgraded Account
        {
            //endeiktikes entoles gia to pws tha mporouse na ginei enas elegxos sti vasi na exei ginei upgrade to account
            bool check = false;

            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
                cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                           //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
                string sql = "Select upgraded from accounts userID='" + userID + "' ";//einai ena aplo string pou tha xrisimopoithei ws query
                MySqlCommand command = new MySqlCommand(sql, cnn);//arxikopoioume to command pou xrisimopoiei ti vilviothiki MySqlCommand i opoia exei 2 orismata
                MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql
                bool checkupgraded = dataReader[0];
                if (checkupgraded == true)
                {
                    check = true;

                }
            }
            catch
            {
                return check;
            }
            return check;
        }
        public bool saveUpgrade(int userID, DateTime dateOfUpgrade, string studentCode, double price)
        {
            //Tha uparxei allo ena table to opoio opoio tha onomazetai Accounts. Mesa tha exei accountID(primary key) userID(foreign key), Upgraded (true i false), StudentCode, DateOfUpgrade, dateOfExpiration
            //me vasi to userID tou xristi tha kanoume insert sto table accounts


            //gia na proxwrisoume se apothikeusi tha prepei na xeroume an exei plirwsei o xristis
            //mesw tis pay 
            //estw oti exei ginei plirwmi. Auto tha mporouse na simainei oti i trapeza tha mas steilei pisw mia metavliti me ena true ii false
            //an einai true exei ginei i plirwmi, an einai false den exei ginei
            //epomenws aspoume oti exoume mia metavliti paymentcheck
            //kai me vasi auti ti metabliti mporoume na sunexisoume
            //kaloume tin checkForUpgradedAccount gia na paroume tin timi tou check

            bool upgradedcheck = false;
            Account up = new Account();
            upgradedcheck = up.checkForUpgradedAccount(userID);

            bool checksavedUpgrade = false;
            if (upgradedcheck == false)
            {
                bool paymentcheck = false;
                Account ac = new Account();
                paymentcheck = ac.pay(userID, price);
                

                if (paymentcheck = true)
                {
                    try
                    {
                        MySqlConnection cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sql = "INSERT INTO Accounts (userID, Upgraded, StudentCode, DateOfUpgrade) VALUES('" + userID + "','" + true + "', '" + studentCode + "', '" + dateOfUpgrade + "'";
                        MySqlCommand command = new MySqlCommand(sql, cnn);
                        command.ExecuteCommand();
                        cnn.Close();
                        checksavedUpgrade = true;
                        return checksavedUpgrade;
                        //an den upirxe provlima sti vasi epistrefei true
                        //alliws pigenei sto catch kai epistrefei tin arxikopoiimeni timi false
                    }
                    catch
                    {
                        return checksavedUpgrade;
                    }
                }
                else
                {
                    return checksavedUpgrade;
                }
            }
            else 
            {
                return checksavedUpgrade;
            }
        }

        public bool pay(int userID, double FinalPrice)//otan o xristis epilexei na plirwsei tha ton stelnei sto exwteriko sustima tis trapezas
        {
            bool paymentcheck = false;
            //arxikopoioume tin paymentcheck
            //se auto to simeio tha epikoinwnei to europemoov me to sustima tis trapezas 
            //kai an exei ginei i plirwmi stin trapeza tha apothikeuetai se mia metavliti paymentcheck=true; iii paymentcheck=false; an den exei ginei


            return paymentcheck;
        }



    }
}




