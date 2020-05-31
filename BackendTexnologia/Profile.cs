using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class Profile
    {
        private bool profilePhoto;
        private string placeOfLiving;
        private int numberOfPlacesVisited;
        private DateTime dateOfLastJourney;
        private string description;

        //estw oti exoume kratisei to userID tou xristi kata tin eisodo tou sto sustima otan pigenei sto profile tou exoume to userID
        //kai to xrisimopoioume san orisma

        public List<string> returnPostToUserProfile(int userID)
        {

            //apo to table posts opou apothikeuoume ta posts pou exoun anartisei oi xristes
            //kai exei sthles to userID(foreign key), tripdestination kai travelexperience
            //kanoume select me vasi to userID tou sugkekrimenou xristi gia na vroume ola ta posts pou exei anartisei

            List<string> listAll = new List<string>();

            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
                cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                           //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
                string sql = "Select travelexprerience, tripdestination from posts where userID='" + userID + "'";//einai ena aplo string pou tha xrisimopoithei ws query
                MySqlCommand command = new MySqlCommand(sql, cnn);//arxikopoioume to command pou xrisimopoiei ti vilviothiki MySqlCommand i opoia exei 2 orismata
                MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql

                while (dataReader.Read())
                {
                    listAll.Add(dataReader[1].ToString());
                    listAll.Add(dataReader[2].ToString());
                    //sti deuteri stili exoume to tripdestination
                    //stin triti stili exoume to travelexperience

                }
                cnn.Close();//edw kleinoume ti sindesi me ti vasi

            }
            catch
            {
                listAll = "error";
                return listAll;
            }
            return listAll;

        }

    }

    public string getListAllPosts()
    {
        List<string> returnedlist = new List<string>();
        returnedlist = Profile.returnPostToUserProfile();
        string allresultsasstring = "";

        for (var i = 0; i < returnedlist.Count(); i++)
        {
            allresultsasstring += i + " στοιχείο:" + returnedlist[i] + ",";
        }
        return allresultsasstring;
    }

    public bool saveToFavorites()
    {
        //mporoume na exoume alli mia stili sto table posts opou tha legetai favourite kai tha einai bool
        //an einai true simainei oti o xristis exei apothikeusei to sugekrimeno post sta agapimena tou
        //emeis ekei pera tha kanoume insert mia default timi false
        //kai otan o xristis tha thelei na apothikeusei kati sta agapimena 
        //tote kata to click pou tha kanei tha erxetai se auti ti methodo
        //me to sugekrimeno id tou tha pigenei stin posts kai tha kanei update me vasi to userID tou kai to postID kai tha to allazei se true
        
    }

    //~~~~~~AN THELOUME NA TA EMFANISOUME~~~~~
    //Tha kanoume ena select gia na paroume ola ta posts pou einai favourite (diladi opou i stili favourite einai true)
    //me to sugekrimeno id tou tha pigenei stin posts kai tha kanei update me vasi to userID(foreign key) tou kai to postID(primary key) kai tha to allazei se true
    //meta tha kanoume ena select gia na pairnoume ola ta postID tou posts pou exoun true stin stili favourite
    
}