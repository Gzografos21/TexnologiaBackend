using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class TravelPackage:Reservation
    {
        private string destination;
        private int persons;
        private int earnedPointsTravelPackage;
        private string countryOfDeparture;
        private string preferences;

        //i exwteriki vasi dedomenvn tvn taxidiwtikwn paketvn tha exei sthles travelpackageID(primary key), userID(foreign key), CountryOfDeparture, Destination, DepartureDate, ArrivalDate, Price, Persons
        public List<string> returnTravelPackages(string countryOfDeparture)
        {

            List<string> listAll = new List<string>();//orizoume mia keni lista opou mesa tha apothikeusoume ta taxidiwtika paketa pou uparxoun analoga me ti xwra anaxwrisis

            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
                cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                           //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
                string sql = "Select CountryOfDeparture, Destination, DepartureDate, ArrivalDate, Price from TravelPackages where CountryOfDeparture='" + countryOfDeparture + "'";//einai ena aplo string pou tha xrisimopoithei ws query
                MySqlCommand command = new MySqlCommand(sql, cnn);//arxikopoioume to command pou xrisimopoiei ti vilviothiki MySqlCommand i opoia exei 2 orismata
                MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql

                while (dataReader.Read())
                {
                    listAll.Add(dataReader[0].ToString()); 
                    listAll.Add(dataReader[1].ToString());
                    listAll.Add(dataReader[2].ToString());
                    listAll.Add(dataReader[3].ToString());
                    listAll.Add(dataReader[4].ToString());
                }

                cnn.Close();//edw kleinoume ti sindesi me ti vasi
            }
            catch
            {
                listAll.Add("Error");
                //return listid;
            }

            return listAll;
        }
        
        public List <string> matchmakingAlgorithm(string countryOfDpearture, string preferences)
        {
            //tha kanoume ena select stin exvteriki vasi dedomwnvn tvn taxidivtikvn paketvn me vasi th xvra anaxvrisis kai ta kritiria epiloghs/protimiseis pou eisagei o xristis
            //kai tha epistrefoume se mia lista ta taxidivtika paketa pou ikanopoioun ta kritiria tou xristi
        }

        public string getListAll()
        {
            List<string> returnedlist = new List<string>();

            returnedlist = TravelPackage.returnTravelPackages(" ", " ", " ", " ", " ");  //an o xristis eisagei mono xvra anaxvrisis

            returnedlist = TravelPackage.matchmakingAlgorithm(" ", " ", " ", " ", " ");  //an o xristis eisagei xvra anaxvrisis k kritiria epilogis/protimiseis

            string allresultsasstring = "";

            for (var i = 0; i < returnedlist.Count(); i++)
            {
                allresultsasstring += i + " στοιχείο:" + returnedlist[i] + ",";
            }

        }

        //pairnei orismata ta stoixeia tou taxidivtikou paketou pou epelexe o xristis kai elegxei an to sugkekrimeno paketo einai diathesimo gia ta atoma pou thelei
        public List<string> returnAvailable(string countryOfDeparture, string destination, DateTime dateOfDeparture, DateTime dateOfArrival, double price, int persons)   
        {

            List<string> listAll = new List<string>();//orizoume mia keni lista opou mesa tha apothikeusoume ta taxidiwtika paketa pou einai diathesima me vasi ta atoma pou eisagei o xristis

            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
                cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                           //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
                string sql = "Select CountryOfDeparture, Destination, DepartureDate, ArrivalDate, Price, Persons from TravelPackages where CountryOfDeparture='" + countryOfDeparture + "' AND Destination= '" + destination + "' AND DepartureDate=" + dateOfDeparture + "' AND ArrivalDate='" + dateOfArrival + "' AND Price='" + price + "' AND Persons='" + persons + "'"; //einai ena aplo string pou tha xrisimopoithei ws query
                MySqlCommand command = new MySqlCommand(sql, cnn);//arxikopoioume to command pou xrisimopoiei ti vilviothiki MySqlCommand i opoia exei 2 orismata
                MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql

                while (dataReader.Read())
                {
                    listAll.Add(dataReader[0].ToString());
                    listAll.Add(dataReader[1].ToString());
                    listAll.Add(dataReader[2].ToString());
                    listAll.Add(dataReader[3].ToString());
                    listAll.Add(dataReader[4].ToString());
                    listAll.Add(dataReader[5].ToString());
                }

                cnn.Close();//edw kleinoume ti sindesi me ti vasi
            }
            catch
            {
                listAll.Add("Error");
                //return listid;
            }

            return listAll;
        }
        public bool saveReservation(int userID, string countryOfDeparture, string destination, DateTime dateOfDeparture, DateTime dateOfArrival, double price, int persons)
        {

            //edw ftiaxnoume ena table pou tha legetai ReservedTravelPackages opou tha pairnei to userid tou xristi apo to table Users kai me vasi auto tha exei stiles
            // userID(foreign key) travelPackageID(primary key), CountryOfDeparture, Destination, DepartureDate, ArrivalDate, Price, Persons


            //ara gia na ginei i kratisi tha prepei na epilexei o xristis ena taxidivtiko paketo
            //estw loipon oti apothikeuetai se mia metavliti selectedTravelPackage to id tis sugekrimenis kratisis tou xristi

            //apothikeuoume to userID tou xristi pou kanei tin kratisi taxidivtikou paketou


            bool checksavedReserv = false;

            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sql = "INSERT INTO ReservedTravelPackages (userID, CountryOfDeparture, Destination, DepartureDate, ArrivalDate, Price, Persons) VALUES('" + userID + "''" + countryOfDeparture + "', '" + destination + "', '" + dateOfDeparture + "','" + dateOfArrival + "','" + price + "','" + persons + "'";
                MySqlCommand command = new MySqlCommand(sql, cnn);
                command.ExecuteCommand();
                cnn.Close();
                checksavedReserv = true;
                increasePointsTravelPackage(userID, 3000);
                return checksavedReserv;
                //an den upirxe provlima sti vasi epistrefei true
                //alliws pigenei sto catch kai epistrefei tin arxikopoiimeni timi false

            }
            catch
            {
                return checksavedReserv;
            }
        }

        public void increasePointsTravelPackage(int userID)
        {
            //exoume allo ena upothetiko table gia tous pontous tou xristi, opou mesa tha exei to userid tou xristi kai tous sunolikous tou pontous
            //tha kalesoume tin saveReservation kai me vasi to checksavedReserv an einai true i false tha proxwrisoume
            //kathws o xristis pairnei pontous an exei oloklirwthei i kratisi (na uparxei diathesimotita kai na exei ginei plirwmi opou ola auta elegxontai stin saveReservation)
            string checkSaved = "";
            TravelPackage tp = new TravelPackage();
            checkSaved = tp.saveReservation();

            if (checkSaved == true)
            {

                //an isxuei i sunthiki gia kathe oloklirwmeni kratisi taxidivtikou paketou pairnei 3000 pontous
                int earnedPointsTravelPackage = 3000;
              
                List<int> PointTable = new List<int>();

                PointTable = Points.getUsersPoints(userID);
                int pointid = 0;
                int userspoints = 0;
                //for (int i; i < Pointtable.Count(); i++)
                //{
                pointid = Pointtable[0];
                userspoints = Pointtable[1];
                //}
                int newpointstobesaved = 0;
                newpointstobesaved = earnedPointsTravelPackage + userspoints;

                Points.saveNewPoints(pointid, newpointstobesaved);
            }
        }

        public bool pay()//otan o xristis epilexei na plirwsei tha ton stelnei sto exwteriko sustima tis trapezas
        {
            bool paymentcheck = false;
            //arxikopoioume tin paymentcheck
            //se auto to simeio tha epikoinwnei to europemoov me to sustima tis trapezas 
            //kai an exei ginei i plirwmi stin trapeza tha apothikeuetai se mia metavliti paymentcheck=true; iii paymentcheck=false; an den exei ginei


            return paymentcheck;
        }
    }
}