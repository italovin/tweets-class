using blazor_test.Models;

namespace blazor_test.Testing;

public class PhraseDebug {

    public static List<Phrase> GenDebugPhrases(int phrasesCount){
        List<Phrase> phrases = [];
        for(int i = 0; i < phrasesCount; i++){
            phrases.Add(new Phrase { Text = $"Frase {i+1}"});
        }
        return phrases;
    }

}