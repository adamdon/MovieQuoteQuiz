using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Controller
    {
        

        public static void StartNewGame(string strPlayerName, int intRoundsTotal)
        {
            Database.gamCurrentGame = new Game(strPlayerName, intRoundsTotal);
            Database.gamCurrentGame.Run();

            DEBUGPrintStatisBarWithPlayerArray();
        }

        public static void SubmitAnswer(int intSelectedRadio)
        {
            Database.gamCurrentGame.SubmitAnswer(intSelectedRadio);
        }

        public static void SetupApplication()
        {
            View.SetupDefultValues();

            Database.SetupQuestions();

            Database.MakeSaveFile();
            Database.WriteToSaveFile();
            Database.ReadFromSaveFile();
        }

        public static  void PlayerNameTextBox_TextChanged(string strPlayerNameFromBox)
        {
            View.PopulateViewWithPlayer(Player.GetPlayerFromList(strPlayerNameFromBox));
        }

        public static void DEBUGPrintStatisBarWithPlayerArray()
        {
            string output = "";
            foreach (Player plaPlayerIndex in Database.plaListOfPlayers)
            {

                output = (output + " " + plaPlayerIndex.strUsername);

            }
            View.UpdateStatusBarError(output);
           
        }



    }
}
