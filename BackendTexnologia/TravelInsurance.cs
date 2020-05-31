using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace BackendTexnologia
{
    string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=TexnologiaVasi";
    public class TravelInsurance
    {
        private string insuranceType;
        private double price;
        //se auto to simeio theloum ena paroume kai to sugekrimeno id tis kratisis stin opoia prosthetoume tin taxidiwtiki asfalisi

        public bool saveTravelInsurance(int userID, string insuranceType, double price, int reservationID)
        {
            //an einai basic (upgraded = false) tha tou emfanizei duo epiloges
            //eite na plirwsei kapoia extra xrimata
            //eite na kanei anabathmisi tou logariasmou tou

            //ara vazoume tin epilogi tou xristi se mia metabliti
            bool checksavedTravelInsurance = false;
            string choice;
            if (choice == "Extra Pay")
            {
                bool paymentcheck = false;
                TravelInsurance ti = new TravelInsurance();

                paymentcheck = ti.pay(userID, price);

                if (paymentcheck == true)
                {
                    //exoume ena upothetiko table TravelInsurancespou exei sthles userID(foreign key), reservationID(foreign key), travelInsuranceID, insurancetype, price
                    try
                    {
                        MySqlConnection cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sql = "INSERT INTO TravelInsurances (userID, reservationID, insurancetype, price) VALUES ('" + userID + "','" + reservationID + "','" + insuranceType + "','" + price + "')";
                        MySqlCommand command = new MySqlCommand(sql, cnn);
                        command.ExecuteReader();
                        cnn.Close();
                        checksavedTravelInsurance = true;
                        return checksavedTravelInsurance;
                    }
                    catch
                    {
                        return checksavedTravelInsurance;//epsitrefoume error se periptwsi pou "skasei i vasi" kai den apothikeutei to id
                    }
                }
                else
                {
                    return checksavedTravelInsurance;
                }

            }
            else if (choice=="upgrade")
            {
                bool checkupgraded = false;
                TravelInsurance tk = new TravelInsurance();

                checkupgraded = tk.upgrade(userID);

                if (checkupgraded == true)
                {
                    try
                    {
                        MySqlConnection cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sql = "INSERT INTO TravelInsurances (userID, reservationID, insurancetype, price) VALUES ('" + userID + "','" + reservationID + "','" + insuranceType + "','" + price + "')";
                        MySqlCommand command = new MySqlCommand(sql, cnn);
                        command.ExecuteReader();
                        cnn.Close();
                        checksavedTravelInsurance = true;
                        return checksavedTravelInsurance;
                    }
                    catch
                    {
                        return checksavedTravelInsurance;//epsitrefoume error se periptwsi pou "skasei i vasi" kai den apothikeutei to id
                    }
                }
                else
                {
                    return checksavedTravelInsurance;
                }
            }
        }
        public bool upgrade(int userID)//otan o xristis epilexei oti thelei na anavathmisi ton logariasmo tou tha tou emfanizei ti selida anavathmisis logariasmou
        {
            bool checkupgraded = false;
            //pigenei stin account elegxei an exei kanei upgrade iii oxi
            //kai an exei kanei 
            //tote dikaioutai dwrean allagi imerominiwn
            //ara den xreiazetai na ginei pay
            //ara epistrefei mia metavliti 
            return checkupgraded;


        }

        public bool pay(int userID, double price)//otan o xristis epilexei na plirwsei tha ton stelnei sto exwteriko sustima tis trapezas
        {
            bool paymentcheck = false;
            //arxikopoioume tin paymentcheck
            //se auto to simeio tha epikoinwnei to europemoov me to sustima tis trapezas 
            //kai an exei ginei i plirwmi stin trapeza tha apothikeuetai se mia metavliti paymentcheck=true; iii paymentcheck=false; an den exei ginei


            return paymentcheck;
        }
    }
}