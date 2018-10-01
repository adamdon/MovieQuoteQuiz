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
        public static List<int> intListOfUsedRadioPositions;

        public static List<Round> rouListOfRounds;

        public static string strPlayerName;
        public static Player plaCurrentPlayer;

        public static int intRoundsTotal;
        public static int intRoundCurrent;
        public static int intCorrectQuestions;
        public static int intTotalPoints;

        public static bool isGameInProgress;

        public Game(string strPlayerNameP, int intRoundsTotalP)
        {
            strPlayerName = strPlayerNameP;


            intRoundsTotal = intRoundsTotalP;
            intRoundCurrent = 0;
            intCorrectQuestions = 0;
            intTotalPoints = (intRoundsTotal * 5);
            isGameInProgress = true;

            rouListOfRounds = new List<Round>();
            intListOfUsedQuestions = new List<int>();
            intListOfUsedAnswers = new List<int>();
            intListOfUsedRadioPositions = new List<int>();

        }

        public void Run()
        {
            plaCurrentPlayer = Player.GetPlayer(strPlayerName);
            SetupRounds();
            PopulateViewWithRound();
            View.PopulateViewWithPlayer(plaCurrentPlayer);
            View.PopulateViewWithScore(intRoundCurrent, intRoundsTotal, intCorrectQuestions, intTotalPoints);

            View.isbtnNewGamebuttonActive = false;
            View.isbtnSubmitAnswerActive = true;
            View.isgruQuizGroupBoxActive = true;

        }


        public void SubmitAnswer(int intSelectedRadio)
        {
          
            if (intSelectedRadio == rouListOfRounds[intRoundCurrent].intCorrectRadio)
            {
                intCorrectQuestions = intCorrectQuestions + 1;
                intTotalPoints = intTotalPoints + 10;
                View.UpdateStatusBar(intTotalPoints, "Correct!");
                PopulateViewWithRound();
            }
            else
            {
                intTotalPoints = intTotalPoints - 5;
                View.UpdateStatusBar(intTotalPoints, "Wrong");
                PopulateViewWithRound();
            }

            if (intRoundCurrent < (intRoundsTotal - 1))
            {
                intRoundCurrent = intRoundCurrent + 1;
            }
            else
            {  
                EndGame();
            }

            View.PopulateViewWithScore(intRoundCurrent, intRoundsTotal, intCorrectQuestions, intTotalPoints);
        }


        public void EndGame()
        {
            plaCurrentPlayer = Player.UpdatePlayer(plaCurrentPlayer, intTotalPoints, intCorrectQuestions, intRoundsTotal);
            View.PopulateViewWithPlayer(plaCurrentPlayer);

            isGameInProgress = false;
            View.UpdateStatusBar(intTotalPoints, "Game End!");
            View.isbtnSubmitAnswerActive = false;
            View.isbtnNewGamebuttonActive = true;
            View.SetupDefultValues();
        }


        public void PopulateViewWithRound()
        {
            if (isGameInProgress == true)
            {
                View.strLblQuestioRoundText = ("Question: " + (intRoundCurrent + 1));
                View.strLblCurrentQuestion = ("\"" + rouListOfRounds[intRoundCurrent].queCurrentQuestion.strQuoteText + "\"");
                View.strRadAnswer1 = GetRadioPositionsOneText();
                View.strRadAnswer2 = GetRadioPositionsTwoText();
                View.strRadAnswer3 = GetRadioPositionsThreeText();
            }
        }


        public void SetupRounds()
        {
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
                rouListOfRounds.Add(rouNewRound);

                intListOfUsedRadioPositions.Clear();
                intListOfUsedAnswers.Clear();
            }
          
        }


        public string GetRadioPositionsOneText()
        {
            if (rouListOfRounds[intRoundCurrent].intCorrectRadio == 1)
            {
                return rouListOfRounds[intRoundCurrent].queCurrentQuestion.strMovieTitle;
            }
            else if (rouListOfRounds[intRoundCurrent].intIncorrectRadio1 == 1)
            {
                return rouListOfRounds[intRoundCurrent].queCurrentWrongAnswer1.strMovieTitle;
            }
            else if (rouListOfRounds[intRoundCurrent].intIncorrectRadio2 == 1)
            {
                return rouListOfRounds[intRoundCurrent].queCurrentWrongAnswer2.strMovieTitle;
            }
            else
            {
                return "Error - no position 1";
            }
        }

        public string GetRadioPositionsTwoText()
        {
            if (rouListOfRounds[intRoundCurrent].intCorrectRadio == 2)
            {
                return rouListOfRounds[intRoundCurrent].queCurrentQuestion.strMovieTitle;
            }
            else if (rouListOfRounds[intRoundCurrent].intIncorrectRadio1 == 2)
            {
                return rouListOfRounds[intRoundCurrent].queCurrentWrongAnswer1.strMovieTitle;
            }
            else if (rouListOfRounds[intRoundCurrent].intIncorrectRadio2 == 2)
            {
                return rouListOfRounds[intRoundCurrent].queCurrentWrongAnswer2.strMovieTitle;
            }
            else
            {
                return "Error - no position 2";
            }
        }

        public string GetRadioPositionsThreeText()
        {
            if (rouListOfRounds[intRoundCurrent].intCorrectRadio == 3)
            {
                return rouListOfRounds[intRoundCurrent].queCurrentQuestion.strMovieTitle;
            }
            else if (rouListOfRounds[intRoundCurrent].intIncorrectRadio1 == 3)
            {
                return rouListOfRounds[intRoundCurrent].queCurrentWrongAnswer1.strMovieTitle;
            }
            else if (rouListOfRounds[intRoundCurrent].intIncorrectRadio2 == 3)
            {
                return rouListOfRounds[intRoundCurrent].queCurrentWrongAnswer2.strMovieTitle;
            }
            else
            {
                return "Error - no position 3";
            }
        }

        public int GetRandomQuestionNumber()
        {

            int intQuestionNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);

            while (intListOfUsedQuestions.Contains(intQuestionNumber))
            {
                intQuestionNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);
            }

            return intQuestionNumber;
        }

        public int GetRandomAnswerNumber()
        {
            int intAnswernNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);

            while (intListOfUsedAnswers.Contains(intAnswernNumber))
            {
                intAnswernNumber = ranRandomNumber.Next(0, Database.queListOfQuestions.Count);
            }

            return intAnswernNumber;
        }

        public int GetRandomRadioPositions()
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
