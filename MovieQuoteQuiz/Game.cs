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
            View.strlblTestLable1 = "Game Start"; 

        }


        public void SubmitAnswer(int intSelectedRadio)
        {
            if (intSelectedRadio == rouListOfRounds[intRoundCurrent].intCorrectRadio)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }

            EndRound();
        }

        public void EndRound()
        {
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

        public void CorrectAnswer()
        {
            intCorrectQuestions = intCorrectQuestions + 1;
            intTotalPoints = intTotalPoints + 10;
            View.UpdateStatusBar(intTotalPoints, "Correct!");
            View.strlblTestLable1 = "Correct!";
        }

        public void WrongAnswer()
        {
            intTotalPoints = intTotalPoints - 5;
            View.strlblTestLable1 = "Wrong";
        }


        public void EndGame()
        {
            plaCurrentPlayer = Player.UpdatePlayer(plaCurrentPlayer, intTotalPoints, intCorrectQuestions, intRoundsTotal, strPlayerName);
            View.PopulateViewWithPlayer(plaCurrentPlayer);

            isGameInProgress = false;
            View.UpdateStatusBar(intTotalPoints, "Game End!");
            View.strlblTestLable1 = ("End: " + intCorrectQuestions + "/" + intRoundsTotal);
            View.ActivateGameStateInView(isGameInProgress);
            View.SetupDefultValues();
        }




    }
}
