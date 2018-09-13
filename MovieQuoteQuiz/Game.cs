using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Game
    {
        public static Random ranRandomNumber = new Random();

        public static List<int> intListOfUsedQuestions; // = new List<int>();
        public static List<int> intListOfUsedAnswers; // = new List<int>();

        public static List<Round> rouListOfRounds = new List<Round>();

        public static string strPlayerName;
        public static int intRoundsTotal;
        public static int intRoundCurrent;
        public static int intCorrectQuestions;
        public static int intTotalPoints;

        public Game(string strPlayerNameP, int intRoundsTotalP)
        {
            strPlayerName = strPlayerNameP;
            intRoundsTotal = intRoundsTotalP;
            intRoundCurrent = 0;
            intCorrectQuestions = 0;
            intTotalPoints = 0;

            intListOfUsedQuestions = new List<int>();
            intListOfUsedAnswers = new List<int>();
        }

        public void SetupRounds()
        {
            for (int index = 0; index < intRoundsTotal; index++)
            {
                Question queCurrentQuestion = Database.queListOfQuestions[GetRandomQuestionNumber()];
                Database.intListOfUsedAnswers.Add(Database.queListOfQuestions.IndexOf(queCurrentQuestion));
                Database.intListOfUsedQuestions.Add(Database.queListOfQuestions.IndexOf(queCurrentQuestion));

                Question queCurrentWrongAnswer1 = Database.queListOfQuestions[GetRandomAnswerNumber()];
                Database.intListOfUsedAnswers.Add(Database.queListOfQuestions.IndexOf(queCurrentWrongAnswer1));

                Question queCurrentWrongAnswer2 = Database.queListOfQuestions[GetRandomAnswerNumber()];
                Database.intListOfUsedAnswers.Add(Database.queListOfQuestions.IndexOf(queCurrentWrongAnswer2));

                Round rouNewRound = new Round(queCurrentQuestion, queCurrentWrongAnswer1, queCurrentWrongAnswer2, index);
                rouListOfRounds.Add(rouNewRound);

                Database.intListOfUsedAnswers.Clear();
            }
          
        }

        public void PopulateViewWithRound()
        {
            View.strLblQuestioRoundText = ("Question: " + (intRoundCurrent + 1));
            View.strLblCurrentQuestion = rouListOfRounds[intRoundCurrent].queCurrentQuestion.strQuoteText;
            View.strRadAnswer1 = rouListOfRounds[intRoundCurrent].queCurrentWrongAnswer1.strMovieTitle;
            View.strRadAnswer2 = rouListOfRounds[intRoundCurrent].queCurrentWrongAnswer2.strMovieTitle;
            View.strRadAnswer3 = rouListOfRounds[intRoundCurrent].queCurrentQuestion.strMovieTitle;
        }

 

        public int GetRandomQuestionNumber()
        {

            int intQuestionNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);

            while (Database.intListOfUsedQuestions.Contains(intQuestionNumber))
            {
                intQuestionNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);
            }

            return intQuestionNumber;
        }

        public int GetRandomAnswerNumber()
        {
            int intAnswernNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);

            while (Database.intListOfUsedAnswers.Contains(intAnswernNumber))
            {
                intAnswernNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);
            }

            return intAnswernNumber;
        }



        //public static void UpdateQuestionsUsed(int intQuestionUsed)
        //{
        //    Database.intListOfUsedQuestions.Add(intQuestionUsed);
        //}

        //public static void UpdateAnswersUsed(int intAnswerUsed)
        //{
        //    Database.intListOfUsedAnswers.Add(intAnswerUsed);
        //}

    }
}
