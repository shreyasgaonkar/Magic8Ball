using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Magic8Ball
{
    class Program
    {
        static void Main(string[] args)
        {
            //Preserve current text color            
            ConsoleColor oldColor = Console.ForegroundColor;

            TellPeopleWhatProgramThisIs();

            Random randomObject = new Random();
            Console.WriteLine("{0}", randomObject.Next(10) + 1);

            while (true)
            {
                string questionString = GetQuestionFromUser();

                int numberOfSecondsToSleep = randomObject.Next(5) + 1;
                Console.WriteLine("Thinking about the answer, standby..");
                Thread.Sleep(numberOfSecondsToSleep * 1000);

                if (questionString.Length == 0)
                {
                    Console.WriteLine("You need to write a question");
                    continue;
                }

                //See if the user types quit as question
                if (questionString.ToLower() == "quit" || questionString.ToLower() == "exit")
                {
                    break;
                }

                //If the user insults with you suck, do this
                if (questionString.ToLower() == "you suck")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You suck even more, Bye!");
                    break;
                }

                //Get a random number 
                int randomNumber = randomObject.Next(4);
                Console.ForegroundColor = (ConsoleColor)randomNumber;

                //Use random number to determine the response
                switch (randomNumber)
                {
                    case 0:
                        {
                            Console.WriteLine("YES!");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("NO!");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("HELL NO!");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("OMG YES!");
                            break;
                        }
                }//end Switch
            }

            //Cleaning up  
            Console.ForegroundColor = oldColor;
        }

        
        
        
            //function declarations

        /// <summary>
        /// This will print the name of the program and who created it
        /// </summary>
        static void TellPeopleWhatProgramThisIs()
        {
            //Change console text color
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Magic 8Ball (by: Shreyas)");
        }

        /// <summary>
        /// This function with return the text the user types
        /// </summary>
        static string GetQuestionFromUser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ask a Question?: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string questionString = Console.ReadLine();

            return questionString;
        }
    }
}
