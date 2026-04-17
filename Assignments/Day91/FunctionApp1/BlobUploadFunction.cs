using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

public class BlobUploadFunction
{
    private readonly ILogger _logger;

    public BlobUploadFunction(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<BlobUploadFunction>();
    }

    [Function("BlobUploadFunction")]
    public async Task Run(
        [BlobTrigger("uploads/{name}", Connection = "AzureWebJobsStorage")] Stream blob,
        string name)
    {
        _logger.LogInformation($"Blob detected: {name}");

        var logicAppUrl = "https://prod-46.westeurope.logic.azure.com:443/workflows/2bc7dae5432845c89d59e7076ea52d66/triggers/When_an_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_an_HTTP_request_is_received%2Frun&sv=1.0&sig=aTKGCcEO97Uvqoq5QILNSPOlLzf72f3p_cs_15J14rc";

        using var client = new HttpClient();

        var json = $"{{ \"fileName\": \"{name}\" }}";

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PostAsync(logicAppUrl, content);
    }
}
