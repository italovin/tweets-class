using Data;
using Models.Core;
using Models.ORM;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class AccessKeyRepository
{
    private readonly IDbContextFactory<ConnectionDbContext>? _dbContextFactory;

    public AccessKeyRepository(){
    }
    public AccessKeyRepository(IDbContextFactory<ConnectionDbContext> dbContextFactory){
        _dbContextFactory = dbContextFactory;
    }
    public bool CheckIfRevoked(AccessKey accessKey){
        return accessKey.Revoked == 1;
    }
    public async Task<AccessKeyRevoke?> GetFirst(){
        if(_dbContextFactory is not null){
            using var dbContext = _dbContextFactory.CreateDbContext();
            var result = await dbContext.AccessKeys.FirstOrDefaultAsync(x => x.Revoked == 1);
            if (result is not null)
                return new AccessKeyRevoke{ Id = result.Id};
            else
                return new AccessKeyRevoke{ Id = 0};
        } else
            return null;
    }
    public async Task<AccessKey?> Get(int keyId){
        if(_dbContextFactory is not null){
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.AccessKeys.FindAsync(keyId);
        } else
            return null;
    }
    public void RevokeAccessKey(AccessKey accessKey){
        if(_dbContextFactory is not null){
            using var dbContext = _dbContextFactory.CreateDbContext();
            accessKey.Revoked = 1;
            dbContext.SaveChanges();
        }
    }
    public bool Validate(AccessKey accessKey, string accessKeyString){
        return Argon2.Verify(accessKey.HashString, accessKeyString);
    }
}