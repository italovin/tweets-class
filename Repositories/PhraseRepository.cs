using Data;
using Models.ORM;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class PhraseRepository
{
    private readonly IDbContextFactory<ConnectionDbContext>? _dbContextFactory;
    public PhraseRepository(){
    }
    public PhraseRepository(IDbContextFactory<ConnectionDbContext> dbContextFactory){
        _dbContextFactory = dbContextFactory;
    }
    public async Task<List<Phrase>> GetPhrases(int quantity){
        List<Phrase> underLabelingPhrases = [];
        if(_dbContextFactory is not null){
            using var dbContext = _dbContextFactory.CreateDbContext();
            underLabelingPhrases = await dbContext.Phrases.Where(i => i.Labelings.Count < 5).ToListAsync();
        }
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
        if(_dbContextFactory is not null){
            using var dbContext = _dbContextFactory.CreateDbContext();
            underLabelingPhrases = await dbContext.Phrases.Where(i => i.Labelings.Count < 5).ToListAsync();
        }
        int n = underLabelingPhrases.Count;
        var rnd = Random.Shared;
        while (n > 1) {  
            n--;  
            int k = rnd.Next(n + 1);
            (underLabelingPhrases[n], underLabelingPhrases[k]) = (underLabelingPhrases[k], underLabelingPhrases[n]);
        }
        return underLabelingPhrases.Take(quantity).ToList();
    }
    public async Task<List<Phrase>> GetAllPhrases(){
        List<Phrase> underLabelingPhrases = [];
        if(_dbContextFactory is not null){
            using var dbContext = _dbContextFactory.CreateDbContext();
            underLabelingPhrases = await dbContext.Phrases.Where(i => i.Labelings.Count < 5).ToListAsync();
        }
        return [.. underLabelingPhrases];
    }
    public void InsertPhrase(Phrase phrase){
        if(_dbContextFactory is not null){
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Phrases.Add(phrase);
            dbContext.SaveChanges();
        }
    }

}