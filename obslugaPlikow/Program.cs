using System;
using System.IO;

namespace obslugaPlikow
{
    class Program
    {
        static string toGuess()
        {

        }


        static void Main(string[] args)
        {
            var ab = "abc";
            var bc = "abc";
            if (ab==bc)
            { Console.WriteLine("Sukces"); }
            //Console.WriteLine("Hello World!");
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var filename = Path.Combine(directory.FullName, "countries_and_capitals.txt");
            var file = new FileInfo(filename);
            //Console.Write(filename);
            if (file.Exists)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    //Console.SetIn(reader);
                    //Console.WriteLine(Console.ReadLine());
                    var fileContent = reader.ReadToEnd();
                    Console.WriteLine(fileContent);
                }
                   
            }


        }
    }
}
