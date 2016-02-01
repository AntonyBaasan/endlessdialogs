using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessDialogs.ConsoleDemo
{
    class Program
    {
        public static string WebPage = "http://antonybaasan.github.io/endlessdialogs/";

        static void Main(string[] args)
        {
            PlayScene1();
        }

        public static void PlayScene1()
        {
            Console.WriteLine("EndlessDialogs library demonstration");
            Console.WriteLine("----------------------------");


            IScene scene1 = DemoSceneCreator.CreateScene1();
            //IConversation conversation1 = scene1.GetConversations().First();
            //ConversationRunner(conversation1);

            IConversation conversation2 = scene1.GetConversations().Skip(1).ToList().First();
            ConversationRunner(conversation2);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("More: \"" + WebPage + "\"");
            Console.ReadKey();
        }

        public static void ConversationRunner(IConversation conversation)
        {
            IEnumerable<IDialog> currentDialogs = conversation.CurrentDialogs().ToList();

            Console.WriteLine(conversation.GetDescription());
            Console.WriteLine("");
            Console.WriteLine("----------------------------");

            while (currentDialogs.Count() > 0)
            {
                if (currentDialogs.Count() == 1)
                {
                    Console.WriteLine("-" + currentDialogs.First().GetText());
                    Console.ReadKey();
                    conversation.Next();
                }
                else if (currentDialogs.Count() > 1)
                {
                    Console.WriteLine("(Select an answer) 1-"+currentDialogs.Count()+")");
                    int i = 1;
                    foreach (var dialog in currentDialogs)
                    {
                        Console.WriteLine("    "+i+")"+dialog.GetText());
                        i++;
                    }

                    int answer = ReadAnswerNumber(currentDialogs.Count());

                    conversation.Answer(currentDialogs.ToList()[answer-1]);
                }
                
                currentDialogs = conversation.CurrentDialogs();
            }
        }

        private static int ReadAnswerNumber(int maxNumber)
        {
            int res;
            String Result = Console.ReadLine();

            while (!Int32.TryParse(Result, out res) || !(res > 0 && res <= maxNumber))
            {
                Console.WriteLine("Not a valid number, try again.");

                Result = Console.ReadLine();
            }

            return res;

        }
    }
}
