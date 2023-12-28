using blazor_test.Repositories;
using blazor_test.Models;
using blazor_test.Models.Validations;
using System.Text.RegularExpressions;

namespace blazor_test.Services;

public partial class AccessKeyService(AccessKeyRepository accessKeyRepository)
{
    private readonly AccessKeyRepository _accessKeyRepository = accessKeyRepository;


    public async Task<bool> Revoke(int accessKeyId){
        AccessKey? accessKey = await _accessKeyRepository.Get(accessKeyId);
        if(accessKey is not null){
           _accessKeyRepository.RevokeAccessKey(accessKey);
           return true;
        } else {
            return false;
        }
    }
    //AccessKeyString = {Id}&{Code}
    public async Task<AccessKeyValidation> ValidateAccessKey(string accessKeyString){
        var match = MatchAccessKeyPattern(accessKeyString);
        string accessKeyCodeString;
        string accessKeyIdString;
        if (match.Success)
        {
            accessKeyIdString = match.Groups[1].Value;
            accessKeyCodeString = match.Groups[2].Value;
        }
        else
        {
            return new() { Message = "Chave de acesso em formato inválido", IsError = true};
        }

        int accessKeyId = int.Parse(accessKeyIdString);
        AccessKey? accessKey = await _accessKeyRepository.Get(accessKeyId);

        if(accessKey is null)
            return new(){ Message = "Id de chave não existe", IsError = true };

        if(_accessKeyRepository.CheckIfRevoked(accessKey))
            return new(){ Message = "Chave já revogada", IsError = true };
            
        bool validated = _accessKeyRepository.Validate(accessKey, accessKeyCodeString);
        if(validated){
            return new(){ Id = accessKeyId, Message = string.Empty, IsError = false };
        } else {
            return new(){ Message = "Chave de acesso inválida", IsError = true };
        }
    }
    private Match MatchAccessKeyPattern(string accessKeyString){
        Regex accessKeyRegex = AccessKeyRegex();
        return accessKeyRegex.Match(accessKeyString);
    }

    [GeneratedRegex(@"^([0-9]+)\&([A-Za-z0-9+/=]+)")]
    private static partial Regex AccessKeyRegex();
}