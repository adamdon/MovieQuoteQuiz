using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class View
    {
        public static string strLblQuestioRoundText = "Question 0";
        public static string strLblCurrentQuestion = "Movie Quote";
        public static string strlblStatusBar = "Status Bar";

        public static string strlblCurrentRound = "0/0";
        public static string strlblCorrectAnswers = "0";
        public static string strlblGamePoints = "0";

        public static string strRadAnswer1 = "Answer 1";
        public static string strRadAnswer2 = "Answer 2";
        public static string strRadAnswer3 = "Answer 3";

        public static bool isRadAnswer1Selected = false;
        public static bool isRadAnswer2Selected = false;
        public static bool isRadAnswer3Selected = false;

        public static bool isbtnSubmitAnswerActive = false;
        public static bool isbtnNewGamebuttonActive = true;

        public static bool isgruQuizGroupBoxActive = false;

        public static void UpdateStatusBar(int intTotalPoints, string strMessage)
        {
            strlblStatusBar = "Points: " + intTotalPoints + " - " + strMessage;
        }

        public static void UpdateStatusBarError(string strMessage)
        {
            strlblStatusBar = "Error: " + strMessage;
        }

        public static void SetupDefultValues()
        {
            strLblQuestioRoundText = "Question 0";
            strLblCurrentQuestion = "Movie Quote";

            strlblCurrentRound = "0/0";
            strlblCorrectAnswers = "0";
            strlblGamePoints = "0";

            strRadAnswer1 = "Answer 1";
            strRadAnswer2 = "Answer 2";
            strRadAnswer3 = "Answer 3";

            isRadAnswer1Selected = false;
            isRadAnswer2Selected = false;
            isRadAnswer3Selected = false;

            isbtnSubmitAnswerActive = false;
            isbtnNewGamebuttonActive = true;
            isgruQuizGroupBoxActive = false;
        }
    }
}
