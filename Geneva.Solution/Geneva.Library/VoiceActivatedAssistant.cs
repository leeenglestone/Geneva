using Geneva.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Geneva.Library
{
    public class VoiceActivatedAssistant
    {
        readonly Configuration _configuration;
        SpeechRecognitionEngine _speechRecognitionEngine;

        public ListeningState ListeningState { get; set; } = ListeningState.Passive;

        public VoiceActivatedAssistant(Configuration configuration)
        {
            _configuration = configuration;
        }

        private void LoadPassiveGrammar()
        {
            _speechRecognitionEngine.UnloadAllGrammars();

            var grammarBuilder = new GrammarBuilder(new Choices(_configuration.WakeWord));
            grammarBuilder.Culture = _configuration.Culture;

            var grammar = new Grammar(grammarBuilder);
            _speechRecognitionEngine.LoadGrammar(grammar);
        }

        private void LoadActiveGrammar()
        {
            _speechRecognitionEngine.UnloadAllGrammars();

            var grammarBuilder = new GrammarBuilder(new Choices("What time is it", "What's the time"));
            grammarBuilder.Culture = _configuration.Culture;

            var grammar = new Grammar(grammarBuilder);
            _speechRecognitionEngine.LoadGrammar(grammar);
        }

        public void Start()
        {
            using (_speechRecognitionEngine = new SpeechRecognitionEngine(_configuration.Culture))
            {
                _speechRecognitionEngine.SpeechRecognized += _speechRecognitionEngine_SpeechRecognized;
                _speechRecognitionEngine.SetInputToDefaultAudioDevice();

                LoadPassiveGrammar();

                // Start asynchronous, continuous speech recognition
                _speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);

                // TODO: Replace reference to Console ReadLine
                // Keep the console window open
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        private void _speechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence < _configuration.ConfidenceLevel)
            {
                Console.WriteLine($"Confidence level not reached ({e.Result.Confidence})");
                return;
            }

            if (ListeningState == ListeningState.Passive)
            {
                ListeningState = ListeningState.Active;
                Console.WriteLine($"Listening State changed to Active");

                LoadActiveGrammar();
                
            }

            // Must be in Active state

            Command command = Command.Get(e.Result.Text);
            CommandResult commandResult = command.Execute();

            Console.WriteLine($"Speech Recognised= {e.Result.Text}; Confidence={e.Result.Confidence}");
        }
    }
}
