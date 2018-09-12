using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Database
    {
        public static List<Question> queListOfQuestions = new List<Question>();

        public static List<int> intListOfUsedQuestions = new List<int>();
        public static List<int> intListOfUsedAnswers = new List<int>();

        public static Question queCurrentQuestion;

        public static Question queCurrentWrongAnswer1;
        public static Question queCurrentWrongAnswer2;

        public static int intQuestionRountNumber;
        public static string strLblQuestioRoundText;
        public static string strLblCurrentQuestion;
        public static string strlblStatusBar;

        public static string strRadAnswer1;
        public static string strRadAnswer2;
        public static string strRadAnswer3;

        public static void SetupDefultValues()
        {
            SetupQuestions();

            intQuestionRountNumber = 1;

            strLblQuestioRoundText = "Question 1";
            strLblCurrentQuestion = "Movie Quote";
            strlblStatusBar = "Status Bar";

            strRadAnswer1 = "Answer 1";
            strRadAnswer2 = "Answer 2";
            strRadAnswer3 = "Answer 3";
        }

        public static void SetupQuestions()
        {
            Question queQuestion1 = new Question("Jaws", "We're Gonna Need a Bigger Boat", 1);
            Question queQuestion2 = new Question("Star Wars", "Luke, I am Your Father", 2);
            Question queQuestion3 = new Question("Back to the Future", "Roads? Where we're going, we don't need roads", 3);
            Question queQuestion4 = new Question("Terminator 2", "Hasta la vista, baby", 4);
            Question queQuestion5 = new Question("Lord of the Rings", "You shall not pass", 5);
            Question queQuestion6 = new Question("Toy Story", "To Infinity and Beyond", 6);


            queListOfQuestions.Add(queQuestion1);
            queListOfQuestions.Add(queQuestion2);
            queListOfQuestions.Add(queQuestion3);
            queListOfQuestions.Add(queQuestion4);
        }


    }
}
