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


        public static void PopulateFieldsWithQuestion()   //(Question queCurrentQuestion)
        {
            Database.queCurrentQuestion = Database.queListOfQuestions[GetRandomQuestionNumber()];
            UpdateQuestionsUsed(Database.queListOfQuestions.IndexOf(Database.queCurrentQuestion));
            UpdateAnswersUsed(Database.queListOfQuestions.IndexOf(Database.queCurrentQuestion));

            Database.queCurrentWrongAnswer1 = Database.queListOfQuestions[GetRandomAnswerNumber()];
            UpdateAnswersUsed(Database.queListOfQuestions.IndexOf(Database.queCurrentWrongAnswer1));

            Database.queCurrentWrongAnswer2 = Database.queListOfQuestions[GetRandomAnswerNumber()];
            UpdateAnswersUsed(Database.queListOfQuestions.IndexOf(Database.queCurrentWrongAnswer2));


            Database.strLblCurrentQuestion = Database.queCurrentQuestion.strQuoteText;
            Database.strRadAnswer1 = Database.queCurrentWrongAnswer1.strMovieTitle;
            Database.strRadAnswer2 = Database.queCurrentWrongAnswer2.strMovieTitle;
            Database.strRadAnswer3 = Database.queCurrentQuestion.strMovieTitle;


            Database.intListOfUsedAnswers.Clear();
        }

        public static int GetRandomQuestionNumber()
        {
            
            int intQuestionNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);

            while (Database.intListOfUsedQuestions.Contains(intQuestionNumber))
            {
                intQuestionNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);
            }

            return intQuestionNumber;
        }

        public static int GetRandomAnswerNumber()
        {
            int intAnswernNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);

            while (Database.intListOfUsedAnswers.Contains(intAnswernNumber))
            {
                intAnswernNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);
            }

            return intAnswernNumber;
        }



        public static void UpdateQuestionsUsed(int intQuestionUsed)
        {
            Database.intListOfUsedQuestions.Add(intQuestionUsed);
        }

        public static void UpdateAnswersUsed(int intAnswerUsed)
        {
            Database.intListOfUsedAnswers.Add(intAnswerUsed);
        }

        public static void UpdateStatusBar(String strUpdateText)
        {
            Database.strlblStatusBar = strUpdateText;
        }


    }
}
