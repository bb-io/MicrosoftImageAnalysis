using Apps.AzureImageAnalysis.Connection;
using Blackbird.Applications.Sdk.Common.Authentication;
using Newtonsoft.Json;
using Tests.AzureImageAnalysis.Base;

namespace Tests.AzureImageAnalysis;

[TestClass]
public class ConnectionValidatorTests : TestBase
{
    [TestMethod]
    public async Task ValidateConnection_ValidData_ShouldBeSuccessful()
    {
        var validator = new ConnectionValidator();
        var result = await validator.ValidateConnection(Creds, CancellationToken.None);

        Console.WriteLine(JsonConvert.SerializeObject(result));
        Assert.IsTrue(result.IsValid);
    }

    [TestMethod]
    public async Task ValidateConnection_InvalidData_ShouldFail()
    {

        var newCredentials = Creds
            .Select(x => new AuthenticationCredentialsProvider(AuthenticationCredentialsRequestLocation.None, x.KeyName, x.Value + "_incorrect"));

        var validator = new ConnectionValidator();
        var result = await validator.ValidateConnection(newCredentials, CancellationToken.None);

        Console.WriteLine(JsonConvert.SerializeObject(result));
        Assert.IsFalse(result.IsValid);
    }
}
