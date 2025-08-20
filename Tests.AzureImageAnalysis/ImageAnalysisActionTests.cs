using Apps.AzureImageAnalysis.Actions;
using Apps.AzureImageAnalysis.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.AzureImageAnalysis.Base;

namespace Tests.AzureImageAnalysis
{
    [TestClass]
    public class ImageAnalysisActionTests :TestBase
    {
        [TestMethod]
        public async Task AnalyzeTags_IsSuccess()
        {
            var action = new ImageAnalysisActions(InvocationContext, FileManager);
            var request = new AnalyzeImageRequest
            {
                File = new Blackbird.Applications.Sdk.Common.Files.FileReference
                {
                    Name = "test.png",
                    ContentType = "image/png"
                },
            };
            var query = new AnalyzeImageQuery{};

            var response = await action.AnalyzeTags(request, query);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task AnalyzePeople_IsSuccess()
        {
            var action = new ImageAnalysisActions(InvocationContext, FileManager);
            var request = new AnalyzeImageRequest
            {
                File = new Blackbird.Applications.Sdk.Common.Files.FileReference
                {
                    Name = "test.png",
                    ContentType = "image/png"
                },
            };
            var query = new AnalyzeImageQuery { };

            var response = await action.AnalyzePeople(request, query);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task AnalyzeObjects_IsSuccess()
        {
            var action = new ImageAnalysisActions(InvocationContext, FileManager);
            var request = new AnalyzeImageRequest
            {
                File = new Blackbird.Applications.Sdk.Common.Files.FileReference
                {
                    Name = "test.png",
                    ContentType = "image/png"
                },
            };
            var query = new AnalyzeImageQuery { };

            var response = await action.AnalyzeObjects(request, query);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task AnalyzeCaptions_IsSuccess()
        {
            var action = new ImageAnalysisActions(InvocationContext, FileManager);
            var request = new AnalyzeImageRequest
            {
                File = new Blackbird.Applications.Sdk.Common.Files.FileReference
                {
                    Name = "test.png",
                    ContentType = "image/png"
                },
            };
            var query = new CaptionAnalysisQuery { };

            var response = await action.AnalyzeCaptions(request, query);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task AnalyzeDenseCaptions_IsSuccess()
        {
            var action = new ImageAnalysisActions(InvocationContext, FileManager);
            var request = new AnalyzeImageRequest
            {
                File = new Blackbird.Applications.Sdk.Common.Files.FileReference
                {
                    Name = "test.png",
                    ContentType = "image/png"
                },
            };
            var query = new CaptionAnalysisQuery { };

            var response = await action.AnalyzeDenseCaptions(request, query);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Assert.IsNotNull(response);
        }
    }
}
