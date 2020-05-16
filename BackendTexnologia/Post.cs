using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class Post
    {
        private string tripDestination;
        private bool photos;
        private bool videos;
        private string travelExperience;
        private string accomodationEvaluation;
        private string travelMethodEvaluation;
        private string earnedPointsPost;

        public bool checkForThePost()
        {

        }

        public bool savePost()
        {

        }

        //edw kaloume ti methodo increasePoints() apo tin klasi Points
        //endeiktikes entoles kalesmatos tis increasePoints
        protected void Points() // dimiourgoume ena event apo ta asp buttons ston designer
        {
            // tha kalei edw mesa ti methodo increasePoints apo tin klasi Points
            //endeiktikes entoles
            string increase;
            Points inc = new Points();
            Increase = inc.increasePoints();//mesa stin parenthesi xreiazontai orismata, analoga ti pairnei i methodos increase
        }


    }
}