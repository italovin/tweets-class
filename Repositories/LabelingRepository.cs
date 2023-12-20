using System.Data.Common;
using blazor_test.Data;
using blazor_test.Models;

namespace blazor_test.Repositories;

public class LabelingRepository{
    private readonly ConnectionDbContext _dbContext;

    public LabelingRepository(ConnectionDbContext dbContext){
        _dbContext = dbContext;
    }
    public async Task LabelPhrase(Labeling labeling){
        _dbContext.Add(labeling);
        await _dbContext.SaveChangesAsync();
    }
}