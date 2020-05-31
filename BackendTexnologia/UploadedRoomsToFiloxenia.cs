using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class UploadedRoomsToFiloxenia
    {
        private string city;
        private string country;
        private int persons;
        private double squareMeters;
        private DateTime startingDate;
        private DateTime endingDate;
        private string information;
        private bool photos;
        private string uploadedPhotos;
        private int earnedPointsUploadFiloxenia;

        //estw oti apothikeuoume ta tetragwnika pou vazei o xristis se mia metavliti pou onomazetai squareMeters
        public bool checkSquareMeters(int userID, double squareMeters)
        {
            bool check = false;
            if (squareMeters >= 10)
            {
                check = true;
                return check;
            }
            else
            {
                return check;
            }

        }
        //apothikeuoume to an exei anebasei fwtografia o xristis se mia metavliti photos kai an einai true exei anebasei, an einai false den exei anebasei
        public bool checkForUploadedPhotos(int userID, bool photos)
        {
            bool check = false;
            if (photos == true)
            {
                check = true;
                return check;
            }
            else
            {
                return check;
            }
        }

        string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=TexnologiaVasi";


        public bool saveRoomToUploadedRoomsToFiloxenia(int userID, string city, string country, int persons, double squareMeters, DateTime startingDate, DateTime endingDate, string information, string uploadedPhotos)
        {

            //kaloume tis duo methodous checkSquareMeters() kai checkForUpladedPhotos() 
            //kai analoga me to an einai true i false kai oi duo tote kanoume insert sti vasi

            bool checkphotos = false;
            UploadedRoomsToFiloxenia cp = new UploadedRoomsToFiloxenia();
            checkphotos = cp.checkForUploadedPhotos();

            bool checksquare = false;
            UploadedRoomsToFiloxenia cs = new UploadedRoomsToFiloxenia();
            checksquare = cs.checkSquareMeters();
            bool checksavedRoom = false;

            if (checksquare == true && checkphotos == true)
            {
                //dimiourgoume sti vasi mas allo ena upothetiko table me titlo Rooms kai stiles to roomID(primary key), userID(foreign key), city, country, persons, startingDate, endingDate, information, square, uploadedPhotos

                try
                {
                    MySqlConnection cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sql = "INSERT INTO Rooms (userID, city, country, persons, startingDate, endingDate,information, square, uploadedPhotos) VALUES('" + userID + "''" + city + "', '" + country + "', '" + persons + "','" + startingDate + "','" + endingDate + "','" + squareMeters + "','" + information + "','" + uploadedPhotos + "')";
                    MySqlCommand command = new MySqlCommand(sql, cnn);
                    command.ExecuteCommand();
                    cnn.Close();
                    checksavedRoom = true;

                    return checksavedRoom;
                    //an den upirxe provlima sti vasi epistrefei true
                    //alliws pigenei sto catch kai epistrefei tin arxikopoiimeni timi false

                }
                catch
                {
                    return checksavedRoom;
                }

            }
            else
            {
                return checksavedRoom;
            }
        }

    }

    public bool increasePointsUploadRoom()
    {
        //exoume allo ena upothetiko table gia tous pontous tou xristi, opou mesa tha exei to userid tou xristi kai tous sunolikous tou pontous
        //tha kalesoume tin saveRoomToUploadedRoomsToFiloxenia kai me vasi to checksavedRoom an einai true i false tha proxwrisoume
        string checkSaved = "";
        UploadedRoomsToFiloxenia sr = new UploadedRoomsToFiloxenia();
        checkSaved = sr.saveRoomToUploadedRoomsToFiloxenia();

        if (checkSaved == true)
        {

            //an isxuei i sunthiki gia kathe oloklirwmeni anartisi dwmatiou pairnei 10000 pontous
            int earnedPointsUploadFiloxenia = 10000;
          
            List<int> PointTable = new List<int>();

            PointTable = Points.getUsersPoints(userID);
            int pointid = 0;
            int userspoints = 0;
            pointid = Pointtable[0];
            userspoints = Pointtable[1];
            int newpointstobesaved = 0;
            newpointstobesaved = earnedPointsUploadFiloxenia + userspoints;

            Points.SaveNewPoints(pointid, newpointstobesaved);
        }
    }

}
