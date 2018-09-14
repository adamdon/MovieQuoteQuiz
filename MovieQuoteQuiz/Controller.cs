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

        public static void StartNewGame()
        {
            //PopulateRoundWithQuestion();
            Database.gamCurrentGame = new Game("Player1", Database.queListOfQuestions.Count);
            Database.gamCurrentGame.SetupRounds();
            Database.gamCurrentGame.PopulateViewWithRound();
        }

        public static void SubmitAnswer(int intSelectedRadio)
        {
            Database.gamCurrentGame.SubmitAnswer(intSelectedRadio);
            Database.gamCurrentGame.PopulateViewWithRound();
        }



    }
}
