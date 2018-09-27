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
            Database.gamCurrentGame.SetPlayer();
            Database.gamCurrentGame.SetupRounds();
            Database.gamCurrentGame.PopulateViewWithRound();
            Database.gamCurrentGame.PopulateViewWithPlayer();

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



    }
}
