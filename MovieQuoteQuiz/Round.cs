using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Round
    {
        public Question queCurrentQuestion { get; set; }

        public Question queCurrentWrongAnswer1 { get; set; }
        public Question queCurrentWrongAnswer2 { get; set; }

        public int intRoundNumber { get; set; }

        public int intSelectedRadio { get; set; }

        public int intCorrectRadio { get; set; }
        public int intIncorrectRadio1 { get; set; }
        public int intIncorrectRadio2 { get; set; }

        private static Random ranRandomNumber = new Random();
        private static List<int> intListOfUsedQuestions = new List<int>();
        private static List<int> intListOfUsedAnswers = new List<int>();
        private static List<int> intListOfUsedRadioPositions = new List<int>();


        public Round(Question queCurrentQuestionP, Question queCurrentWrongAnswer1P, Question queCurrentWrongAnswer2P, int intCorrectRadioP, int intIncorrectRadio1P, int intIncorrectRadio2P, int intRoundNumberP)
        {
            queCurrentQuestion = queCurrentQuestionP;
            queCurrentWrongAnswer1 = queCurrentWrongAnswer1P;
            queCurrentWrongAnswer2 = queCurrentWrongAnswer2P;
            
            intCorrectRadio = intCorrectRadioP;
            intIncorrectRadio1 = intIncorrectRadio1P;
            intIncorrectRadio2 = intIncorrectRadio2P;

            intRoundNumber = intRoundNumberP;
        }


        public static List<Round> SetupRounds(int intRoundsTotal)
        {
            List<Round> CurrentListOfRounds = new List<Round>();

            for (int index = 0; index < intRoundsTotal; index++)
            {
                Question queCurrentQuestion = Database.queListOfQuestions[GetRandomQuestionNumber()];
                intListOfUsedAnswers.Add(Database.queListOfQuestions.IndexOf(queCurrentQuestion));
                intListOfUsedQuestions.Add(Database.queListOfQuestions.IndexOf(queCurrentQuestion));

                Question queCurrentWrongAnswer1 = Database.queListOfQuestions[GetRandomAnswerNumber()];
                intListOfUsedAnswers.Add(Database.queListOfQuestions.IndexOf(queCurrentWrongAnswer1));

                Question queCurrentWrongAnswer2 = Database.queListOfQuestions[GetRandomAnswerNumber()];
                intListOfUsedAnswers.Add(Database.queListOfQuestions.IndexOf(queCurrentWrongAnswer2));

                int intCorrectRadio = GetRandomRadioPositions();
                intListOfUsedRadioPositions.Add(intCorrectRadio);

                int intIncorrectRadio1 = GetRandomRadioPositions();
                intListOfUsedRadioPositions.Add(intIncorrectRadio1);

                int intIncorrectRadio2 = GetRandomRadioPositions();
                intListOfUsedRadioPositions.Add(intIncorrectRadio2);


                Round rouNewRound = new Round(queCurrentQuestion, queCurrentWrongAnswer1, queCurrentWrongAnswer2, intCorrectRadio, intIncorrectRadio1, intIncorrectRadio2, index);
                CurrentListOfRounds.Add(rouNewRound);

                intListOfUsedRadioPositions.Clear();
                intListOfUsedAnswers.Clear();
            }

            intListOfUsedQuestions.Clear();

            return CurrentListOfRounds;
        }


        public static string GetRadioPositionsText(List<Round> CurrentListOfRounds, int intRoundCurrent, int intRadioPosition)
        {
            if (CurrentListOfRounds[intRoundCurrent].intCorrectRadio == intRadioPosition)
            {
                return CurrentListOfRounds[intRoundCurrent].queCurrentQuestion.strMovieTitle;
            }
            else if (CurrentListOfRounds[intRoundCurrent].intIncorrectRadio1 == intRadioPosition)
            {
                return CurrentListOfRounds[intRoundCurrent].queCurrentWrongAnswer1.strMovieTitle;
            }
            else if (CurrentListOfRounds[intRoundCurrent].intIncorrectRadio2 == intRadioPosition)
            {
                return CurrentListOfRounds[intRoundCurrent].queCurrentWrongAnswer2.strMovieTitle;
            }
            else
            {
                return ("Error - no position " + intRadioPosition + " found");
            }
        }

        public static int GetRandomQuestionNumber()
        {

            int intQuestionNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);

            while (intListOfUsedQuestions.Contains(intQuestionNumber))
            {
                intQuestionNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);
            }

            return intQuestionNumber;
        }

        public static int GetRandomAnswerNumber()
        {
            int intAnswernNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);

            while (intListOfUsedAnswers.Contains(intAnswernNumber))
            {
                intAnswernNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);
            }

            return intAnswernNumber;
        }

        public static int GetRandomRadioPositions()
        {
            int intRadioPositions = ranRandomNumber.Next(1, 4);

            while (intListOfUsedRadioPositions.Contains(intRadioPositions))
            {
                intRadioPositions = ranRandomNumber.Next(1, 4);
            }

            return intRadioPositions;
        }

    }
}
