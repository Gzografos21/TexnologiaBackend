using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class Points
    {
        private int collectedPoints;
        private int pointsForBackpack;
        private int pointsForDiscountedHostel;
        private int pointsForFreeTrip;
        private int redeemedPoints;
        private int remainingPointsToBackpack;
        private int remainingPointsToDiscountedHostel;
        private int remainingPointsToFreeTrip;

        public bool increasePoints()
        {
            //methodos i opoia tha kaleitai etsi wste na sugentrwnei olous tous pontous apo kathe energeia pou kanei
            //ousiastika i increasePoints tha einai dilwmeni se auti tin klasi kai tha kaleitai opou xreiazetai
            //gia paradeigma an eimaste sti selida invite a friend, me to pou ginei h epilogi "send invitation" tha prepei na kaleitai
            //i methodos increasePoints kai tha pairnei orismata pithanws diafora orismata opws tous sugekrimenous pontous gia kathe periptwsi
            // to swma tis increasePoints tha apoteleitai sigoura apo delete kai insert gia ti vasi dedomenwn
            //kai mporei na mpei sto table Users mia stili me tous pontous tou xristi kai kathe fora pou tha kaleitai auti i methodos
            // kanontas praxeis mesa stin methodo tha anoigei ti vasi tha kanei delete tous proigoumenous pontous tou xristi kai insert sti sugekrimeni stili kai grammi (diladi me vasi to userid tou xristi)
            //tous kainourious pontous tou xristi 
            //episis kai se autin tin periptwsi tha prepei na xrisimopoiithei to session gia na perasoun to user id etsi wste na xeroume gia poion xristi sugekrimena kanoume insert kai delete tous pontous tou

        }

        public bool checkPoints()
        {
            //edw tha ginetai select apo ti vasi gia na vriskoume akrivws ta points tou sugekrimenou xristi
        }

        public string displayRedeemChoices()
        {
            //select apo ti vasi gia emfanisi twn epilogwn exargurwsis
            //analoga me tous pontous pou exei sugentrwsei o xristis gia to backpack kai tis ekptwseis
        }

        public string substractPoints()
        {
            //edw tha afairei tous exargurwmenous pontous
        }

        public static void bookTravelPackage()
        {
            //ton pigenei stin othoni kleisimatos taxidiwtikou paketou, otan epilexei na kleisei taxidiwtiko paketo
        }

        public static void inviteAFriend()
        {
            //ton pigenei stin othoni prosklisis filou, otan epilexei na proskalesei filo 
        }

        public static void reservationToFiloxenia()
        {
            //ton pigenei stin othoni kratisis dwmatiou sto Filoxenia
        }

        public static void uploadToFiloxenia()
        {
            //othoni anartisis dwmatiou sto Filoxenia
        }

        public static void bookHostel()
        {
            //othoni kratisis Hostel
        }

        public static void bookTickets()
        {
            //othoni kratisis eisitiriwn
        }

        public static void post()
        {
            //othoni dimosieusis taxidiwtikou periexomenou
        }

    }

}