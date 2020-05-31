using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class User
    {
        private string name;
        public string email;
        private string password;//wietjwopitj@hotmail.com
        public DateTime dateOfBirth;
        public string phone;
        public int userID; //Auto to orizoume san metavliti edw alla pithanws na min xrisimopoiithei kapou kathws to kanoume auto-increment sti vasi kai apo ekei kanoume tous elegxous pou theloume me ta selects, ta inserts ktlp
        public DateTime signupDate;

        //tha prepei na ginei sundesi me ti vasi 
        //kai tha uparxei pali try catch se periptwsi pou skasei error sti vasi 
        //sto epomeno paradoteo tha perasoume pio analutika neous methodous
        //gia olous tous pithanous elegxous pou xreiazontai gia na ginoun kata tin eggrafi ii ti sundesi tou xristi

        public bool signUp(string name, string password, string email, DateTime dateOfBirth, DateTime signupDate)
        {

            //prwta tha elegxoume an uparxei o xristis kai an den uparxei tote tha kanoume insert sti vasi
            bool check = false;
            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sql = "Select name from users where name='" + name + "'";
                MySqlCommand command = new MySqlCommand(sql, cnn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader[0].ToString() == name)
                    {
                        check = true;
                    }
                }
            }
            catch
            {
                check = true;
            }

            //efoson den uparxei idi xristis kanoume to insert sti vasi


            if (check == true)
            {
                return check;
            }
            else
            {
                string hashedPassword = "";
                ConverterCls hs = new ConverterCls();
                hashedPassword = hs.Encrypt(password);

                try
                {
                    MySqlConnection cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sql = "INSERT INTO users(name , password, email, dateOfBirth, signupDate) VALUES('" + name + "', '" + hashedPassword + "', '" + email + "','" + dateOfBirth + "','"+ signupDate + "')";
                    MySqlCommand command = new MySqlCommand(sql, cnn);
                    command.ExecuteReader();
                    check = false;
                    
                    return check;
                    //Meta apo auti ti methodo sto frontend tha xrisimopoiisw to sugekrimeno email gia na dw me select kainouriou email apo ton pinaka invitations
                    //an uparxei to sugekrimeno email ekei mesa stis 30 imeres. Kai an uparxei tha pigenei kai tha prosthetei pontous sto userID tou pinaka invitations me to sugekrimeno email
                }
                catch
                {
                    return check;
                }
            }
            //se auto to simeio tha kaloume tin methodo returnNewEmailDate() 
            //kai se ekeini ti methodo tha apothikeuoume to 
        }
    }
}
//etsi ousiastika tha mporouse na klithei sto page load

public void PageLoad(EventArgs e)
{
    string emailtobechecked = this.txtEmail.Text;//Esto i timi pou dinei o xristis apo javascript
    bool chk = User.signUp("George", "Zografos", emailtobechecked, "CraetionDate");
    string useridthatInvitedthisnewUser = InvitedFriends.CheckInvitation(emailtobechecked);
    if (useridthatInvitedthisnewUser != "")
    {
        Points.increasePointsInvitedFriends(useridthatInvitedthisnewUser, 1500);
    }

}


public bool login(string name, string password)//bazoume orismata mesa
{
    try
    {
        MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
        cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                   //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
        string sql = "Select id, name, password, email from users where name='" + name + "'";//einai ena aplo string pou tha xrisimopoithei ws query
        MySqlCommand command = new MySqlCommand(sql, cnn);//arxikopoioume to command pou xrisimopoiei ti vilviothiki MySqlCommand i opoia exei 2 orismata
                                                          //

        MySqlDataReader dataReader = command.ExecuteReader();//(pataei kerauno)ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql

        bool check = false;

        while (dataReader.Read())
        {
            string decryptPassword = "";
            ConverterCls hs = new ConverterCls();//edw kaloume tin klasi Converter pou den tin exoume ulopoiisei alla ousiastika kanei 2-way encryption gia to passwrod
                                                 //me vasi etoimo algorithmo kai o datareader xekinaei na elegxei sti vasi
                                                 //me vasi to kwdikopoiimeno password. Einai pio swstos autos o tropos para na ginetai kateutheian, me auton ton tropo petuxainoume megaluteri asfaleia sto sustima
            decryptPassword = hs.Decrypt(dataReader[2].ToString());//to dataReade[2] einai i stili tou password
            if (decryptPassword == password)
            {
                check = dataReader[0].ToString();
            }
        }
        cnn.Close();
        check = true;
        return check;
    }
    catch
    {
        return false;
    }
}
