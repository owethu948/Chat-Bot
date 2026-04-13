using System;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";
            Console.SetWindowSize(100, 40);

            // Initialize services
            AudioService audioService = new AudioService();
            UIService uiService = new UIService();
            ResponseService responseService = new ResponseService();

            // Play voice greeting
            audioService.PlayGreeting();

            // Display ASCII art logo
            uiService.DisplayLogo();

            // Create chatbot instance
            Chatbot chatbot = new Chatbot(uiService, responseService);

            // Start the conversation
            chatbot.StartConversation();
        }
    }
}
