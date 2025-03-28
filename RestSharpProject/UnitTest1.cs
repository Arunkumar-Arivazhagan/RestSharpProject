using FluentAssertions;
using RestSharp;
using Xunit.Abstractions;

namespace RestSharpProject;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    [Fact]
    public async Task Test1()
    {

        var restClientOptions = new RestClientOptions
        {
            BaseUrl = new Uri("http://localhost:5001/"),
            RemoteCertificateValidationCallback = (sender, certificate, chain, errors)=> true
        };

        //Rest Client
        var client = new RestClient(restClientOptions);
        //Rest Request
        var request = new RestRequest("Product/GetProductById/1");
        //Perform GET operation
        var response = await client.GetAsync(request);
        //Assert
        response.Should().NotBeNull();
    }
}