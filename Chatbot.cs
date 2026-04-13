using System;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        private UIService _uiService;
        private ResponseService _responseService;
        private string _userName;
        private bool _isRunning;

        public Chatbot(UIService uiService, ResponseService responseService)
        {
            _uiService = uiService;
            _responseService = responseService;
            _isRunning = true;
        }

        public void StartConversation()
        {
            // Get user name
            _userName = GetUserName();

            // Display welcome message
            _uiService.DisplayWelcomeMessage(_userName);

            // Main conversation loop
            while (_isRunning)
            {
                string userInput = GetUserInput();
                ProcessUserInput(userInput);
            }
        }

        private string GetUserName()
        {
            _uiService.DisplaySectionHeader("IDENTIFICATION");
            _uiService.WriteColored("May I have your name? ", ConsoleColor.Cyan);
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                _uiService.WriteColored("I didn't catch that. Please enter your name: ", ConsoleColor.Yellow);
                name = Console.ReadLine();
            }

            return name.Trim();
        }

        private string GetUserInput()
        {
            _uiService.DisplaySectionHeader("CHAT");
            _uiService.WriteColored($"{_userName}: ", ConsoleColor.Green);
            string input = Console.ReadLine();
            return input?.Trim() ?? "";
        }

        private void ProcessUserInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                _uiService.WriteTypingEffect("I didn't quite understand that. Could you rephrase?", 30);
                return;
            }

            string lowerInput = input.ToLower();

            // Exit condition
            if (lowerInput == "exit" || lowerInput == "quit" || lowerInput == "goodbye")
            {
                _uiService.WriteColored($"\nThank you for learning about cybersecurity, {_userName}! Stay safe online! 🔒\n", ConsoleColor.Magenta);
                _isRunning = false;
                return;
            }

            // Get response from response service
            string response = _responseService.GetResponse(lowerInput, _userName);
            _uiService.WriteTypingEffect(response, 40);

            // Display tips after each response
            _uiService.DisplayTip();
        }
    }
}
}]
