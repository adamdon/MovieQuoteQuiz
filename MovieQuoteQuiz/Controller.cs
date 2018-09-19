﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Controller
    {
        public static Random ranRandomNumber = new Random();

        public static void StartNewGame()
        {
            Database.gamCurrentGame = new Game("Player1", Database.queListOfQuestions.Count);
            Database.gamCurrentGame.SetupRounds();
            Database.gamCurrentGame.PopulateViewWithRound();
            View.isbtnNewGamebuttonActive = false;
            View.isbtnSubmitAnswerActive = true;

            Database.MakeSaveFile();
            Database.WriteToSaveFile();
        }

        public static void SubmitAnswer(int intSelectedRadio)
        {
            Database.gamCurrentGame.SubmitAnswer(intSelectedRadio);
            Database.gamCurrentGame.PopulateViewWithRound();
        }



    }
}
