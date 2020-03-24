using System;
using System.IO;

namespace GitDiffConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The following text documents are available for comparison: \nGitRepositories_1a\nGitRepositories_1b\nGitRepositories_2a\nGitRepositories_2b\nGitRepositories_3a\nGitRepositories_3b");
            Console.WriteLine("Please pick the first document to compare");
            //User inputs the first file they want for comparison. This is used to generate the file path stored in fileInput in the readFiles() method.
            string firstFilePath = Console.ReadLine();
            //The returned string is the stored as a local variable in Main().
            string firstFile = ReadFiles.readFiles(firstFilePath);
            Console.WriteLine("Please pick the second document");
            //The same is repeated here for the second file comparison.
            string secondFilePath = Console.ReadLine();
            string secondFile = ReadFiles.readFiles(secondFilePath);
            //The bool from the compareFiles method is returned and stored locally.
            bool filesSame = compareFiles(firstFile, secondFile);
            //If the bool is true, then the files are the same, and the console outputs as such.
            if (filesSame == true)
            {
                Console.WriteLine("The compared files are the same");
            }
            //Otherwise they are different, and the console outputs as such.
            else
            {
                Console.WriteLine("The compared files are not the same");
            }
        }

        //Method for comparing the two text files put in as arguments. Returns a bool.
        static bool compareFiles(string firstFile, string secondFile)
        {
            bool sameFiles;
            //If the arguments are the same, return true.
            if (firstFile == secondFile)
            {
                sameFiles = true;
            }
            //Otherwise, return false.
            else
            {
                sameFiles = false;
            }
            return sameFiles;
        }
    }

    //Class which reads a single file.
    class ReadFiles
    {
        //The method of the class, which actually reads the file.
        public static string readFiles(string fileChoice)
        {
            //Initializes a StreamReader object, a variable instance of the text file. The currently entered file path will be overwritten in the try-catch block.
            StreamReader textObject = new StreamReader(@"textFiles/GitRepositories_1a.txt");
            //Creates a file path for StreamReader to use. Uses the argument fileChoice to select which file.
            string fileInput = $@"textFiles/{fileChoice}.txt";
            //Ensures the while loop runs until a correct file path is found.
            bool fileFound = false;
            while (fileFound == false)
            {
                try
                {
                    //Attempts to create a StreamReader object using the file path created by the argument.
                    textObject = new StreamReader(fileInput);
                    //If successful, will end the while loop. The code does not get to this point if no file is found using the given path.
                    fileFound = true;
                }
                //The catch block is gone into if the file path entered does not find any files.
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Invalid file entered. Please try again.");
                    //The user is asked to re-enter the file they want to select and re-generates the file path using their selection, then performs the while loop again.
                    fileChoice = Console.ReadLine();
                    fileInput = $@"textFiles/{fileChoice}.txt";
                }
            }
            //Reads the entirety of the StreamReader object and converts it into a string object.
            string textFile = textObject.ReadToEnd();
            //The output of the method is a string version of the chosen text file.
            return textFile;
        }
    }
}
