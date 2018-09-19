using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Database
    {
        public static List<Question> queListOfQuestions = new List<Question>();
        public static Game gamCurrentGame;

        public static BinaryWriter binWriteSave; 



        public static void MakeSaveFile()
        {
            try
            {
                binWriteSave = new BinaryWriter(new FileStream("save.db", FileMode.Create));
            }
            catch (IOException e)
            {
                View.UpdateStatusBarError("Could not Create File - " + e.Message.ToString());
            }
        }

        public static void WriteToSaveFile()
        {
            try
            {
                binWriteSave.Write("Test text");

            }
            catch (IOException e)
            {
                View.UpdateStatusBarError("Could not Write to File - " + e.Message.ToString());
                return;
            }
            binWriteSave.Close();
        }

        public static void SetupQuestions()
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
        }


    }
}
