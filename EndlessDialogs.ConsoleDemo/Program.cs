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
            IScene scene = DemoSceneCreator.CreateScene1();
            string fileName = "TestScene.conv";
            PlayScene1(scene, fileName, WebPage, new SceneFileSerializer());


        }

        public static void PlayScene1(IScene scene, string fileName, string webaddress, ISceneSerializer sceneSerializer)
        {
            Console.WriteLine("EndlessDialogs library demonstration");
            Console.WriteLine("----------------------------");

            Console.WriteLine("Example");
            Console.WriteLine("1) Linear conversation");
            Console.WriteLine("2) Branched conversation");
            Console.WriteLine("3) Save Scene");
            Console.WriteLine("4) Load Scene");
            int answer = ReadAnswerNumber(1, 4);

            if (answer == 1)
                ConversationRunner(scene.GetConversations().First());
            else if(answer == 2)
                ConversationRunner(scene.GetConversations().Skip(1).ToList().First());
            else if (answer == 3)
            {
                sceneSerializer.Serialize(scene, fileName);
                Console.WriteLine("Scene saved to file: TestScene.xml");
            }
            else if (answer == 4)
            {
                IScene loadedScene = sceneSerializer.Deserialize(fileName);
                Console.WriteLine("Scene loaded from file: TestScene.xml");
                ConversationRunner(loadedScene.GetConversations().Skip(1).ToList().First());
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("More: \"" + webaddress + "\"");
            Console.ReadKey();
        }

        public static void ConversationRunner(IConversation conversation)
        {
            IEnumerable<IDialog> currentDialogs = conversation.CurrentDialogs().ToList();

            Console.WriteLine(conversation.GetDescription());
            Console.WriteLine("");
            Console.WriteLine("----------------------------");

            while (currentDialogs.Any())
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

                    int answer = ReadAnswerNumber(1, currentDialogs.Count());

                    conversation.Answer(currentDialogs.ToList()[answer-1]);
                }
                
                currentDialogs = conversation.CurrentDialogs();
            }
        }

        private static int ReadAnswerNumber(int minNumber, int maxNumber)
        {
            int res;
            string result = Console.ReadLine();

            while (!int.TryParse(result, out res) || !(res >= minNumber && res <= maxNumber))
            {
                Console.WriteLine("Not a valid number, try again.");

                result = Console.ReadLine();
            }

            return res;

        }
    }
}
