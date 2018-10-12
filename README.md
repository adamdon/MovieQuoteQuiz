# MovieQuoteQuiz
### Multiple Choice Quiz using WPF

 - [Download .exe](https://github.com/adamdon/MovieQuoteQuiz/releases/download/1.0/MovieQuoteQuiz.exe)
 
![Screenshot of UI](https://adamdon.github.io/img/MovieQuoteQuiz_screenshot01.gif)

This side project was done on my own time to learn the WPF/XAML framework in C# and to get more familiar with the .Net technologies in general.

The program provides a simple multiple choice quiz that lets the end user save their performance with the use of a BinaryWriter/Reader in the Interface Class, Generic object Types where used to allow reuse of this class in future projects. The MahApps.Metro tool-kit was utilized to give the design a Metro-style feel. A package called Costura.Fody was installed to embed the .dll files into the .exe as a resources, so the application can be deployed as a single file

I got to use the Model–view–viewmodel for the first time here, I can really see the benefits of this more modulator architectural pattern and I will consider porting this project to other platforms to take advantage of this

```csharp
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
```
 - [View Full Source (github)](https://github.com/adamdon/MovieQuoteQuiz/tree/master/MovieQuoteQuiz)
