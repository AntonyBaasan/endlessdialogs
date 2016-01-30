namespace EndlessDialogs.ConsoleDemo
{
    class DemoSceneCreator
    {
        public static IScene CreateScene1()
        {

            IScene resultScene = new Scene();
            resultScene.AddConversation(Conversation1());
            resultScene.AddConversation(Conversation2Branched());

            return resultScene;
        }

        public static IConversation Conversation1()
        {
            //Create dialogs
            IDialog dialog1 = new Dialog("Hello. What is your name");
            IDialog dialog2 = new Dialog("Hello. My name is \"EndlessDialogs\"");
            IDialog dialog3 = new Dialog("What are you you?");
            IDialog dialog4 = new Dialog("I am a software library that help developers to make conversation system.");
            IDialog dialog5 = new Dialog("Got you.");

            //Create dialog connections. In this case it is linear conversation
            dialog1.AddNext(new[] { dialog2 });
            dialog2.AddNext(new[] { dialog3 });
            dialog3.AddNext(new[] { dialog4 });
            dialog4.AddNext(new[] { dialog5 });

            //Create a conversation
            IConversation conversation1 = new Conversation();
            conversation1.SetName("Conversation 1");
            conversation1.SetDescription("Demo: Scene1 - Conversation1 ('DemoSceneCreator.cs' - 'CreateScene1()')");
            conversation1.SetStartDialog(new[] { dialog1 });

            return conversation1;
        }

        public static IConversation Conversation2Branched()
        {
            //Create dialogs
            IDialog dialog1 = new Dialog("Hello. What is your name?");
            IDialog dialogAnwer1 = new Dialog("My name is Player1");
            IDialog dialogAnwer2 = new Dialog("My name is Player2");
            IDialog dialogAnwer3 = new Dialog("My name is Player3");

            IDialog dialog2 = new Dialog("Nice to meet you Player1");
            IDialog dialog3 = new Dialog("Nice to meet you Player2");
            IDialog dialog4 = new Dialog("Nice to meet you Player3");

            IDialog dialog5 = new Dialog("I am a software library that help developers to make conversation system.");
            IDialog dialog6 = new Dialog("Got you.");

            //Create dialog connections. In this case it is linear conversation
            dialog1.AddNext(new[] { dialogAnwer1, dialogAnwer2, dialogAnwer3 });

            dialogAnwer1.AddNext(new[] { dialog2 });
            dialogAnwer2.AddNext(new[] { dialog3 });
            dialogAnwer3.AddNext(new[] { dialog4 });

            //Create a conversation
            IConversation conversation1 = new Conversation();
            conversation1.SetName("Conversation 2 (Branched)");
            conversation1.SetDescription("Demo: Scene1 - Conversation2 ('DemoSceneCreator.cs' - 'CreateScene2()')");
            conversation1.SetStartDialog(new[] { dialog1 });

            return conversation1;
        }

    }
}
