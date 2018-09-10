using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Controller
    {
        public static List<Question> queListOfQuestions = new List<Question>();

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

        public static void PopulateFieldsWithQuestion(Question queCurrentQuestion)
        {
            //MainWindow.
        }


    }
}
