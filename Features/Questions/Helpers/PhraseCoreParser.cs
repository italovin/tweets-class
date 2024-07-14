using Models.Core;
using Models.ORM;

namespace Features.Questions.Helpers;
public class PhraseCoreParser{

    public static List<PhraseCore> PhrasesORMToCore(List<Phrase> phrasesORM){
        List<PhraseCore> phraseCores = [];
        foreach(var phraseORM in phrasesORM){
            phraseCores.Add(new PhraseCore{ Id = phraseORM.Id, Text = phraseORM.Text});
        }
        return phraseCores;
    } 

}