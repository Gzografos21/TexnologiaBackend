using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class TravelPackage:Reservation
    {
        private string destination;
        private int persons;
        private int earnedPointsTravelPackage;

        public bool checkForTravelPackage()
        {
            //select sti vasi gia ton elegxo tou TravelPackage
            //exoun dwthei endeiktikes entoles kai se alles klaseis gia to pws tha mporouse na ginei

        }
        public string matchmakingAlgorithm()
        {

        }

        public bool checkAvailability()
        {
            //edw tha kaleitai i checkAvailability() tis uperklasis Reservation
        }
        public bool saveReservation()
        {
            //edw tha kaleitai i saceResevation() tis uperklasis Reservation
        }

        public bool increasePoints()
        {
            //edw tha kaleitai i increasePoints() tis Points
        }

        public static void pay()
        {
            //edw otan thelei o xristis na plirwsei tha ton pigenei sto perivallon tis trapezas gia tin plirwmi
        }
    }
}