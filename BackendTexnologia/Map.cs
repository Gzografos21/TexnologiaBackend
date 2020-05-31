using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class Map
    {
        private string tripDestination;
        private DateTime tripDate;

    }

    //an kai o xartis afora to front end sto sugekrimeno sustima tha xreiastoume na apothikeusoume ta pins sti vasi
    //mporoun na xrisimopoiithoun diafora ergaleia opws ajax gia tin emfanisi twn pin panw sto xarti xwris na ginetai refresh tis selidas

    public bool savePin(int userID, string lati, string longi, DateTime tripDate, string tripDestination)//me ta antisoixa orismata
    {
        //se auto to simeio tha prepei na pairnoume ta coordinates tou kathe pin pou vazei o xristis kai na ta apothikeuoume me insert sti vasi dedomenwn se ena kainourio table
        //to table auto tha mporouse na onomastei pins kai na apoteleitai apo to userid tou xristi(foreignkey) kai alles treis stiles lattitude kai longitude tripdestination kai tripdate
        //an theloume gia paradeigma na exei kai sxolia iii likes i fwtografia pou anebasei o xristis tha xreiastoume kai alles stiles antistoixa
        //kai otan mpainei o xristis sto profile tou to sustima tha prepei automata na kanei select (auto tha ginetai diladi sto pageload) apo ti vasi dedomenwn ta stoixeia tou table pins gia paradeigma opws anaferame parapanw
        //kai na ta emfanizei panw ston xarti
        //epomenes merikes endeiktikes entoles gia tin apothikeusi pins sti vasi dedomenwn tha mporousan na einai
        try
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            cnn.Open();
            string sql = "Insert into pins (latitude, longitude, tripdestination, tripdate)VALUES('" + lati + "','" + longi + "','"+tripDestination+"','"+tripDate+"')";
            MySqlCommand command = new MySqlCommand(sql, cnn);
            command.ExecuteReader();
            cnn.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

}

