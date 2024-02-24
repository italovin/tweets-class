using blazor_test.Data;
using blazor_test.Models.ORM;
using Isopoh.Cryptography.Argon2;

namespace blazor_test.Repositories;

public class AccessKeyRepository
{
    private readonly ConnectionDbContext? _dbContext;

    public AccessKeyRepository(){
    }
    public AccessKeyRepository(ConnectionDbContext dbContext){
        _dbContext = dbContext;
    }
    public bool CheckIfRevoked(AccessKey accessKey){
        return accessKey.Revoked == 1;
    }
    public async Task<AccessKey?> Get(int keyId){
        if(_dbContext is not null)
            return await _dbContext.AccessKeys.FindAsync(keyId);
        else
            return null;
    }
    public void RevokeAccessKey(AccessKey accessKey){
        if(_dbContext is not null){
            accessKey.Revoked = 1;
            _dbContext.SaveChanges();
        }
    }
    public bool Validate(AccessKey accessKey, string accessKeyString){
        return Argon2.Verify(accessKey.HashString, accessKeyString);
    }
}