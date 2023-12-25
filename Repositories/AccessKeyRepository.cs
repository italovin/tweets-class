using blazor_test.Data;
using blazor_test.Models;
using Isopoh.Cryptography.Argon2;

public class AccessKeyRepository{
    private readonly ConnectionDbContext _dbContext;

    public AccessKeyRepository(ConnectionDbContext dbContext){
        _dbContext = dbContext;
    }
    public bool CheckIfRevoked(AccessKey accessKey){
        return accessKey.Revoked == 1;
    }
    public AccessKey? GetAccessKey(int keyId){
        return _dbContext.AccessKeys.Find(keyId);
    }
    public async Task RevokeAccessKey(AccessKey accessKey){
        accessKey.Revoked = 1;
        await _dbContext.SaveChangesAsync();
    }
    public bool? ValidateAccessKey(int keyId, string accessKeyString){
        var accessKey = GetAccessKey(keyId);
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