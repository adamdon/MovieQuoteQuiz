using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class View
    {
        public static string strLblQuestioRoundText = "Question null";
        public static string strLblCurrentQuestion = "Movie Quote";
        public static string strlblStatusBar = "Status Bar";

        public static string strRadAnswer1 = "Answer 1";
        public static string strRadAnswer2 = "Answer 2";
        public static string strRadAnswer3 = "Answer 3";

        public static bool isbtnSubmitAnswerActive = true;

        public static void UpdateStatusBar(int intTotalPoints, string strMessage)
        {
            strlblStatusBar = "Points: " + intTotalPoints + " - " + strMessage;
        }

        public static void SetupDefultValues()
        {
            

            strLblQuestioRoundText = "Question 0";
            strLblCurrentQuestion = "Movie Quote";
            strlblStatusBar = "Status Bar";

            strRadAnswer1 = "Answer 1";
            strRadAnswer2 = "Answer 2";
            strRadAnswer3 = "Answer 3";

            isbtnSubmitAnswerActive = true;
        }
    }
}
