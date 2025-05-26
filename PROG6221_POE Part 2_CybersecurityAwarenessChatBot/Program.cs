using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_2_CybersecurityAwarenessChatBot
{
    class Program
    {
        static void Main()
        {
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(new string('=', Console.WindowWidth)); // top border

                Console.WriteLine(@" 

              ██████╗██╗   ██╗██████╗ ███████╗██████╗     ███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗    
             ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗    ██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝    
             ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝    ███████╗█████╗  ██║     ██║   ██║██████╔╝██║   ██║    ╚████╔╝     
             ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗    ╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██║   ██║     ╚██╔╝      
             ╚██████╗   ██║   ██████╔╝███████╗██║  ██║    ███████║███████╗╚██████╗╚██████╔╝██║  ██║██║   ██║      ██║       
              ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝       

                             █████╗ ██╗    ██╗ █████╗ ██████╗ ███████╗███╗   ██╗███████╗███████╗███████╗                   
                            ██╔══██╗██║    ██║██╔══██╗██╔══██╗██╔════╝████╗  ██║██╔════╝██╔════╝██╔════╝                   
                            ███████║██║ █╗ ██║███████║██████╔╝█████╗  ██╔██╗ ██║█████╗  ███████╗███████╗                   
                            ██╔══██║██║███╗██║██╔══██║██╔══██╗██╔══╝  ██║╚██╗██║██╔══╝  ╚════██║╚════██║                   
                            ██║  ██║╚███╔███╔╝██║  ██║██║  ██║███████╗██║ ╚████║███████╗███████║███████║                   
                            ╚═╝  ╚═╝ ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝╚══════╝╚══════╝╚══════╝                                                                                                                           
            ");

                Console.WriteLine(new string('=', Console.WindowWidth)); // Bottom border made of = signs 

                //array to store each line of the slogan 
                string[] lines = new string[]
                {

                "      C Y B E R S E C U R I T Y   1 0 1     ",
                "           STAY SAFE ONLINE              ",

       };
                //stores width of console. allows us to centralise text 
                int consoleWidth = Console.WindowWidth;

                //loop to centralise text 
                foreach (string line in lines)
                {
                    //calculates how many empty spaces are left when the line is printed. then 
                    //then, divides it by 2, to determine how many spaces to put before the line so that we can centralise it
                    int padding = (consoleWidth - line.Length) / 2;
                    //creates a string of spaces for the left padding
                    ////prints the spaces out first, then the actual line, so that it looks centered
                    Console.WriteLine(new string(' ', Math.Max(0, padding)) + line);
                    // math.max ensures that the padding is not negative, in case the line is wider t

                }

                Console.WriteLine();







            }
            }
    }
}
