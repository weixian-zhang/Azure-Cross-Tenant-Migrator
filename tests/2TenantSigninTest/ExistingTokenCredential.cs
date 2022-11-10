

using Azure.Core;

public class ExistingTokenCredential : TokenCredential
{
    private string _token;
    private AccessToken _accessToken;

    public ExistingTokenCredential(string accessToken, DateTime dt)
    {
        var utcTime1 = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
        DateTimeOffset dtoffset = utcTime1;

        _token = accessToken;
        _accessToken = new AccessToken(_token, dtoffset);
    }

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return _accessToken;
    }

    public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult<AccessToken>(_accessToken);
    }
}