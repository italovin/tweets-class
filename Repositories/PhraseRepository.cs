using System.Diagnostics;
using blazor_test.Data;
using blazor_test.Models.ORM;
using Microsoft.EntityFrameworkCore;

namespace blazor_test.Repositories;

public class PhraseRepository
{
    private readonly ConnectionDbContext? _dbContext;

    public PhraseRepository(){
    }
    public PhraseRepository(ConnectionDbContext dbContext){
        _dbContext = dbContext;
    }
    public async Task<List<Phrase>> GetPhrases(int quantity){
        List<Phrase> underLabelingPhrases = [];
        if(_dbContext is not null)
            underLabelingPhrases = await _dbContext.Phrases.Where(i => i.Labelings.Count < 5).ToListAsync();
        List<Phrase> phrases = [];
        var rnd = Random.Shared;
        for (int i = 0; i < quantity; i++)
        {
            if(underLabelingPhrases.Count <= 0)
                break;
            int randomIndex = rnd.Next(underLabelingPhrases.Count);
            phrases.Add(underLabelingPhrases[randomIndex]);
            underLabelingPhrases.RemoveAt(randomIndex);
        }
        return phrases;
    }
    public async Task<List<Phrase>> GetPhrasesWithShuffle(int quantity){
        List<Phrase> underLabelingPhrases = [];
        if(_dbContext is not null)
            underLabelingPhrases = await _dbContext.Phrases.Where(i => i.Labelings.Count < 5).ToListAsync();
        int n = underLabelingPhrases.Count;
        var rnd = Random.Shared;
        while (n > 1) {  
            n--;  
            int k = rnd.Next(n + 1);
            (underLabelingPhrases[n], underLabelingPhrases[k]) = (underLabelingPhrases[k], underLabelingPhrases[n]);
        }
        return underLabelingPhrases.Take(quantity).ToList();
    }
    public void InsertPhrase(Phrase phrase){
        if(_dbContext is not null){
            _dbContext.Phrases.Add(phrase);
            _dbContext.SaveChanges();
        }
    }

}