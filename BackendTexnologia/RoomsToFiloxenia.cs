using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class RoomsToFiloxenia : Reservation
    {
        private string city;
        private string country;
        private string ownerName;
        private int persons;
        private int earnedPointsReservationFiloxenia;

        string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=TexnologiaVasi";//to bgazw apexw gia na mporw na to xrisimopoiw kathe fora pou xreiazetai na anoixw ti vasi

        
        public List<string> returnAvailable(string city, string country, int persons, DateTime dateOfDeparture, DateTime dateOfArrival)
        {

            List<string> listAll = new List<string>();//orizoume mia keni lista opou mesa tha apothikeusoume ta diathesima dwmatia

            //to table me titlo Rooms pou exei apothikeumena ta anartimena dvmatia tvn xristwn exei stiles to roomID(primary key), userID(foreign key), city, country, persons, startingDate, endingDate, information, square, uploadedPhotos
                try
                {
                    MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
                    cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                               //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
                    string sql = "Select userID, City, Country, startingDate, endingDate, Persons, Information, square, uploadedPhotos from Rooms where City='" + city + "' AND Country= '" + country + "' AND startingDate=" + dateOfDeparture + "'AND endingDate='" + dateOfArrival + "' AND Persons= '" + persons + "'" ;//einai ena aplo string pou tha xrisimopoithei ws query
                    MySqlCommand command = new MySqlCommand(sql, cnn);//arxikopoioume to command pou xrisimopoiei ti vilviothiki MySqlCommand i opoia exei 2 orismata
                    MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql

                    while (dataReader.Read())
                    {
                        listAll.Add(dataReader[1].ToString()); //kratame to userID tou xristi pou anevase to dwmatio etsi vste otan theloume na emfanisoume ta diathesima dwmatia na xanakanoume select st table user vste na paroume to name tou
                        listAll.Add(dataReader[2].ToString());
                        listAll.Add(dataReader[3].ToString());
                        listAll.Add(dataReader[4].ToString());
                        listAll.Add(dataReader[5].ToString());
                        listAll.Add(dataReader[6].ToString());
                        listAll.Add(dataReader[7].ToString());
                        listAll.Add(dataReader[8].ToString());
                        listAll.Add(dataReader[9].ToString());
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
        //se auto to simeio ginetai to display twn eisitiriwn

        public string getListAll()
        {
            List<string> returnedlist = new List<string>();
            returnedlist = RoomsToFiloxenia.returnAvailable(" ", " ", " ", " ", " ", " ", " ", " ", " ");
            string allresultsasstring = "";

            for (var i = 0; i < returnedlist.Count(); i++)
            {
                allresultsasstring += i + " στοιχείο:" + returnedlist[i] + ",";
            }
       
        }

        //gia na ginei save reservation prepei o xristis na exei epilexei dvmatio gia kratisi
 
        public bool saveReservation(string city, string country, int persons, DateTime dateOfDeparture, DateTime dateOfArrival)
        {

            //edw ftiaxnoume ena table pou tha legetai ReservedRooms opou tha pairnei to userid tou xristi apo to table Users kai me vasi auto tha exei stiles
           // userID, city, country, persons, startingDate, endingDate, information, square, uploadedPhotos


            //ara gia na ginei i kratisi tha prepei na epilexei o xristis ena apo ta diathesima dwmatia pou tou kaname "Display", to pws tha ginei afora kommati tou Frontend
            //estw loipon oti apothikeuetai se mia metavliti selectedRooms to id tis sugekrimenis kratisis tou xristi

            //apothikeuoume to userID tou xristi pou kanei tin kratisi dwmatiou

            bool checksavedReserv = false;
            
                try
                {
                    MySqlConnection cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sql = "INSERT INTO ReservedRooms (userID, City, Country, DepartureDate, ArrivalDate, Persons) VALUES('" + userID + "''" + city + "', '" + country + "', '" + dateOfDeparture+ "','" + dateOfArrival + "','" + persons + "'";
                    MySqlCommand command = new MySqlCommand(sql, cnn);
                    command.ExecuteCommand();
                    cnn.Close();
                    checksavedReserv = true;
                    increasePointsReservationFiloxenia(userID, 2000);
                    return checksavedReserv;
                    //an den upirxe provlima sti vasi epistrefei true
                    //alliws pigenei sto catch kai epistrefei tin arxikopoiimeni timi false

                }
                catch
                {
                    return checksavedReserv;
                }
        }

        public void increasePointsReservationFiloxenia(int userID, int collectedPoints)
        {
            //exoume allo ena upothetiko table gia tous pontous tou xristi, opou mesa tha exei to userid tou xristi kai tous sunolikous tou pontous
            //tha kalesoume tin saveReservation kai me vasi to checksavedReserv an einai true i false tha proxwrisoume
            //kathws o xristis pairnei pontous an exei oloklirwthei i kratisi (na uparxei diathesimotita kai na exei ginei plirwmi opou ola auta elegxontai stin saveReservation)
            string checkSaved = "";
            RoomsToFiloxenia rf = new RoomsToFiloxenia();
            checkSaved = rf.saveReservation();

            if (checkSaved == true)
            {

                //an isxuei i sunthiki gia kathe oloklirwmeni kratisi dwmatiou pairnei 2000 pontous
                int earnedPointsReservationFiloxenia = 2000;
                
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
                newpointstobesaved = earnedPointsReservationFiloxenia + userspoints;

                Points.saveNewPoints(pointid, newpointstobesaved);
            }
        }
        public bool saveReservationChange()
        {
            //Gia na ginei i allagi kratisis tha prepei na xanaginei oli i diadikasia elegxou diathesimotitas gia tis nees imerominies 
            //kai na kalountai opoies methodoi xreiazontai xana
            //efoson uparxei diathesimotita
            //an o xristis kanei allagi se imerominies eisitiriwn tote tha kanei update tis kainouries imerominies sto table ReservedRooms
        }


    }
}