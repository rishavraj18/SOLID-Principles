using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Principles
{
    // Following the Liskov Substitution Principle
    public interface IFileReader
    {
        void ReadFile(string filePath);
    }

    public interface IFileWriter
    {
        void WriteFile(string filePath);
    }

    public class AdminDataFileUserFixed : IFileReader, IFileWriter
    {
        public void ReadFile(string filePath)
        {
            // Read File logic
            Console.WriteLine($"File {filePath} has been read");
        }

        public void WriteFile(string filePath)
        {
            //Write File Logic
            Console.WriteLine($"File {filePath} has been written");
        }
    }

    public class RegularDataFileUserFixed : IFileReader
    {
        public void ReadFile(string filePath)
        {
            // Read File logic
            Console.WriteLine($"File {filePath} has been read");
        }
    }

    //Calling class following Liskov Substitution Principle
    public class LSP
    {
        public void LSPMethod()
        {
            IFileReader fileReader = new AdminDataFileUserFixed();
            fileReader.ReadFile(@"c:\temp\a.txt");

            IFileWriter fileWriter = new AdminDataFileUserFixed();
            fileWriter.WriteFile(@"c:\temp\a.txt");

            IFileReader fileReaderR = new RegularDataFileUserFixed();
            fileReaderR.ReadFile(@"c:\temp\a.txt");
        }
    }
}
