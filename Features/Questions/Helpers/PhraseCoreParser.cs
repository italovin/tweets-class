using blazor_test.Models.Core;
using blazor_test.Models.ORM;

public class PhraseCoreParser{

    public static List<PhraseCore> PhrasesORMToCore(List<Phrase> phrasesORM){
        List<PhraseCore> phraseCores = [];
        foreach(var phraseORM in phrasesORM){
            phraseCores.Add(new PhraseCore{ Id = phraseORM.Id, Text = phraseORM.Text});
        }
        return phraseCores;
    } 

}