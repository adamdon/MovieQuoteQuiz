using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    [Serializable]
    class Player
    {
        public string strUsername { get; set; }
        public int intTotalRoundsPlayed { get; set; }
        public int intTotalCorrectQuestions { get; set; }
        public int intintTotalPointsAllGames { get; set; }

        public Player(string strUsernameP)
        {
            strUsername = strUsernameP;
            intTotalRoundsPlayed = 0;
            intTotalCorrectQuestions = 0;
            intintTotalPointsAllGames = 0;
        }

    }
}
