using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Controller
    {
        public static Random ranRandomNumber = new Random();

        public static void StartNewGame(string srtPlayerName)
        {
            Database.gamCurrentGame = new Game(srtPlayerName, Database.queListOfQuestions.Count);
            Database.gamCurrentGame.UpdateListOfPlayersIfNew();
            Database.gamCurrentGame.SetupRounds();
            Database.gamCurrentGame.PopulateViewWithRound();

            View.isbtnNewGamebuttonActive = false;
            View.isbtnSubmitAnswerActive = true;
            View.isgruQuizGroupBoxActive = true;
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
