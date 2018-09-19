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

        public static Game gamCurrentGame;

        public static BinaryWriter binWriteSave;
        public static BinaryReader binReadSave;



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
                binWriteSave.Write(SerializeListToBytes(queListOfQuestionsTemp));
            }
            catch (IOException e)
            {
                View.UpdateStatusBarError("Could not Write to File - " + e.Message.ToString());
            }
            binWriteSave.Close();
        }

        public static void ReadFromSaveFile()
        {
            try
            {
                binReadSave = new BinaryReader(new FileStream("save.db", FileMode.Open));
            }
            catch (IOException e)
            {
                View.UpdateStatusBarError("Could not Open File - " + e.Message.ToString());
            }

            try
            {
                queListOfQuestions = DeserializeListFromBytes(GetArrayOfBytesFromBinaryReader());
            }
            catch (IOException e)
            {
                View.UpdateStatusBarError("Could not read Opened File - " + e.Message.ToString());
            }

            binReadSave.Close();
        }

        public static byte[] GetArrayOfBytesFromBinaryReader()
        {
            //byte[] allData = binReadSave.ReadBytes(int.MaxValue);

            byte[] allData2 = binReadSave.ReadBytes(10000);

            return allData2;
        }

        public static byte[] SerializeListToBytes<List>(List lisListToBeSerialized)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream())
            {
                binFormatter.Serialize(memStream, lisListToBeSerialized);
                memStream.Seek(0, SeekOrigin.Begin);
                return memStream.ToArray();
            }
        }

        public static List<Question> DeserializeListFromBytes(byte[] bytes)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream(bytes))
            {
                try
                {
                    return (List<Question>)binFormatter.Deserialize(memStream);
                }
                catch (IOException e)
                {
                    View.UpdateStatusBarError("Could not Deserialize List From Bytes - " + e.Message.ToString());
                    return (List<Question>)binFormatter.Deserialize(memStream);
                }

                
            }
        }

        public static void SetupQuestions()
        {
            Question queQuestion1 = new Question("Jaws", "We're Gonna Need a Bigger Boat", 0);
            Question queQuestion2 = new Question("Star Wars", "Luke, I am Your Father", 1);
            Question queQuestion3 = new Question("Back to the Future", "Roads? Where we're going, we don't need roads", 2);
            Question queQuestion4 = new Question("Terminator 2", "Hasta la vista, baby", 3);
            Question queQuestion5 = new Question("Lord of the Rings", "You shall not pass", 4);
            Question queQuestion6 = new Question("Toy Story", "To Infinity and Beyond", 5);


            queListOfQuestionsTemp.Add(queQuestion1);
            queListOfQuestionsTemp.Add(queQuestion2);
            queListOfQuestionsTemp.Add(queQuestion3);
            queListOfQuestionsTemp.Add(queQuestion4);
            queListOfQuestionsTemp.Add(queQuestion5);
            queListOfQuestionsTemp.Add(queQuestion6);
        }


    }
}
