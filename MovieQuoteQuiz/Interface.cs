using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Interface
    {
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

        public static void WriteToSaveFile(List<object> lstListToBeWritten)
        {
            try
            {
                binWriteSave.Write(SerializeListToBytes(lstListToBeWritten));
            }
            catch (IOException e)
            {
                View.UpdateStatusBarError("Could not Write to File - " + e.Message.ToString());
            }
            binWriteSave.Close();
        }

        //public static List<object> ReadFromSaveFile()
        //{
        //    List<object> lstListToBeRead;

        //    try
        //    {
        //        binReadSave = new BinaryReader(new FileStream("save.db", FileMode.Open));
        //    }
        //    catch (IOException e)
        //    {
        //        View.UpdateStatusBarError("Could not Open File - " + e.Message.ToString());
        //    }

        //    try
        //    {
        //        lstListToBeRead = DeserializeListFromBytes(GetArrayOfBytesFromBinaryReader());
        //    }
        //    catch (IOException e)
        //    {
        //        View.UpdateStatusBarError("Could not read Opened File - " + e.Message.ToString());
        //    }

        //    binReadSave.Close();

        //    return lstListToBeRead;
        //}

        public static byte[] GetArrayOfBytesFromBinaryReader()
        {
            //byte[] allData2 = binReadSave.ReadBytes(10000);
            //return AllData2

            const int intBufferSize = 4096;
            using (MemoryStream memSteamTemp = new MemoryStream())
            {
                byte[] bytBuffer = new byte[intBufferSize];
                int intCount;
                while ((intCount = binReadSave.Read(bytBuffer, 0, bytBuffer.Length)) != 0)
                {
                    memSteamTemp.Write(bytBuffer, 0, intCount);
                }

                return memSteamTemp.ToArray();
            }

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

        public static List<Object> DeserializeListFromBytes(byte[] bytes)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream(bytes))
            {
                try
                {
                    return (List<Object>)binFormatter.Deserialize(memStream);
                }
                catch (IOException e)
                {
                    View.UpdateStatusBarError("Could not Deserialize List From Bytes - " + e.Message.ToString());
                    return (List<Object>)binFormatter.Deserialize(memStream);
                }


            }
        }





    }
}
