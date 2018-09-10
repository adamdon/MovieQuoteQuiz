using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Controller
    {

        public static void PopulateFieldsWithQuestion()   //(Question queCurrentQuestion)
        {
            int intQuestionNumber = GetQuestionNumber();

            Database.strLblCurrentQuestion = Database.queListOfQuestions[intQuestionNumber].strQuoteText;
            Database.strRadAnswer1 = Database.queListOfQuestions[1].strMovieTitle;
            Database.strRadAnswer2 = Database.queListOfQuestions[2].strMovieTitle;
            Database.strRadAnswer3 = Database.queListOfQuestions[intQuestionNumber].strMovieTitle;
        }

        public static int GetQuestionNumber()
        {
            int intQuestionNumber = 0;
            Random ranRandomNumber = new Random();
            intQuestionNumber = ranRandomNumber.Next(0, 3);

            return intQuestionNumber;
        }


    }
}
