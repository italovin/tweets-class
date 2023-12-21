using blazor_test.Data;
using blazor_test.Models;
using Microsoft.EntityFrameworkCore;

namespace blazor_test.Repositories;

public class PhraseRepository{
    private readonly ConnectionDbContext _dbContext;

    public PhraseRepository(ConnectionDbContext dbContext){
        _dbContext = dbContext;
    }
    public async Task<List<Phrase>> GetPhrases(int quantity){
        List<Phrase> underLabelingPhrases = await _dbContext.Phrases.Where(i => i.Labelings.Count < 5).ToListAsync();
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
    public async Task InsertPhrase(Phrase phrase){
        _dbContext.Phrases.Add(phrase);
        await _dbContext.SaveChangesAsync();
    }

}