using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geneva.Library
{
    public class Configuration
    {
        private string wakeWord = "Jasper";
        public string WakeWord { get { return wakeWord; } set { wakeWord = value; } }

        CultureInfo _culture = new System.Globalization.CultureInfo("en-GB");
        public CultureInfo Culture { get { return _culture; } set { _culture = value; } }

        float _confidenceLevel = 0.96f;
        public float ConfidenceLevel { get { return _confidenceLevel; } set { _confidenceLevel = value; } }
    }
}
