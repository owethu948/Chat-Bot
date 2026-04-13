using System;
using System.Media;
using System.IO;

namespace CybersecurityChatbot
{
    public class AudioService
    {
        public void PlayGreeting()
        {
            try
            {
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");
                
                if (File.Exists(audioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.PlaySync(); // Play synchronously
                    }
                }
                else
                {
                    Console.Beep(440, 500); // Fallback beep if audio file not found
                    Console.WriteLine("[Audio: Welcome to Cybersecurity Awareness Bot]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Note: Audio greeting could not be played: {ex.Message}");
            }
        }
    }
}
