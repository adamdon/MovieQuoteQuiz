using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Game
    {
        public static List<Round> rouListOfRounds;

        public static string strPlayerName;
        public static Player plaCurrentPlayer;

        public static int intRoundsTotal;
        public static int intRoundCurrent;
        public static int intCorrectQuestions;
        public static int intTotalPoints;

        public static bool isGameInProgress;

        public Game(string strPlayerNameP, int intRoundsTotalP)
        {
            strPlayerName = strPlayerNameP;

            intRoundsTotal = intRoundsTotalP;
            intRoundCurrent = 0;
            intCorrectQuestions = 0;
            intTotalPoints = (intRoundsTotal * 5);
            isGameInProgress = true;

            rouListOfRounds = new List<Round>();
        }

        public void Run()
        {
            plaCurrentPlayer = Player.GetPlayer(strPlayerName);
            rouListOfRounds = Round.SetupRounds(intRoundsTotal);
            View.PopulateViewWithRound(rouListOfRounds, intRoundCurrent, isGameInProgress); ;
            View.PopulateViewWithPlayer(plaCurrentPlayer);
            View.PopulateViewWithScore(intRoundCurrent, intRoundsTotal, intCorrectQuestions, intTotalPoints);

            View.ActivateGameStateInView(isGameInProgress);

        }


        public void SubmitAnswer(int intSelectedRadio)
        {
          
            if (intSelectedRadio == rouListOfRounds[intRoundCurrent].intCorrectRadio)
            {
                intCorrectQuestions = intCorrectQuestions + 1;
                intTotalPoints = intTotalPoints + 10;
                View.UpdateStatusBar(intTotalPoints, "Correct!");
                
            }
            else
            {
                intTotalPoints = intTotalPoints - 5;
                View.UpdateStatusBar(intTotalPoints, "Wrong");     
            }

            if (intRoundCurrent < (intRoundsTotal - 1))
            {
                intRoundCurrent = intRoundCurrent + 1;
            }
            else
            {  
                EndGame();
            }
            View.PopulateViewWithRound(rouListOfRounds, intRoundCurrent, isGameInProgress);
            View.PopulateViewWithScore(intRoundCurrent, intRoundsTotal, intCorrectQuestions, intTotalPoints);
        }


        public void EndGame()
        {
            plaCurrentPlayer = Player.UpdatePlayer(plaCurrentPlayer, intTotalPoints, intCorrectQuestions, intRoundsTotal);
            View.PopulateViewWithPlayer(plaCurrentPlayer);

            isGameInProgress = false;
            View.UpdateStatusBar(intTotalPoints, "Game End!");
            View.ActivateGameStateInView(isGameInProgress);
            View.SetupDefultValues();
        }




    }
}
