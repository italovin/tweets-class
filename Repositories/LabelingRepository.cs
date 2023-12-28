using System.Data.Common;
using blazor_test.Data;
using blazor_test.Models;

namespace blazor_test.Repositories;

public class LabelingRepository(ConnectionDbContext dbContext)
{
    private readonly ConnectionDbContext _dbContext = dbContext;

    public void LabelPhrase(Labeling labeling){
        _dbContext.Labelings.Add(labeling);
        _dbContext.SaveChanges();
    }
    public void LabelPhrasesList(List<Labeling> labelings){
        _dbContext.Labelings.AddRange(labelings);
        _dbContext.SaveChanges();
    }
}