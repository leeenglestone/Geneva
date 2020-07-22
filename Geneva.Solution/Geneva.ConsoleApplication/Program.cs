using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Geneva.ConsoleApplication
{
    class Program
    {
        static readonly float confidenceLevel = 0.96f;

        static void Main(string[] args)
        {
            var culture = new System.Globalization.CultureInfo("en-GB");

            using (SpeechRecognitionEngine _speechRecognitionEngine = new SpeechRecognitionEngine(culture))
            {
                _speechRecognitionEngine.SpeechRecognized += _speechRecognitionEngine_SpeechRecognized;
                _speechRecognitionEngine.SetInputToDefaultAudioDevice();

                var choices = new Choices();
                choices.Add("Geneva");
                choices.Add("Jasper");

                var grammarBuilder = new GrammarBuilder(choices);
                grammarBuilder.Culture = culture;

                var grammar = new Grammar(grammarBuilder);
                _speechRecognitionEngine.LoadGrammar(grammar);

                // Start asynchronous, continuous speech recognition
                _speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);

                // Keep the console window open
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        private static void _speechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > confidenceLevel)
            {
                Console.WriteLine($"Speech Recognised= {e.Result.Text}; Confidence={e.Result.Confidence}");
            }
        }
    }
}
