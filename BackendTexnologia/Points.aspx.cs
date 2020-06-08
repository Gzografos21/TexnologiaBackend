using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TexnologiaProject
{
    public partial class Points : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int collectedPoints;
        private int pointsForBackpack = 30000;
        private int pointsForDiscountedHostel = 50000;
        private int pointsForFreeTrip = 100000;
        private int remainingPointsToBackpack;
        private int remainingPointsToDiscountedHostel;
        private int remainingPointsToFreeTrip;

        string connectionString = @"server=localhost;user id=root; password=4040; persistsecurityinfo=True;database=texnologiavasi";

        public List<int> getUsersPoints(int userID)//pairnei orismata userID, earnedPoints
        {
            //me auti ti methodo pame kai pairnoume tous pontous pou exei mazepsei o xristis me to sugekrimeno id
            //Tha epistrefei
            List<int> getpointsandpoitnid = new List<int>();
            MySqlConnection cnn = new MySqlConnection(connectionString);
            cnn.Open();
            string sql = "select pointID, collectedpoints from texnologiavasi.points where userID = '" + userID + "'";
            MySqlCommand command = new MySqlCommand(sql, cnn);
            MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql

            while (dataReader.Read())
            {
                getpointsandpoitnid.Add(dataReader.GetInt32(0));//PointID
                collectedPoints = dataReader.GetInt32(1);
                getpointsandpoitnid.Add(collectedPoints);//Points
                return getpointsandpoitnid;
            }
            cnn.Close();
            return getpointsandpoitnid;
        }
        //to table point exei treis steiles
        //to PointID(Primary Key), userID(Foreign Key), collectedPoints


        public bool saveNewPoints(int pointID, int increasedpoints)
        {
            bool checksavedpoints = false;
            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);
                cnn.Open();

                string sql = "UPDATE texnologiavasi.points SET collectedpoints =@increasedpoints WHERE pointID =@pointID ";

                MySqlCommand command = new MySqlCommand(sql, cnn);

                command.Parameters.AddWithValue("@increasedpoints", increasedpoints);
                command.Parameters.AddWithValue("@pointID", pointID);

                MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql
                cnn.Close();
                checksavedpoints = true;

                return checksavedpoints;

            }
            catch (Exception ex)
            {
                return checksavedpoints;
            }


        }
        public bool checkPoints()
        {
            //edw tha ginetai elegxos an oi collectedPoints tou sugekrimenou User 
            //einai megaluteroi ii isoi apo tous pontous pou xreiazontai gia to backpack, tin ektpwsi sto hostel kai to dwrean taxidi
            //tha kaleitai otan o xristis epilexei oti thelei na kanei exargurwsi pontwn
            //An oi pontoi eparkoun tha ginetai exargurwsi, an den eparkoun tha tou proteinei tropous na sulexei pontous

            //tha pigenei sti selida Points
            //tha pataei redeem Points
            //kai to sustima tha elegxei an oi pontoi eparkoun gia exargurwsi
            //gia paradeigma an einai gia to backpack
            //tha kanei select sti vasi gia na parei tous pontous kai tha tous apothikeusei se mia metabliti collectedPoints
            bool check = false;
            if (collectedPoints >= pointsForBackpack)
            {
                //an isxuei i sunthiki
                check = true;
                return check;
            }
            else
            {
                return check;
            }
        }

        public List<string> displayRedeemChoices()
        {
            List<string> asd = new List<string>();
            return asd;
            //analoga me tous pontous pou exei sulexei o xristis tha tou emfanizei
            //diaforetikous tropous exargurwsis pontwn
            //px an o xristis exei sulexei 60000 pontous tha tou emfanizei 2 epiloges
            //2 backpack(30000 pontoi to kathena)
            //ekptwsi se hostel (50000 pontoi) kai tou menoun 10000 pontoi

        }

        public void substractPoints()
        {
            //prwta kaloume tin checkPoints gia na doume an exei tous pontous pou xreiazetai
            // kai apothikeuoume tous pontous se mia metavliti 
            //afairoume apo tous pontous pou exei epilexei tous pontous pou exargurwnei o xristis

            //kai meta kaloume tin saveNewPoints etsi wste na ginoun update sti vasi oi kainourioi pontoi
            //edw tha ginontai diafores praxeis gia tous pontous analoga otan prostithontai kai otan ginetai exargurwsi pontwn
        }

        //an o xristis den exei arketous pontous gia exargurwsi 
        //tha tou emfanizei proteinomenous tropous gia na mazepsei pontous
        //gia paradeigma an o xristis epilexei na kleisei taxidiwtiko paketo
        //tha ton stelnei sti selida Book Travel Package
        //omoiws gia ta upoloipa

        public void bookTravelPackage()
        {

        }

        public void inviteAFriend()
        {

        }

        public void reservationToFiloxenia()
        {

        }

        public void uploadToFiloxenia()
        {

        }

        public void bookHostel()
        {

        }

        public void bookTickets()
        {

        }

        public void post()
        {

        }

    }
}