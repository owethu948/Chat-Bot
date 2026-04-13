using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class ResponseService
    {
        private Dictionary<string, Func<string, string>> _responseHandlers;

        public ResponseService()
        {
            InitializeResponseHandlers();
        }

        private void InitializeResponseHandlers()
        {
            _responseHandlers = new Dictionary<string, Func<string, string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "how are you", (name) => $"I'm functioning well, {name}! Ready to help you learn about cybersecurity. 🤖" },
                { "purpose", (name) => $"My purpose is to educate South African citizens about cybersecurity threats like phishing, malware, and social engineering. I'm here to help you stay safe online! 🛡️" },
                { "what can i ask", (name) => $"You can ask me about:{Environment.NewLine}• Password safety tips{Environment.NewLine}• How to recognize phishing emails{Environment.NewLine}• Safe browsing practices{Environment.NewLine}• General cybersecurity advice" },
                { "password", (name) => $"Great question, {name}! Use strong passwords with at least 12 characters, including uppercase, lowercase, numbers, and symbols. Never reuse passwords across different sites! 🔑" },
                { "phishing", (name) => $"Phishing is when scammers trick you into giving personal information. Never click suspicious links or download attachments from unknown senders. Always verify the sender's email address! 🎣" },
                { "safe browsing", (name) => $"For safe browsing, {name}:{Environment.NewLine}• Look for 'https://' and the padlock icon{Environment.NewLine}• Don't click on pop-up ads{Environment.NewLine}• Keep your browser updated{Environment.NewLine}• Use ad-blockers and anti-virus software 🌐" },
                { "malware", (name) => $"Malware is malicious software. Protect yourself by:{Environment.NewLine}• Installing reputable anti-virus software{Environment.NewLine}• Keeping your system updated{Environment.NewLine}• Not downloading from untrusted sources{Environment.NewLine}• Being careful with USB drives 🦠" },
                { "2fa", (name) => $"Two-Factor Authentication adds an extra layer of security. Even if someone steals your password, they can't access your account without the second factor (like a code sent to your phone). Always enable 2FA when available! 🔐" },
                { "social engineering", (name) => $"Social engineering manipulates people into revealing information. Always verify who you're talking to, don't share sensitive data over phone calls, and be skeptical of urgent requests. 🎭" }
            };
        }

        public string GetResponse(string userInput, string userName)
        {
            // Check for greetings
            if (userInput.Contains("hello") || userInput.Contains("hi") || userInput.Contains("hey"))
            {
                return $"Hello there, {userName}! How can I help you with cybersecurity today? 👋";
            }
            
            if (userInput.Contains("thank"))
            {
                return $"You're welcome, {userName}! Stay safe online! Remember, cybersecurity is everyone's responsibility. 🤝";
            }

            // Check for help
            if (userInput.Contains("help") || userInput.Contains("what can you do"))
            {
                return _responseHandlers["what can i ask"](userName);
            }

            // Check each response handler
            foreach (var handler in _responseHandlers)
            {
                if (userInput.Contains(handler.Key.ToLower()))
                {
                    return handler.Value(userName);
                }
            }

            // Default response for unrecognized input
            return $"I'm not sure I understand, {userName}. Could you ask me about passwords, phishing, safe browsing, malware, or 2FA? Or type 'help' to see what I can do. 🤔";
        }
    }
}
