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
        public static string strTeststring = "Test text";

        public static string strLblQuestionNumber;
        public static string strLblCurrentQuestion;

        public static string strRadAnswer1;
        public static string strRadAnswer2;
        public static string strRadAnswer3;

        public static void SetupDefultValues()
        {
            SetupQuestions();

            strLblQuestionNumber = "Question 1";
            strLblCurrentQuestion = "Movie Quote";

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

            queListOfQuestions.Add(queQuestion1);
            queListOfQuestions.Add(queQuestion2);
            queListOfQuestions.Add(queQuestion3);
            queListOfQuestions.Add(queQuestion4);
        }


        //public Database()
        //{
        //    //setup defult values
        //    strLblQuestionNumber = "Question 1";
        //    strLblCurrentQuestion = "Movie Quote";

        //    strRadAnswer1 = "Answer 1";
        //    strRadAnswer2 = "Answer 2";
        //    strRadAnswer3 = "Answer 3";

        //}

    }
}
