using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class Post
    {
        private string tripDestination;
        private string travelExperience;
        private int earnedPointsPost;

        string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=TexnologiaVasi";

        public List<string> returnPosts(string tripDestination)
        {
            bool checkExistingPost = false;

            //edw kanoume select sto table posts gia na mathoume an uparxoyn posts gia to sygkekrimeno proorismo poy thelei o xristis
            //to table posts exei stiles userID(foreign key), tripdestination kai travelexperience

            List<string> listAll = new List<string>();

            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
                cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                           //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
                string sql = "Select * from posts where tripDestination='" + tripDestination + "'";//einai ena aplo string pou tha xrisimopoithei ws query
                MySqlCommand command = new MySqlCommand(sql, cnn);//arxikopoioume to command pou xrisimopoiei ti vilviothiki MySqlCommand i opoia exei 2 orismata
                MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql

                while (dataReader.Read())
                {
                    listAll.Add(dataReader[0].ToString());
                    listAll.Add(dataReader[1].ToString());
                    listAll.Add(dataReader[2].ToString());
                    //stin prwti stili exoume to userid tou xristi, to kratame etsi vste otan theloume na emfanisoume ta posts na xanakanoume select st table user vste na paroume to name tou
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
        public string getListAllPosts()
        {
            List<string> returnedlist = new List<string>();
            returnedlist = Post.returnPosts("", "", "", "", "", "");
            string allresultsasstring = "";

            for (var i = 0; i < returnedlist.Count(); i++)
            {
                allresultsasstring += i + " στοιχείο:" + returnedlist[i] + ",";
            }
            return allresultsasstring;
        }


        //ftiaxnoume sti vasi mas ena table posts opou apothikeuoume ta posts pou exoun anartisei oi xristes
        //kai exei sthles to userID(foreign key), tripdestination kai travelexperience

        public bool savePost(string tripDestination, string travelExperience)
        {
            bool checkUploadedPost = false;
            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sql = "INSERT INTO posts (tripdestination, travelexperience) VALUES('" + tripDestination + "', '" + travelExperience + "')";
                MySqlCommand command = new MySqlCommand(sql, cnn);
                command.ExecuteCommand();
                cnn.Close();

                checkUploadedPost = true;
                return checkUploadedPost;
                //an den upirxe provlima sti vasi epistrefei true
                //alliws pigenei sto catch kai epistrefei tin arxikopoiimeni timi false

            }
            catch
            {
                return checkUploadedPost;
            }

        }
        public void increasePointsPost(int userID, int collectedPoints)
        {
            //exoume allo ena upothetiko table gia tous pontous tou xristi, opou mesa tha exei to userid tou xristi kai tous sunolikous tou pontous
            //tha kalesoume tin savePost kai me vasi to checkUploadedPost an einai true i false tha proxwrisoume
            //kathws o xristis pairnei pontous an exei anartisi taxidiwtiko periexomeno
            string checkPost = "";
            Post ps = new Post();
            checkPost = ps.savePost();

            if (checkPost == true)
            {
                //kaloume tin increasePoints apo tin klasi Points


                //an isxuei i sunthiki gia kathe anartisi taxidiwtikou periexomenou pairnei 2000 pontous
                int earnedPointsPost = 2000;
                //edw tha ginei select apo to table me tous pontous kai tha to apothikeui se mia metavliti savedPoints
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
                newpointstobesaved = earnedPointsPost + userpoints;
                Points.saveNewPoints(pointid, newpointstobesaved);
            }
        }
    }
}