using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_2_CybersecurityAwarenessChatBot
{
    class Program
    {
        static SpeechSynthesizer synth = new SpeechSynthesizer
        {
            //sets the volume to the highest available option i.e. 100
            Volume = 100,
            //sets the speed at which the text is spoken to the default speed
            Rate = 0
        };

        //class used to generate random tips (e.g. tips of the day, security tips)
        static Random random = new Random();


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

                // Play audio greeting
                PlayGreetingAudio("greetingsTwo.wav"); // Use the converted WAV file

                RespondWithSpeech("Welcome to your Cybersecurity Awareness Bot. I'm here to help you stay safe online.");


                // Ask for the user's name
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("What's your name? ");
                Console.ForegroundColor = ConsoleColor.White;
                string userName = Console.ReadLine();
                //store username in memoryRecall()
                MemoryRecall["name"] = userName;

                LoadingEffect();

                RespondWithSpeech($"Hi,{userName}! Here's a fun tip for you!");

                // Display a security tip of the day
                DisplayTipOfTheDay();

                // Display available topics the user can ask about
                Console.WriteLine(new string('—', 70));
                Console.WriteLine(" You can ask about: ");
                Console.WriteLine(" - How to create strong passwords");
                Console.WriteLine(" - How to recognize phishing emails");
                Console.WriteLine(" - How to practise safe browsing");
                Console.WriteLine(" - General questions like \"How are you?\", \"What's your purpose?\"");
                Console.WriteLine(" - Or type 'exit' to quit.");
                Console.WriteLine(new string('-', 70));

                // Start the chat loop
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{userName}: ");
                    string userInput = Console.ReadLine()?.ToLower().Trim();

                    // checks for an empty input
                    if (string.IsNullOrEmpty(userInput))
                    {
                        LoadingEffect();
                        Console.ForegroundColor = ConsoleColor.Red;
                        RespondWithSpeech("Please enter a valid question.");
                        continue;
                    }

                    // check to see if the user enters the 'exit' command
                    if (userInput == "exit")
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        RespondWithSpeech("Stay safe and think before you click! Goodbye!");
                        break;
                    }

                    HandleUserQuery(userInput, userName);
                }
                // Save chat history when exiting
                SaveChatHistory();
            }
        }








        //method to play audio 
        public static void PlayGreetingAudio(string filePath)
        {
            try
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

                if (File.Exists(fullPath))
                {
                    SoundPlayer player = new SoundPlayer(fullPath);
                    player.PlaySync();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: The file {filePath} was not found.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error playing audio: {ex.Message} ");
            }
        }



        //method to read out text 
        public static void RespondWithSpeech(string response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TypingEffect($"ChatBot: {response}\n");

            try
            {
                //speaks out loud 
                synth.Speak(response); //reliable speech output 

            }
            catch (Exception ex)
            {
                //error message if exception fails 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Its Error: {ex.Message}");
            }
            chatHistory.Add($"ChatBot: {response}");

        }



        //method to stimulate the effect of someone typing 
        public static void TypingEffect(string message, int delay = 30)
        {
            //loops through each letter in the message 
            foreach (char c in message)
            {
                //prints the current letter in the word, without moving to a new line
                Console.Write(c);
                //the delay adds a to the typing effect (delay by a millisecond, before typing the next character 
                Thread.Sleep(delay);
            }
        }

        //saves entire conversation to a text file 
        public static void SaveChatHistory()
        {
            //name of file where text will be saved 
            string path = "chat_history.txt";
            //writes all the lines in the conversation 
            File.WriteAllLines(path, chatHistory);
            //colour of text will be grey 
            Console.ForegroundColor = ConsoleColor.Gray;
            //prints confirmation message 
            Console.WriteLine($"Chat history saved to {path}");
        }


        //method to display a fun tip of the day
        public static void DisplayTipOfTheDay()
        {
            //array to store a variety of tips that can be rotated 
            string[] tips = new string[]
            {
               "Tip: Use multi-factor authentication {MFA} wherever possible to enhance security!",
               "Tip: Always verify the senders email address before clicking on any link",
               "Tip: Avoid using public Wi-Fi for accessing sensitive information like banking"
            };

            //randomly selects an index between zero and length - 1 (arrays start at index zero)
            int tipIndex = random.Next(tips.Length);
            //displays dots to display chatbot thinking 
            LoadingEffect();
            //changes colour 
            Console.ForegroundColor = ConsoleColor.Green;
            RespondWithSpeech($"Security Tip of the Day: {tips[tipIndex]}");
        }


        //method to stimulate chatbot thinking 
        public static void LoadingEffect()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //displays 'chatbot' without a new line
            Console.Write("chatbot");
            //loops 3 times
            for (int i = 0; i < 3; i++)
            {
                //pauses for 0.4 seconds (400 milliseconds 
                Thread.Sleep(400);
                //prints 3 dots after 'chatbot' to stimulate chatbot thinking 
                Console.Write("...");
            }
            //move to next line 
            Console.WriteLine();
        }

        //dictionary to store a phrases of confused words 
        public static string lastTopic = " ";
        static List<string> confusedWords = new List<string>
        {
            "i do not understand", "what", "explain", "dont understand", "don't understand", "huh", "confused", "lost", "more detail", "more info", "more information", "explain in more detail"
        };


        //dictionary to respond to basic queries 
        static Dictionary<string, string> responses = new Dictionary<string, string>
            {
                { "how are you", "I'm doing great! How can I assist you with cybersecurity today?"},
                { "what's your purpose", "My purpose is to educate you on how to create a safe environment online by giving cybersecurity tips." +
                  "\nI can answer questions regarding phishing emails, password safety and safe browsing."},
                 { "help", "You can ask about passwords, phishing, safe browsing, or general cybersecurity guidance."}

        };


        //dictionary to understand user, if they didn't enter main keyword from the 'responses' dictionary
        static Dictionary<string, List<string>> keywordGroups = new Dictionary<string, List<string>>()
            {
                {"password", new List <string> {"passwords", "password", "strong password", "secure password"} },
                {"phishing", new List <string> {"phishing", "phishing email", "fake email", "scam", "scams"} },
                {"safe browsing", new List <string> {"browse safely", "secure browsing", "browsing","privacy", "safe-browsing"} },
                {"how are you", new List <string> {"how are u", "how r u", "how are you?", "how r u?"} },
                {"what's your purpose", new List <string> {"purpose", "what is your purpose", "whats your purpose" } },
       };


        //dictionary to understand memory recall (store user name and favourite security)
        static Dictionary<string, string> MemoryRecall = new Dictionary<string, string>();
        //flag to ensure that the memory recall only occurs once in every session - reminded user about interest 
        static bool hasRemindedUserAboutInterest = false;
        //flag to track if user expressed their interest 
        static bool hasStoredInterest = false;

        static List<string> chatHistory = new List<string>();

        public static string NormalizeInput(string input)
        {
            //removes punctuation and converts user input to lowercase letters
            return input.ToLower().Trim().Replace("?", "").Replace(".", "").Replace(",", "");
        }




        //method to answer basic questions from the user 
        static void HandleUserQuery(string input, string userName)
        {
            //prevents chatbot from crashing out. simply prompts user to enter a valid entry 
            if (string.IsNullOrWhiteSpace(input))
                return;

            //referencing the method in this method
            string normalizedInput = NormalizeInput(input);
            // to lower all user inputs to lowercase letters
            string lowercaseInput = input.ToLower();
            //splits words
            string[] inputTokens = normalizedInput.Split(' ');


            //checks if user expressed interest in a topic and responds appropriately
            if (lowercaseInput.Contains("like ") || lowercaseInput.Contains("interested") || lowercaseInput.Contains("prefer") || lowercaseInput.Contains("enjoy"))
            {
                //set flag to false - tracks if users expressed their interest 
                hasStoredInterest = false;

                //loop to check if user prompt is stored in keywordGroup dictionary 
                foreach (var group in keywordGroups)
                {
                    foreach (var synonym in group.Value)
                    {
                        if (normalizedInput.Contains(NormalizeInput(synonym)))
                        {
                            lastTopic = group.Key;
                            MemoryRecall["favouriteTopic"] = group.Key;
                            hasStoredInterest = true;
                            RespondWithSpeech($"Great! I'll remember that you're interested in {group.Key}. It's a crucial part of staying safe online.");

                            break;
                        }
                    }

                    if (hasStoredInterest)
                        break;
                }

                //if no matching topic was found 
                if (!hasStoredInterest)
                {
                    RespondWithSpeech("Please enter a valid topic. Type 'help' to see what you can be interested in.");
                }
                return;

            }

            // Check if user's input contains their favourite topic, and mention it
            if (MemoryRecall.ContainsKey("favouriteTopic") &&
           normalizedInput.IndexOf(MemoryRecall["favouriteTopic"], StringComparison.OrdinalIgnoreCase) >= 0 &&
            !hasRemindedUserAboutInterest)
            {
                string rememberedTopic = MemoryRecall["favouriteTopic"];
                RespondWithSpeech($"As someone interested in {rememberedTopic}, here's something important you should know.");
                hasRemindedUserAboutInterest = true;
            }

            // Checks if user is confused and displays the appropriate output 
            foreach (string phrase in confusedWords)
            {
                string normalizedPhrase = NormalizeInput(phrase);

                if (normalizedInput == normalizedPhrase ||
                    //above, checks if the entire line entered by user matches the confused phrase dictionary exactly!
                    normalizedInput.StartsWith(normalizedPhrase + " ") ||
                    //above, checks if the users input partly matches the phrase from the confused dictionary i.e. phrase is followed by more words
                    normalizedInput.EndsWith(" " + normalizedPhrase))
                //above, checks if the users input partly matches the phrase from the confused dictionary i.e. phrase is followed by more words 
                {

                    if (!string.IsNullOrEmpty(lastTopic))
                    {
                        // Only explain if lastTopic is one of the three recognized topics
                        if (lastTopic == "password" || lastTopic == "phishing" || lastTopic == "safe browsing")
                        {
                            ContinueExplaining(lastTopic);
                        }
                        else if (responses.ContainsKey(lastTopic))
                        {
                            // For other known topics like "how are you" or "what's your purpose"
                            RespondWithSpeech(responses[lastTopic]);
                        }
                        else
                        {
                            //message displays when chatbot knows what the last topic is, but cant explain it i.e it isn't password, phishing or safe-browsing
                            RespondWithSpeech("I’ll do my best to explain better. Can you be more specific? Type 'help' to see what you can ask about.");
                        }
                    }
                    else
                    {
                        //when user is confused at the start of the program, and there is no 'lastTopic' in the chatbot history
                        RespondWithSpeech("I'm here to help.Type 'help' to see what you can ask about");
                    }
                    return;
                }
            }


            //checks for sentiment keywords and responds appropriately
            if (lowercaseInput.Contains("worried") || lowercaseInput.Contains("scared") || lowercaseInput.Contains("anxious"))
            {
                RespondWithSpeech("It's completely okay to feel that way. Cybersecurity can seem complex, \nbut you're doing great by asking questions. I'm here to help you every step of the way.\nType 'help' to see what you can learn about to feel less anxious.");
                return;
            }

            if (lowercaseInput.Contains("frustrated"))
            {
                RespondWithSpeech("Don't worry if it's frustrating. Many people feel that way at first. \nYou're not alone, and I'll do my best to make things clearer for you.\nIf you wish, you can type 'help' to see what else you can learn about.");
                return;
            }

            if (lowercaseInput.Contains("curious"))
            {
                RespondWithSpeech("I love your curiosity! \nLet's explore the topic together — cybersecurity is full of interesting areas.Type 'help' to see what else you can learn about.");
                return;
            }







        }
}
