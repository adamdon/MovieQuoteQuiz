using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Controller
    {
        //public static Random ranRandomNumber = new Random();

        public static void StartNewGame(string strPlayerName, int intRoundsTotal)
        {
            View.SetupDefultValues();

            Database.gamCurrentGame = new Game(strPlayerName, intRoundsTotal);
            Database.gamCurrentGame.Run();

            View.isbtnNewGamebuttonActive = false;
            View.isbtnSubmitAnswerActive = true;
            View.isgruQuizGroupBoxActive = true;

            View.strlblCurrentRound = ("1/" + intRoundsTotal);
            View.UpdateStatusBar(0, (strPlayerName + "'s game setup with " + intRoundsTotal + " rounds"));

        }

        public static void SubmitAnswer(int intSelectedRadio)
        {
            Database.gamCurrentGame.SubmitAnswer(intSelectedRadio);
            Database.gamCurrentGame.PopulateViewWithRound();
        }

        public static void SetupApplication()
        {
            View.SetupDefultValues();

            Database.SetupQuestions();
            Database.MakeSaveFile();
            Database.WriteToSaveFile();
            Database.ReadFromSaveFile();
        }


        public static void PopulateViewWithPlayer(Player plaPlayerToPopulate)
        {
            double dubPercentageCorrect = (((double)plaPlayerToPopulate.intTotalCorrectQuestions / (double)plaPlayerToPopulate.intTotalRoundsPlayed) * 100);
            dubPercentageCorrect = Math.Round(dubPercentageCorrect, 2);
            if (Double.IsNaN(dubPercentageCorrect))
            {
                dubPercentageCorrect = 0;
            }

            View.strlblPlayerName = plaPlayerToPopulate.strUsername;
            View.strlblPercentageCorrect = (dubPercentageCorrect.ToString() + "%");
            View.strlblTotalPoints = plaPlayerToPopulate.intintTotalPointsAllGames.ToString();
        }

        public static Player GetPlayerFromList(string strPlayerNameTemp)
        {
            foreach (Player plaPlayerIndex in Database.plaListOfPlayers)
            {
                if (plaPlayerIndex.strUsername == strPlayerNameTemp)
                {
                    View.UpdateStatusBarError("Player " + strPlayerNameTemp + " not new");
                    return plaPlayerIndex;
                }
            }
            return new Player(strPlayerNameTemp);
        }


    }
}
