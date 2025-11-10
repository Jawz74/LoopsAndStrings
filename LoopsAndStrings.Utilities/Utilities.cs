namespace LoopsAndStrings.Utilities
{
    // Utility-klasser innehåller allmänna funktioner som kan användas i flera projekt.
    // Specialfall av en helper-klass. Har bara static metoder.
    public static class Utils
    {
        public static bool FindNthWordInSentence(string? sentence, uint wordNo, out string? nthWord)
        {
            nthWord = "";
            
            // Nedanstående hoppas över om sentence innehåller ctrl + z (null), enter (tom sträng) eller enbart blanksteg.
            if (IsStringValidText(sentence, false))
            {
                string[]? wordArray;

                // Dela upp inkommande mening på mellanslag (efter att repeterande mellanslag tagits bort - med option) 
                wordArray = sentence?.Split(' ', StringSplitOptions.RemoveEmptyEntries);      

                if (wordNo > 0 && wordNo <= wordArray?.Length) // Om det finns minst n ord i meningen
                {
                    nthWord = wordArray[wordNo - 1];
                    return true;
                }
            }

            return false;        
        }

        // Kollar om inkommande textsträng innehåller en textsträng.
        // En tom sträng ("") eller enbart blanksteg (" ") kan tillåtas genom allowEmpty=true.
        // Null eller ctrl + z tillåts däremot inte.
        public static bool IsStringValidText(string? text, bool allowEmptyOrBlanksOnly = false)
        {
            // Om Ctrl + z har matats in är text==null, dvs inte en sträng 
            if (!(text is string))
                return false;

            // Blir false endast om text är tom ("") eller bara blanksteg, fastän det inte tillåts. Annars true.
            return !allowEmptyOrBlanksOnly && string.IsNullOrEmpty(text.Trim()) ? false : true;
        }
    }
}
