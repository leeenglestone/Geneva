using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Geneva.Library
{
    public class Command
    {
        public Command(string name, string[] phrases, Func<CommandResult> action)
        {
            Name = name;
            Phrases = phrases;
            Action = action;
        }

        public string Name { get; set; }

        public string[] Phrases { get; set; }
        public Func<CommandResult> Action { get; }

        internal static Command Get(string text)
        {
            // This eventually needs to lookup against a collection of commands


            return new Command("WhatTimeIsIt",
                new string[] { "What time is it", "What's the time" },
                () =>
                {
                    var speechSynthesizer = new SpeechSynthesizer();
                    speechSynthesizer.Speak($"The time is {DateTime.Now.ToString("HH mm tt")}");

                    Console.WriteLine($"The time is {DateTime.Now.ToString("HH mm tt")}");
                    return new CommandResult();
                });
        }

        internal CommandResult Execute()
        {
            return Action();
        }
    }
}
