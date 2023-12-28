using blazor_test.Data;
using blazor_test.Models;
using Isopoh.Cryptography.Argon2;

namespace blazor_test.Repositories;

public class AccessKeyRepository(ConnectionDbContext dbContext)
{
    private readonly ConnectionDbContext _dbContext = dbContext;

    public bool CheckIfRevoked(AccessKey accessKey){
        return accessKey.Revoked == 1;
    }
    public async Task<AccessKey?> Get(int keyId){
        return await _dbContext.AccessKeys.FindAsync(keyId);
    }
    public void RevokeAccessKey(AccessKey accessKey){
        accessKey.Revoked = 1;
        _dbContext.SaveChanges();
    }
    public bool Validate(AccessKey accessKey, string accessKeyString){
        return Argon2.Verify(accessKey.HashString, accessKeyString);
    }
}