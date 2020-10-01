using System.Collections.Generic;

namespace LoveVision
{
    public class HandlePhrases
    {
        private Phrases _phrases;
        private List<string> _sayings;

        public HandlePhrases()
        {
            _phrases = new Phrases();
            _sayings = _phrases.Sayings.Clone();
        }

        public string GetSaying()
        {
            if (_sayings.Count > 0)
            {
                var sayingToReturn = _sayings[0];

                // Remove that saying from the list;
                _sayings.RemoveAt(0);

                return sayingToReturn;
            }
            else
            {
                // We want to repopulate the local list and run this again.
                _sayings = _phrases.Sayings.Clone();
                return GetSaying();
            }
        }
    }
}