using blazor_test.Data;
using blazor_test.Models;

namespace blazor_test.Services;

public class LabelingsService{
    private readonly ConnectionDbContext _dbContext;

    public LabelingsService(ConnectionDbContext dbContext){
        _dbContext = dbContext;
    }
    public async Task InsertLabeling(Labeling labeling){
        _dbContext.Labelings.Add(labeling);
        await _dbContext.SaveChangesAsync();
    }
}