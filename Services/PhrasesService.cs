using blazor_test.Configurations;
using blazor_test.Data;
using blazor_test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace blazor_test.Services;

public class PhrasesService{

    private readonly ConnectionDbContext _dbContext;
    public PhrasesService(ConnectionDbContext dbContext){
        _dbContext = dbContext;
    }
    public async Task<List<Phrase>> GetPhrases(int quantity) => 
    await _dbContext.Phrases.OrderBy(x=>Guid.NewGuid()).Skip(Random.Shared.Next(1,_dbContext.Phrases.Count())).Take(quantity).ToListAsync(); 

    public async Task InsertPhrase(Phrase phrase){
        _dbContext.Phrases.Add(phrase);
        await _dbContext.SaveChangesAsync();
    }
    
}