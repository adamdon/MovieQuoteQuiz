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
            Question queQuestion6 = new Question("The Shining", "Heeere's Johnny!", 5);
            Question queQuestion7 = new Question("Scarface", "Say 'hello' to my little friend", 6);
            Question queQuestion8 = new Question("Forest Gump", "Life is like a box of chocolates", 7);
            Question queQuestion9 = new Question("The Dark Knight", "Why so serious?", 8);
            Question queQuestion10 = new Question("The Wizard of Oz", "There's no place like home", 9);
            Question queQuestion11 = new Question("Harry Potter", "Yer a wizard, Harry", 10);
            Question queQuestion12 = new Question("Saw", "Wanna play a game?", 11);


            queListOfQuestions.Add(queQuestion1);
            queListOfQuestions.Add(queQuestion2);
            queListOfQuestions.Add(queQuestion3);
            queListOfQuestions.Add(queQuestion4);
            queListOfQuestions.Add(queQuestion5);
            queListOfQuestions.Add(queQuestion6);
            queListOfQuestions.Add(queQuestion7);
            queListOfQuestions.Add(queQuestion8);
            queListOfQuestions.Add(queQuestion9);
            queListOfQuestions.Add(queQuestion10);
            queListOfQuestions.Add(queQuestion11);
            queListOfQuestions.Add(queQuestion12);


            return queListOfQuestions;
        }

        public static List<Player> GetDefultPlayers()
        {
            Player plaTestPlayer1 = new Player("Frodo", 50, 30, 430);
            Player plaTestPlayer2 = new Player("Bilbo", 40, 20, 310);
            Player plaTestPlayer3 = new Player("Samwise", 10, 4, 280);

            plaListOfPlayers.Add(plaTestPlayer1);
            plaListOfPlayers.Add(plaTestPlayer2);
            plaListOfPlayers.Add(plaTestPlayer3);

            return plaListOfPlayers;
        }


    }
}
