using Data;
using Models.ORM;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class LabelingRepository
{
    private readonly IDbContextFactory<ConnectionDbContext>? _dbContextFactory;

    public LabelingRepository(){
    }
    public LabelingRepository(IDbContextFactory<ConnectionDbContext> dbContextFactory){
        _dbContextFactory = dbContextFactory;
    }
    public void LabelPhrase(Labeling labeling){
        if(_dbContextFactory is not null){
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Labelings.Add(labeling);
            dbContext.SaveChanges();
        }
    }
    public void LabelPhrasesList(List<Labeling> labelings){
        if(_dbContextFactory is not null){
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Labelings.AddRange(labelings);
            dbContext.SaveChanges();
        }
    }
}