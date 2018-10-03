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

        public static string strlblPlayerName = "Name";
        public static string strlblPercentageCorrect = "00%";
        public static string strlblTotalPoints = "0";

        public static string strRadAnswer1 = "Answer 1";
        public static string strRadAnswer2 = "Answer 2";
        public static string strRadAnswer3 = "Answer 3";

        public static bool isRadAnswer1Selected = false;
        public static bool isRadAnswer2Selected = false;
        public static bool isRadAnswer3Selected = false;

        public static bool isbtnSubmitAnswerActive = false;
        public static bool isbtnNewGamebuttonActive = true;

        public static bool iscmbPlayerNameTextBoxtActive = true;
        public static bool iscmbRoundsAmountActive = true;

        public static bool isgruQuizGroupBoxActive = false;
        public static bool isgruScoreGroupBoxActive = false;

        public static void PopulateViewWithPlayer(Player plaPlayerToPopulate)
        {
            double dubPercentageCorrect = (((double)plaPlayerToPopulate.intTotalCorrectQuestions / (double)plaPlayerToPopulate.intTotalRoundsPlayed) * 100);
            dubPercentageCorrect = Math.Round(dubPercentageCorrect, 2);
            if (Double.IsNaN(dubPercentageCorrect))
            {
                dubPercentageCorrect = 0;
            }

            View.strlblPlayerName = plaPlayerToPopulate.strUsername;
            View.strlblPercentageCorrect = (dubPercentageCorrect.ToString() + "%");
            View.strlblTotalPoints = plaPlayerToPopulate.intintTotalPointsAllGames.ToString();
        }

        public static void PopulateViewWithScore(int intRoundCurrent, int intRoundsTotal, int intCorrectQuestions, int intTotalPoints)
        {
            View.strlblCurrentRound = ((intRoundCurrent + 1) + "/" + intRoundsTotal);
            View.strlblCorrectAnswers = intCorrectQuestions.ToString();
            View.strlblGamePoints = intTotalPoints.ToString();
        }

        public static void PopulateViewWithRound(List<Round> CurrentListOfRounds, int intRoundCurrent, bool isGameInProgress)
        {
            if (isGameInProgress == true)
            {
                View.strLblQuestioRoundText = ("Question: " + (intRoundCurrent + 1));
                View.strLblCurrentQuestion = ("\"" + CurrentListOfRounds[intRoundCurrent].queCurrentQuestion.strQuoteText + "\"");

                View.strRadAnswer1 = Round.GetRadioPositionsText(CurrentListOfRounds, intRoundCurrent, 1);
                View.strRadAnswer2 = Round.GetRadioPositionsText(CurrentListOfRounds, intRoundCurrent, 2);
                View.strRadAnswer3 = Round.GetRadioPositionsText(CurrentListOfRounds, intRoundCurrent, 3);
            }
        }

        public static void ActivateGameStateInView(bool isGameInProgress)
        {
            if (isGameInProgress == true)
            {
                View.isbtnNewGamebuttonActive = false;
                View.iscmbPlayerNameTextBoxtActive = false;
                View.iscmbRoundsAmountActive = false;
                View.isbtnSubmitAnswerActive = true;
                View.isgruQuizGroupBoxActive = true;
                View.isgruScoreGroupBoxActive = true;
            }
            else
            {
                View.isbtnNewGamebuttonActive = true;
                View.iscmbPlayerNameTextBoxtActive = true;
                View.iscmbRoundsAmountActive = true;
                View.isbtnSubmitAnswerActive = false;
                View.isgruQuizGroupBoxActive = false;
                View.isgruScoreGroupBoxActive = false;
            }
        }

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

            //strlblPlayerName = "Name";
            //strlblPercentageCorrect = "00%";
            //strlblTotalPoints = "0";

            strRadAnswer1 = "Answer 1";
            strRadAnswer2 = "Answer 2";
            strRadAnswer3 = "Answer 3";

            isRadAnswer1Selected = false;
            isRadAnswer2Selected = false;
            isRadAnswer3Selected = false;

            isbtnSubmitAnswerActive = false;
            isbtnNewGamebuttonActive = true;
            isgruQuizGroupBoxActive = false;
            isgruScoreGroupBoxActive = false;
            iscmbPlayerNameTextBoxtActive = true;
            iscmbRoundsAmountActive = true;
        }
    }
}
