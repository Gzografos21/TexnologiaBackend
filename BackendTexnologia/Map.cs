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
        private string tripDate;
        private bool pinPhoto;
    }

    //an kai o xartis afora to front end sto sugekrimeno sustima tha xreiastoume na apothikeusoume ta pins sti vasi
    //mporoun na xrisimopoiithoun diafora ergaleia opws ajax gia tin emfanisi twn pin panw sto xarti xwris na ginetai refresh tis selidas

    public bool savePin()//me ta antistoixa orismata
    {
        //se auto to simeio tha prepei na pairnoume ta coordinates tou kathe pin pou vazei o xristis kai na ta apothikeuoume me insert sti vasi dedomenwn se ena kainourio table
        //to table auto tha mporouse na onomastei pins kai na apoteleitai apo to userid tou xristi kai alles treis stiles lattitude kai longitude photo kai imerominia taxidiou
        //kai otan mpainei o xristis sto profile tou to sustima tha prepei automata na kanei select apo ti vasi dedomenwn ta stoixeia tou table pins gia paradeigma opws anaferame parapanw
        //kai na ta emfanizei panw ston xarti
        //epeidi omws mporei na exei polla stoixeia isws o kaluteros tropos einai na xrisimopoiisoume lista tis listas. I mia lista einai ta coordinates tis photos kai tin imerominia kai i alli lista einai to sunolo twn pins
        //opote tha emfanizontai ola ta simeia ston xarti me tis fwtografies
        //uparxoun texnologies etsi wste na mporei o xristis apla pigenontas to velaki panw apo to pin na tou emfanizei ti fwtografia, omws emvathunoumai parapanw apo oso apaiteitai
        //epomenes merikes endeiktikes entoles gia tin apothikeusi pins sti vasi dedomenwn tha mporousan na einai
        try
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            cnn.Open();
            string sql = "INSERT INTO PINS (userID, latitude, longitude, date)VALUES('" + userid + "','" + lati + "','" + longi + "','"+date+"')";
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

}
