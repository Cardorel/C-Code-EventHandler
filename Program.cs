using System;

namespace CSharp1
{
   public class Container: EventArgs
   {
      public string letter;
   }


   class EventClass
   {
       public event EventHandler <Container> allEvent;
       public event EventHandler <Container> colorA;
       public event EventHandler <Container> handlerEventColorB;

       public void start(string let)
       {
           Container myCont = new Container();
           myCont.letter = let;

           allEvent.Invoke(this , myCont);
       }

       public void startColorA(string color)
       {
           Container myCont = new Container();
           myCont.letter = color;

           colorA.Invoke(this , myCont);
       }

       public void startColorB(string color_B)
       {
           Container myCont = new Container();
           myCont.letter = color_B;

           handlerEventColorB.Invoke(this , myCont);
       }
   }

    class Program
    {
        static void Handler_A(object sender , Container e)
        {
            if(e.letter == "a")
            {
               Console.WriteLine("I am A");
               Console.WriteLine("Entrer la couleur du A...");
               string color = Console.ReadLine();
               
               EventClass evClass = (EventClass)sender;
               evClass.startColorA(color);

            }
            else{
                   Console.WriteLine("C est pas moi A!");
               }
        }

        static void Handler_B(object sender , Container e)
        {
            if(e.letter == "b")
            {
               Console.WriteLine("I am B");
               Console.WriteLine("Entrer la couleur du B...");
               string color1 = Console.ReadLine();

               EventClass myEventColorB = (EventClass)sender;
               myEventColorB.startColorB(color1);
            }
            else{
                   Console.WriteLine("C est pas moi B!");
               }
        }

        static void HandlerColorA_colorBlue(object sender , Container e)
        {
            if(e.letter == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("AAAAAAAAAA");
            }
        }

        static void HandlerColorA_colorGreen(object sender , Container e)
        {
            if(e.letter == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*********   **********   *********");
                Console.WriteLine("*           *        *   *        *");
                Console.WriteLine("*           *        *   *        *");
                Console.WriteLine("*           *        *   *        *");
                Console.WriteLine("*           * ****** *   ***************");
                Console.WriteLine("*           *        *   *             *");
                Console.WriteLine("*           *        *   *             *");
                Console.WriteLine("*********   *        *   *             *");
            }
        }

        static void HandlerColorB_colorRed(object sender , Container e)
        {
            if(e.letter == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("AAAAAAA");
            }
        }

        static void HandlerColorB_colorwhite(object sender , Container e)
        {
            if(e.letter == "white")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("AAAAAAA");
            }
        }
        static void Main(string[] args)
        {
            EventClass ec = new EventClass();
            ec.allEvent += Handler_A;
            ec.allEvent += Handler_B;
            ec.colorA += HandlerColorA_colorGreen;
            ec.colorA += HandlerColorA_colorBlue;
            ec.handlerEventColorB += HandlerColorB_colorRed;
            ec.handlerEventColorB += HandlerColorB_colorwhite;


            while(true)
            {
                Console.WriteLine("Entre la lettre...");
                string s = Console.ReadLine();
                 ec.start(s);
            }

        }
    }
}
