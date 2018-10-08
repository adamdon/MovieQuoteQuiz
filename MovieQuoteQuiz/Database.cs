using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Database
    {
        public static List<Question> queListOfQuestions = new List<Question>();
        public static List<Question> queListOfQuestionsTemp = new List<Question>();

        public static List<Player> plaListOfPlayers = new List<Player>();

        public static Game gamCurrentGame;



        public static List<Question> GetDefultQuestions()
        {
            Question queQuestion1 = new Question("Jaws", "We're Gonna Need a Bigger Boat", 0);
            Question queQuestion2 = new Question("Star Wars", "Luke, I am Your Father", 1);
            Question queQuestion3 = new Question("Back to the Future", "Roads? Where we're going, we don't need roads", 2);
            Question queQuestion4 = new Question("Terminator 2", "Hasta la vista, baby", 3);
            Question queQuestion5 = new Question("Lord of the Rings", "You shall not pass", 4);
            Question queQuestion6 = new Question("Toy Story", "To Infinity and Beyond", 5);


            queListOfQuestions.Add(queQuestion1);
            queListOfQuestions.Add(queQuestion2);
            queListOfQuestions.Add(queQuestion3);
            queListOfQuestions.Add(queQuestion4);
            queListOfQuestions.Add(queQuestion5);
            queListOfQuestions.Add(queQuestion6);


            return queListOfQuestions;
        }

        public static List<Player> GetDefultPlayers()
        {
            Player plaTestPlayer1 = new Player("Test1");
            Player plaTestPlayer2 = new Player("Test2");
            Player plaTestPlayer3 = new Player("Test3");

            plaListOfPlayers.Add(plaTestPlayer1);
            plaListOfPlayers.Add(plaTestPlayer2);
            plaListOfPlayers.Add(plaTestPlayer3);

            return plaListOfPlayers;
        }


    }
}
