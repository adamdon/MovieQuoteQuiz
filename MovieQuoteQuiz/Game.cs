using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Game
    {
        //public static Random ranRandomNumber = new Random();

        //public static List<int> intListOfUsedQuestions; // = new List<int>();
        //public static List<int> intListOfUsedAnswers; // = new List<int>();
        //public static List<int> intListOfUsedRadioPositions;

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
            //intListOfUsedQuestions = new List<int>();
            //intListOfUsedAnswers = new List<int>();
            //intListOfUsedRadioPositions = new List<int>();

        }

        public void Run()
        {
            plaCurrentPlayer = Player.GetPlayer(strPlayerName);
            rouListOfRounds = Round.SetupRounds(intRoundsTotal);
            View.PopulateViewWithRound(rouListOfRounds, intRoundCurrent, isGameInProgress); ;
            View.PopulateViewWithPlayer(plaCurrentPlayer);
            View.PopulateViewWithScore(intRoundCurrent, intRoundsTotal, intCorrectQuestions, intTotalPoints);

            View.isbtnNewGamebuttonActive = false;
            View.isbtnSubmitAnswerActive = true;
            View.isgruQuizGroupBoxActive = true;

        }


        public void SubmitAnswer(int intSelectedRadio)
        {
          
            if (intSelectedRadio == rouListOfRounds[intRoundCurrent].intCorrectRadio)
            {
                intCorrectQuestions = intCorrectQuestions + 1;
                intTotalPoints = intTotalPoints + 10;
                View.UpdateStatusBar(intTotalPoints, "Correct!");
                View.PopulateViewWithRound(rouListOfRounds, intRoundCurrent, isGameInProgress);
                
            }
            else
            {
                intTotalPoints = intTotalPoints - 5;
                View.UpdateStatusBar(intTotalPoints, "Wrong");
                View.PopulateViewWithRound(rouListOfRounds, intRoundCurrent, isGameInProgress);
           
            }

            if (intRoundCurrent < (intRoundsTotal - 1))
            {
                intRoundCurrent = intRoundCurrent + 1;
            }
            else
            {  
                EndGame();
            }

            View.PopulateViewWithScore(intRoundCurrent, intRoundsTotal, intCorrectQuestions, intTotalPoints);
        }


        public void EndGame()
        {
            plaCurrentPlayer = Player.UpdatePlayer(plaCurrentPlayer, intTotalPoints, intCorrectQuestions, intRoundsTotal);
            View.PopulateViewWithPlayer(plaCurrentPlayer);

            isGameInProgress = false;
            View.UpdateStatusBar(intTotalPoints, "Game End!");
            View.isbtnSubmitAnswerActive = false;
            View.isbtnNewGamebuttonActive = true;
            View.SetupDefultValues();
        }




    }
}
