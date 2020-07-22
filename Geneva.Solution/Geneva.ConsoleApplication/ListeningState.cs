using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geneva.ConsoleApplication
{
    public enum ListeningState
    {
        Passive, // Listening for wake word
        Active // Heard wake word, now listening for command
    }
}
