 # >> CYBERSECURITY AWARENESS ASSISTANT CHATBOT <<

                          > POE PART 2 <

# DESCRIPTION 
This Console App was designed to provide cybersecurity tips. 
It provides cybersecurity tips on selected topics to raise awareness.
It was built using C#

# PURPOSE OF THE CHATBOT?
To stimulate real-life scenarios where users may encounter cyber threats and provide assistance in avoiding common traps. 
The chatbot educates users on cybersecurity topics in a conversational manner. 

# WHAT PROBLEM DOES THE CHATBOT SOLVE?
Cyberattacks have become popular in South Africa. 
It affects businesses, individuals and government institutions.
This chatbot aims to educate users to identify and mitigate cyber threats. 

# FEATURES IN THE CHATBOT:
1. Voice greeting 
   - Adds a personal touch to the chatbot and enhances the conversational tone. 
   - Audio is saved as a WAV file. 
   - Try-catch block used in the PlayGreetingAudio() to make the code look more cohesive and professional. It also allows errors to be handled gracefully. 

2. ASCII art
   - Images are not supported on console apps so ASCII art is a good way to make the application feel more welcoming and creative. 
   - Makes the chatbot more fun for users to interact with. 

3. Personalisation
   - Chatbot prompts user to enter their name. 
   - Allows responses to be personalised throughout the conversation. 

4. Type writing effect 
   -Stimulates the chatbot to feel like a human typing
   - The loadingEffect() also adds a human-feel to the chatbot by delaying responses by 0.4 seconds. 
 
5. Switch statement 
   - Makes it easier to read the code, since it is more organised than multiple if-else statements.

6. Use of colour and borders
   - Different colours are used to distinguish between the users input and the chatbots responses. 
   - Makes it easier for the user to focus on a section, as each section is visually separated. 

7. Exception handling 
   - If the user enters an invalid prompt, the chatbot will gracefully inform them to enter a valid option. 

8. Keyword Recognition 
   - Chabot recognises and responds to specific cybersecurity-related topics. 

9. Array with Random Responses
   - Chatbot selects one response from multiple predefines responses for cybersecuirty queries.
   - Allows variation to occur.Enhances conversational manner. 

10. Memory and Recall 
    - Chatbot can 'remember' details entered by the user 
    - E.g. the users name and their favourite cybersecurity topic 
    - This makes the chatbot more engaging .

11. Sentiment Detection 
    - The chatbot adjusts its responses based on the users sentiment. 
    - Creates an empathetic interaction since chatbot provides encouragemenet or support if user feels overwhelemed or unsure. 

12. Code Optimisation 
    - Shown by use of dictionaries, arrays, keyword responses

13. Flags 
    - Used to track events in the program. 
    -Indicated if a specific result took place. 

# SETUP INSTRUCTIONS 
- .NET SDK 
- An IDE. Visual Studio was used for this console app 
- Terminal/Command prompt [Optional]

# USAGE INSTURCTIONS 
When the application runs, it will first display ascii art follwed by a welcome message. 
It will then prompt the user for their name.
The start of the program will look like this:

[ascii art]           
  C Y B E R S E C U R I T Y     1 0 1     
           STAY SAFE ONLINE   

ChatBot: Welcome to your Cybersecurity Awareness Bot. I'm here to help you stay safe online.
 ChatBot: What's your name?

The user can type questions like:
- What are phishing emails 
- How to create a strong password 
- How to practise safe browisng 
- Exit the application 


# EXAMPLE CONVERSATION 
ChatBot: What's your name?

User: Nabihah 

ChatBot: Hi, Nabihah ! Here's a fun tip for you!

ChatBot: ......

ChatBot: Tip: Always verify the senders email address before clicking on any link.

Nabihah: exit 

ChatBot: ......

ChatBot: Stay safe and think before you click! Goodbye!
