using Geneva.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Geneva.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration();

            var voiceActivatedAssitant = new VoiceActivatedAssistant(configuration);
            voiceActivatedAssitant.Start();
        }
    }
}
