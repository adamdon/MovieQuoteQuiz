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


        public static List<T> getSave<T>(List<T> lisDefultList)
        {
            if (IsFilePresent<T>() == true)
            {
                return ReadFromSaveFile<T>();
            }
            else
            {
                MakeSaveFile<T>();
                WriteToSaveFile<T>(lisDefultList);
                return ReadFromSaveFile<T>();
            }
        }

        public static void setSave<T>(List<T> lisToBeWrittenList)
        {
            if (IsFilePresent<T>() == true)
            {
                WriteToSaveFile<T>(lisToBeWrittenList);
            }
            else
            {
                //
            }
        }

        public static bool IsFilePresent<T>()
        {
            string strSaveFileTypeName = (typeof(T).FullName + "Save.db");

            if (File.Exists(strSaveFileTypeName))
            {
                return true;
            }
            return false;
        }


        public static void MakeSaveFile<T>()
        {
            string strSaveFileTypeName = (typeof(T).FullName + "Save.db");

            try
            {
                binWriteSave = new BinaryWriter(new FileStream(strSaveFileTypeName, FileMode.Create));
            }
            catch (IOException e)
            {
                View.UpdateStatusBarError("Could not Create File - " + e.Message.ToString());
            }
        }

        public static void WriteToSaveFile<T>(List<T> lstListToBeWritten)
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


        public static List<T> ReadFromSaveFile<T>()
        {

            List<T> lisListToBeRead = new List<T>();
            string strSaveFileTypeName = (typeof(T).FullName + "Save.db");

            Type mytype = typeof(T);
            try
            {
                binReadSave = new BinaryReader(new FileStream(strSaveFileTypeName, FileMode.Open));
            }
            catch (IOException e)
            {
                View.UpdateStatusBarError("Could not Open File - " + e.Message.ToString());
            }

            try
            {
                lisListToBeRead = DeserializeListFromBytes<T>(GetArrayOfBytesFromBinaryReader());
            }
            catch (IOException e)
            {
                View.UpdateStatusBarError("Could not read Opened File - " + e.Message.ToString());
            }

            binReadSave.Close();

            return lisListToBeRead;
        }

        public static byte[] GetArrayOfBytesFromBinaryReader()
        {

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

        public static List<T> DeserializeListFromBytes<T>(byte[] bytes)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream(bytes))
            {
                try
                {
                    return (List<T>)binFormatter.Deserialize(memStream);
                }
                catch (IOException e)
                {
                    View.UpdateStatusBarError("Could not Deserialize List From Bytes - " + e.Message.ToString());
                    return (List<T>)binFormatter.Deserialize(memStream);
                }


            }
        }





    }
}
