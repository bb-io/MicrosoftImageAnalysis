using Apps.AzureImageAnalysis.Actions;
using Apps.AzureImageAnalysis.Models.Request;
using Tests.AzureImageAnalysis.Base;

namespace Tests.AzureImageAnalysis
{
    [TestClass]
    public class OcrActionTests : TestBase
    {
        [TestMethod]
        public async Task RecognizeText_IsSuccess()
        {
            var action = new OcrActions(InvocationContext, FileManager);
            var request = new RecognizeTextRequest
            {
                File = new Blackbird.Applications.Sdk.Common.Files.FileReference
                {
                    Name = "test.png",
                    ContentType = "image/png"
                },
            };
            var response = await action.RecognizeText(request);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Assert.IsNotNull(response);
        }
    }
}
