using System;
using System.Threading;

namespace CybersecurityChatbot
{
    public class UIService
    {
        public void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo = @"
    ╔══════════════════════════════════════════════════════════════════════════════╗
    ║                         🔒 CYBERSECURITY AWARENESS BOT 🔒                    ║
    ║                                                                              ║
    ║       ██████╗██╗   ██╗██████╗ ███████╗██████╗     ██████╗  ██████╗ ████████╗  ║
    ║      ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗    ██╔══██╗██╔═══██╗╚══██╔══╝  ║
    ║      ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝    ██████╔╝██║   ██║   ██║     ║
    ║      ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗    ██╔══██╗██║   ██║   ██║     ║
    ║      ╚██████╗   ██║   ██████╔╝███████╗██║  ██║    ██████╔╝╚██████╔╝   ██║     ║
    ║       ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚═════╝  ╚═════╝    ╚═╝     ║
    ║                                                                              ║
    ║                    🛡️  Protecting South Africans Online  🛡️                   ║
    ╚══════════════════════════════════════════════════════════════════════════════╝
";
            Console.WriteLine(logo);
            Console.ResetColor();
            Thread.Sleep(1500);
        }

        public void DisplayWelcomeMessage(string userName)
        {
            DisplaySectionHeader("WELCOME");
            WriteColored($"Hello, {userName}! 👋\n", ConsoleColor.Yellow);
            WriteTypingEffect("I'm your Cybersecurity Awareness Assistant. I'm here to help you stay safe online!", 40);
            WriteTypingEffect("\nYou can ask me about:\n", 40);
            WriteColored("  • Password Safety 🔑\n", ConsoleColor.Green);
            WriteColored("  • Phishing Scams 🎣\n", ConsoleColor.Green);
            WriteColored("  • Safe Browsing 🌐\n", ConsoleColor.Green);
            WriteColored("  • General Cybersecurity Tips 🛡️\n\n", ConsoleColor.Green);
            WriteTypingEffect("Type 'exit' or 'goodbye' to end our conversation.\n", 40);
            Thread.Sleep(1000);
        }

        public void DisplaySectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n┌─────────────────────────────────────────────────────────────────┐");
            Console.WriteLine($"│  {title.PadRight(63)}│");
            Console.WriteLine($"└─────────────────────────────────────────────────────────────────┘");
            Console.ResetColor();
        }

        public void WriteColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public void WriteTypingEffect(string text, int delayMs)
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        public void DisplayTip()
        {
            string[] tips = {
                "💡 Tip: Never share your passwords with anyone!",
                "💡 Tip: Look for 'https://' in website URLs before entering sensitive info.",
                "💡 Tip: Enable Two-Factor Authentication whenever possible.",
                "💡 Tip: Be wary of emails asking for personal information.",
                "💡 Tip: Use a different password for each of your accounts."
            };
            
            Random rand = new Random();
            string randomTip = tips[rand.Next(tips.Length)];
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n{randomTip}\n");
            Console.ResetColor();
        }

        public void DisplayDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("─".Repeat(65));
            Console.ResetColor();
        }
    }
}

// Extension method for string repetition
public static class StringExtensions
{
    public static string Repeat(this string str, int count)
    {
        return new string(str[0], count);
    }
}
