using System.Data.Common;
using blazor_test.Data;
using blazor_test.Models;

namespace blazor_test.Repositories;

public class LabelingRepository(ConnectionDbContext dbContext)
{
    private readonly ConnectionDbContext _dbContext = dbContext;

    public async Task LabelPhrase(Labeling labeling){
        _dbContext.Labelings.Add(labeling);
        await _dbContext.SaveChangesAsync();
    }
    public async Task LabelPhrasesList(List<Labeling> labelings){
        _dbContext.Labelings.AddRange(labelings);
        await _dbContext.SaveChangesAsync();
    }
}