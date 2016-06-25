using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class Message
    {
        private MLS LanguageString;

        public Message(params string[] languageStrings)
        {
            this.LanguageString = new MLS(languageStrings);
        }

        public string Format(string languageCode, params object[] formattingValues)
        {
            if (this.LanguageString.Count == 0)
                return null;

            if (this.LanguageString.Count == 1)
                return String.Format(this.LanguageString[0].Value, formattingValues);

            foreach (LS ls in LanguageString)
            {
                return String.Format(ls.Value, formattingValues);
            }

            return null;
        }
    }
}
