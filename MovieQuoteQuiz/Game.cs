using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Game
    {
        public string strPlayerName { get; set; }
        public int intRoundsTotal { get; set; }
        public int intRoundCurrent { get; set; }
        public int intCorrectQuestions { get; set; }
        public int intTotalPoints { get; set; }

        public Game(string strPlayerNameP, int intRoundsTotalP)
        {
            strPlayerName = strPlayerNameP;
            intRoundsTotal = intRoundsTotalP;
            intRoundCurrent = 1;
            intCorrectQuestions = 0;
            intTotalPoints = 0;
        }

    }
}
