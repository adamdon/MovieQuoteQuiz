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

            DEBUGPrintStatisBarWithPlayerArray(Database.plaListOfPlayers);
        }

        public static void SubmitAnswer(int intSelectedRadio)
        {
            Database.gamCurrentGame.SubmitAnswer(intSelectedRadio);
        }

        public static void SetupApplication()
        {
            View.SetupDefultValues();

            Database.queListOfQuestions = Interface.getSave<Question>(Database.GetDefultQuestions());
            Database.plaListOfPlayers = Interface.getSave<Player>(Database.GetDefultPlayers());
        }

        public static  void PlayerNameTextBox_TextChanged(string strPlayerNameFromBox)
        {
            View.PopulateViewWithPlayer(Player.GetPlayerFromList(strPlayerNameFromBox));
        }

        public static void DEBUGPrintStatisBarWithPlayerArray(List<Player> plaListOfPlayers)
        {
            string output = "";
            foreach (Player plaPlayerIndex in plaListOfPlayers)
            {

                output = (output + " " + plaPlayerIndex.strUsername);

            }
            View.UpdateStatusBarError(output);

        }



    }
}
