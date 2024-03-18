using blazor_test.Data;
using blazor_test.Models.Core;
using blazor_test.Models.ORM;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;

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
    public async Task<AccessKeyRevoke?> GetFirst(){
        if(_dbContext is not null){
            var result = await _dbContext.AccessKeys.FirstOrDefaultAsync(x => x.Revoked == 1);
            if (result is not null)
                return new AccessKeyRevoke{ Id = result.Id};
            else
                return new AccessKeyRevoke{ Id = 0};
        }else
            return null;
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