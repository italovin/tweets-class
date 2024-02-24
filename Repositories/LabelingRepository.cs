using System.Data.Common;
using blazor_test.Data;
using blazor_test.Models.ORM;

namespace blazor_test.Repositories;

public class LabelingRepository
{
    private readonly ConnectionDbContext? _dbContext;

    public LabelingRepository(){
    }
    public LabelingRepository(ConnectionDbContext dbContext){
        _dbContext = dbContext;
    }
    public void LabelPhrase(Labeling labeling){
        if(_dbContext is not null){
            _dbContext.Labelings.Add(labeling);
            _dbContext.SaveChanges();
        }
    }
    public void LabelPhrasesList(List<Labeling> labelings){
        if(_dbContext is not null){
            _dbContext.Labelings.AddRange(labelings);
            _dbContext.SaveChanges();
        }
    }
}