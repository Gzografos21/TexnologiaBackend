using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexnologiaProject
{
    public class UploadedRoomsToFiloxenia
    {
        private string city;
        private string country;
        private int persons;
        private DateTime startingDate;
        private DateTime endingDate;
        private string information;

        private string uploadedPhotos;
        private int earnedPointsUploadFiloxenia;

        //estw oti apothikeuoume ta tetragwnika pou vazei o xristis se mia metavliti pou onomazetai squareMeters

        //estw oti to userID=1 photos=true kai squaremeters=15

        //int userID = 1;
        //bool photos = true;
        //double squareMeters = 15;


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



        public bool saveRoomToUploadedRoomsToFiloxenia(int userID, string city, string country, int persons, double squareMeters, DateTime startingDate, DateTime endingDate, string information, bool photos, string uploadedPhotos)
        {

            //kaloume tis duo methodous checkSquareMeters() kai checkForUpladedPhotos() 
            //kai analoga me to an einai true i false kai oi duo tote kanoume insert sti vasi

            bool checkphotos = false;
            UploadedRoomsToFiloxenia cp = new UploadedRoomsToFiloxenia();
            checkphotos = cp.checkForUploadedPhotos(userID, photos);

            bool checksquare = false;
            UploadedRoomsToFiloxenia cs = new UploadedRoomsToFiloxenia();
            checksquare = cs.checkSquareMeters(userID, squareMeters);



            bool checksavedRoom = false;
            string connectionString = @"server=localhost;user id=root; password=4040; persistsecurityinfo=True;database=texnologiavasi";

            if (checksquare == true && checkphotos == true)
            {
                //dimiourgoume sti vasi mas allo ena upothetiko table me titlo Rooms kai stiles to roomID(primary key), userID(foreign key), city, country, persons, startingDate, endingDate, information, square, uploadedPhotos

                try
                {
                    MySqlConnection cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sql = "INSERT INTO texnologiavasi.rooms (userid, city, country, persons, startingDate, endingDate, information, square, uploadedPhotos) VALUES('" + userID + "', '" + city + "', '" + country + "', '" + persons + "',@startingDate, @endingDate , '" + information + "','" + squareMeters + "','" + uploadedPhotos + "')";
                    MySqlCommand command = new MySqlCommand(sql, cnn);
                    command.Parameters.AddWithValue("@startingDate", startingDate);
                    command.Parameters.AddWithValue("@endingDate", endingDate);
                    MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql
                    cnn.Close();
                    checksavedRoom = true;

                    return checksavedRoom;
                    //an den upirxe provlima sti vasi epistrefei true
                    //alliws pigenei sto catch kai epistrefei tin arxikopoiimeni timi false

                }
                catch (Exception ex)
                {
                    return checksavedRoom;
                }

            }
            else
            {
                return checksavedRoom;
            }
        }
        public bool IncreasePointsUploadRoom(int userID, string city, string country, int persons, double squareMeters, DateTime startingDate, DateTime endingDate, string information, bool photos, string uploadedPhotos)
        {
            //exoume allo ena upothetiko table gia tous pontous tou xristi, opou mesa tha exei to userID(foreign key), PointID(primary key) kai collectedPoints
            //tha kalesoume tin saveRoomToUploadedRoomsToFiloxenia kai me vasi to checksavedRoom an einai true i false tha proxwrisoume

            //UploadedRoomsToFiloxenia sr = new UploadedRoomsToFiloxenia();
            //checkSaved = sr.saveRoomToUploadedRoomsToFiloxenia(userID, city, country, persons, squareMeters, startingDate, endingDate, information, photos, uploadedPhotos);

            bool checkSaved = true;
            int earnedPointsUploadFiloxenia = 10000;

            List<int> PointTable = new List<int>();
            Points pointclass = new Points();

            PointTable = pointclass.getUsersPoints(userID);
            int pointid = 0;
            int userspoints = 0;
            pointid = PointTable[0];
            userspoints = PointTable[1];
            int newpointstobesaved = 0;
            newpointstobesaved = earnedPointsUploadFiloxenia + userspoints;
            //estw oti to point id einai 2

            int pointID = 1;

            Points np = new Points();
            bool newpoints = false;
            newpoints = np.saveNewPoints(pointID, newpointstobesaved);

            if (newpoints == true)
            {
                checkSaved = true;
                return checkSaved;
            }
            else
            {
                return checkSaved;
            }
        }
    }
}
