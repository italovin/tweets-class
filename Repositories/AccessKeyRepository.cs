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
    public async Task<AccessKey?> GetAccessKey(int keyId){
        return await _dbContext.AccessKeys.FindAsync(keyId);
    }
    public async Task RevokeAccessKey(AccessKey accessKey){
        accessKey.Revoked = 1;
        await _dbContext.SaveChangesAsync();
    }
    public async Task<bool?> ValidateAccessKey(int keyId, string accessKeyString){
        var accessKey = await GetAccessKey(keyId);
        if(accessKey is null)
            return null;
        if (Argon2.Verify(accessKey.HashString, accessKeyString))
        {
            return true;
        } else{
            return false;
        }
    }
}