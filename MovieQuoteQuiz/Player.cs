using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    [Serializable]
    class Player
    {
        public string strUsername { get; set; }
        public int intTotalRoundsPlayed { get; set; }
        public int intTotalCorrectQuestions { get; set; }
        public int intintTotalPointsAllGames { get; set; }

        public Player(string strUsernameP)
        {
            strUsername = strUsernameP;
            intTotalRoundsPlayed = 0;
            intTotalCorrectQuestions = 0;
            intintTotalPointsAllGames = 0;
        }

        public override string ToString()
        {
            return this.strUsername;
        }

        public static Player GetPlayer(string strPlayerNameTemp)
        {
            Player plaCurrentPlayer;

            if (IsPlayerNew(strPlayerNameTemp) == true)
            {
                plaCurrentPlayer = new Player(strPlayerNameTemp);
                Database.plaListOfPlayers.Add(plaCurrentPlayer);
            }
            else
            {
                plaCurrentPlayer = Player.GetPlayerFromList(strPlayerNameTemp);
            }

            return plaCurrentPlayer;
        }

        public static bool IsPlayerNew(string strPlayerNameTemp)
        {
            foreach (Player plaPlayerIndex in Database.plaListOfPlayers)
            {
                if (plaPlayerIndex.strUsername == strPlayerNameTemp)
                {
                    View.UpdateStatusBarError("Player " + strPlayerNameTemp + " not new");
                    return false;
                }
            }
            View.UpdateStatusBarError("Player " + strPlayerNameTemp + " added to db");
            return true;
        }

        public static Player GetPlayerFromList(string strPlayerNameTemp)
        {
            foreach (Player plaPlayerIndex in Database.plaListOfPlayers)
            {
                if (plaPlayerIndex.strUsername == strPlayerNameTemp)
                {
                    View.UpdateStatusBarError("Player " + strPlayerNameTemp + " not new");
                    return plaPlayerIndex;
                }
            }
            return new Player("Error");
        }

        public static int GetPlayerIndexOfList(string strPlayerNameTemp)
        {
            int intIndexOfPlayerItem = 0;

            foreach (Player plaPlayerIndex in Database.plaListOfPlayers)
            {
                if (plaPlayerIndex.strUsername == strPlayerNameTemp)
                {
                    intIndexOfPlayerItem = Database.plaListOfPlayers.IndexOf(plaPlayerIndex);
                    return intIndexOfPlayerItem;
                }
            }
            return intIndexOfPlayerItem;
        }

        public static Player UpdatePlayer(Player plaPlayerToBeUpdated, int intTotalPoints, int intCorrectQuestions, int intRoundsTotal, string strPlayerName)
        {
            plaPlayerToBeUpdated.intintTotalPointsAllGames = (plaPlayerToBeUpdated.intintTotalPointsAllGames + intTotalPoints);
            plaPlayerToBeUpdated.intTotalCorrectQuestions = (plaPlayerToBeUpdated.intTotalCorrectQuestions + intCorrectQuestions);
            plaPlayerToBeUpdated.intTotalRoundsPlayed = (plaPlayerToBeUpdated.intTotalRoundsPlayed + intRoundsTotal);

            int intIndexOfPlayerItem = GetPlayerIndexOfList(strPlayerName);

            Database.plaListOfPlayers[intIndexOfPlayerItem] = plaPlayerToBeUpdated; //to be removed when interface is in place
            Interface.MakeSaveFile<Player>();
            Interface.setSave<Player>(Database.plaListOfPlayers);

            return plaPlayerToBeUpdated;
        }

    }
}
