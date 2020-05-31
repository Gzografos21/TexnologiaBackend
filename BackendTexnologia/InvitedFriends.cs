using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class InvitedFriends
    {
        private string emailFriend;
        private bool accepted;
        private int earnedPointsInvitations;
        private string sendingInvitationDate;
        //Auta ta duo attributes ta orizoume gia na min mas bgazei suntantiko error
        //tha ta xreiastoume parakatw
        //ousiastika auta ta exei pliktrologisei o xristis kai auta vriskontai stin klasi user
        //kai tha ta xrisimoipoiisoume sti methodo newSignupCheck()  

        public string email;
        public DateTime signupDate;


        public bool sendInvitation(string emailfriend)
        {
            //estw oti apothikeuoume to email tou filou pou mas exei dwsei o xristis se mia metavliti emailFriend
            //to sustima mas edw tha stelnei automata ena email sto email pou mas exei dwsei o xristis
            //pou tha ton proskalei sto na graftei sto Europemoov (mesa tha exei enan link pou tha ton pigenei apeutheias sto signup)
        }

        string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=TexnologiaVasi";

        public void saveInvitation(string email, int userID, string sendingInvitationDate)
        {
            //edw dimiourgoume ena table gia ta invitations tou xristi me titlo invitations kai stiles invitationID(primary key), userID(foreign key), emailFriend, sendingInvitationDate
            //to invitationID tha ginetai autoincrement apo ti vasi
            //ara tha kanoume insert to email tou filou tou xristi to opoio omws tha einai apothikeumeno me vasi to id tou idiou tou xristi pou ton proskalese
            //etsi wste na xeroume posa invitations kai se poia email exei steilei
            //tha kanoume insert sti vasi
            //den tha ginetai se auto to simeio edw o elegxos gia to an exei graftei swsta to email tou filou tou apo ton xristi (regural expression tha ginetai sto frontend)

            bool checksavedInv = false;
            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sql = "INSERT INTO invitations (emailFriend, sendinginvitationDate) VALUES('" + email + "', '" + sendingInvitationDate + "')";
                MySqlCommand command = new MySqlCommand(sql, cnn);
                command.ExecuteCommand();
                cnn.Close();
                checksavedInv = true;
                return checksavedInv;
                //an den upirxe provlima sti vasi epistrefei true
                //alliws pigenei sto catch kai epistrefei tin arxikopoiimeni timi false

            }
            catch
            {
                return checksavedInv;
            }
        }
        //epistrefoume lista apo strings giati theloume na epistrepsoume duo pragmata
        //to userID kai to checkInvitationAccepted

        public bool newSignUpCheck(string email, DateTime signupDate)
        {
            //o xristis tha pairnei pontous efoson to invitation pou exei steilei ston filo tou exei ginei apodekto mesa se 30 meres
            //diladi o filos tou na kanei eggrafi sto Europemoov entws 30 imerwn
            //gia na to elegxoume auto tha prepei me to pou kanei eggrafi o xristis na kratame to email kai tin imerominia eggrafis tou se duo metavlites
            //exoume orisei ta email kai signupDate panw panw kai einai auta pou vriskontai stin klasi User(ta opoia tha ta exei plikrologisei o xristis)
            //edw theloume na kanoume mia anazitisi sti vasi mas sto table invitations kai na doume an uparxei to sugekrimeno email pou exei valei o xristis kata tin eggrafi
            //sta apothikeumena email sta opoia exei apostalei prosklisi
            //an uparxei to email tou sto table me ta invitations KAI EXEI GINEI I EGGRAFI 
            //kai i eggrafi exei ginei entws 30 imerwn
            //AUTO simainei oti exei ginei prosklisi gia ton sugekrimeno xristi kai an o xristis kanei eggrafi mesa se 30 meres o allos xristis pou ekane to sugekrimeno invitation tha parei pontous


            bool checksignup = true;
            bool checkemail = false;
            bool finalcheckdays = false;

            //edw kanoume select sto table invitations gia na mathoume an i eggrafi sto sustima proilthe apo apodoxi prosklisis i oxi (kathw sto table invitations exoume apothikeumenes ta email ton proskeklimenwn xristwn)

            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
                cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                           //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
                string sql = "Select UserID, emailFriend, sendingInvitationDate from invitations where emailFriend='" + email + "'";//einai ena aplo string pou tha xrisimopoithei ws query
                MySqlCommand command = new MySqlCommand(sql, cnn);//arxikopoioume to command pou xrisimopoiei ti vilviothiki MySqlCommand i opoia exei 2 orismata
                MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql
                string userIDFriendFromDB = "";
                while (dataReader.Read())
                {
                    userIDFriendFromDB = dataReader[0].ToString();

                }

                cnn.Close();//edw kleinoume ti sindesi me ti vasi

                if (userIDFriendFromDB != "")
                {
                    checkemail = true;
                }
            }
            catch
            {
                checkemail = false;
            }

            //se auto to simeio pairnoume tin imerominia apostolis tis prosklisi kai to userID tou xristi me vasi to email pou exei kanei prosklisi o idios

            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
                cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                           //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
                string sql = "Select sendingInvitationDate, userID from invitations where emailFriend='" + email + "'";//einai ena aplo string pou tha xrisimopoithei ws query
                MySqlCommand command = new MySqlCommand(sql, cnn);//arxikopoioume to command pou xrisimopoiei ti vilviothiki MySqlCommand i opoia exei 2 orismata
                MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql

                string userIDIncreasePoints = "";
                DateTime sendingInvitationDateFromDB;
                while (dataReader.Read())
                {
                    //apothikeuoume se mia metabliti sendingInvitationDateFromDB tin imerominia apostolis prosklisis
                    sendingInvitationDateFromDB = dataReader.getDateTime(0);//i triti stili einai to date
                    //apothikeuoume se mia metabliti to id tou sugekrimenou xristi//kai tha to epistrepsoume mazi me to teliko result mesa se lista apo string
                    string userIDIncreasePoints = dataReader[1].ToString();
                }

                cnn.Close();//edw kleinoume ti sindesi me ti vasi



                // afairoume tis duo imerominies gia na mathoume poses meres mesolabisan apo tin apostoli tis prosklisis mexri tin apodoxi tis prosklisis/eggrafi sto sustima
                TimeSpan result = signupDate.Subtract(sendingInvitationDateFromDB);
                //metatrepoume to apotelesma se int kai to apothikeuoume se mia metavliti days
                int days = (int)result.TotalDays;

                //an exoun meswlavisei perissoteres apo 30 meres o xristis pou esteile tin prosklisi den pairnei pontous
                //alla auto tha elegxei stin increasePointsInvitedFriends() 

                if (days > 30)
                {
                    finalcheckdays = false;
                }
                else
                {
                    finalcheckdays = true;

                }
            }
            catch
            {
                finalcheckdays = false;
            }


            string checkInvitationAccepted = "ERROR";

            List<string> FinalList = new List<string>();
            //edw elegxoume tis duo simantikes sunthikes gia tin auxisi twn pontwn
            //apodoxi prosklisis (na exei kanei eggrafi)
            //apodoxi prosklisis mesa se 30 meres 

            if (finalcheckdays == true && checkemail == true)
            {
                increasePointsInvitedFriends(userIDFriendFromDB, collectedPoints);

                checkInvitationAccepted = "OK";
            }
            else
            {
                checkInvitationAccepted = "ERROR";

            }
        }


        public void increasePointsInvitedFriends(int userID)
        {
            //exoume allo ena upothetiko table gia tous pontous tou xristi, opou mesa tha exei to userid tou xristi kai tous sunolikous tou pontous
            //tha kalesoume tin newSignupCheck kai me vasi to FinalList proxwrame
            //kathws o xristis pairnei pontous an exei ginei apodexti i prosklisi entws 30 imerwn

            //pairnoume to userID pou brisketai sto prwto kouti tis listas mas kai to bazoume se mia metabliti finalUserID
            //pairnoume to checkInvitationAccepted pou vrisketai sto deutero koutaki tis listas kai to bazoume se mia metavliti finalCheck
            bool finalCheck = false;

            if (finalCheck == true)
            {
                //kaloume tin increasePoints apo tin klasi Points


                //an exei ginei apodexti i prosklisi entws 30 imerwn o xristis pairnei 500 pontous
                int earnedPointsInvitation = 500;
                //edw tha ginei select apo to table me tous pontous kai tha to apothikeui se mia metavliti savedPoints
                List<int> PointTable = new List<int>();
                //Bazoume to sugekrimeno id pou exoume parei apo tin newSignUpCheck
                PointTable = Points.getUsersPoints(userID);//auto einai mia lista me duo pragmata. to pointID kai to sunolo twn pontwn 

                int pointid = 0;
                int userspoints = 0;
                //auto tha ginotan sto frontend gia na ta emfanisei 
                //for (int i; i < Pointtable.Count(); i++)
                //{
                pointid = Pointtable[0];//id=5
                userspoints = Pointtable[1];//collectedpoints = 8000
                //}
                int newpointstobesaved = 0;
                newpointstobesaved = earnedPointsInvitation + userspoints;

                Points.saveNewPoints(pointid, newpointstobesaved);
            }
        }
    }
}