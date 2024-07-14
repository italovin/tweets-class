using Models.Core;

namespace Testing;

public class PhraseDebug {

    public static List<PhraseCore> GenDebugPhrases(int phrasesCount){
        List<PhraseCore> phrases = [];
        for(int i = 0; i < phrasesCount; i++){
            phrases.Add(new PhraseCore { Text = $"Frase {i+1}"});
        }
        return phrases;
    }

}