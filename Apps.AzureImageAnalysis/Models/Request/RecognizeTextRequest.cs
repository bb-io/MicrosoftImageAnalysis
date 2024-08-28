using Apps.AzureImageAnalysis.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.AzureImageAnalysis.Models.Request;

public class RecognizeTextRequest
{
    [Display("File", Description = "The image or document to recognize text in")]
    public FileReference File { get; set; } = new();

    [Display("Pages", Description = "Custom page numbers for multi-page documents(PDF/TIFF), input the number of the pages you want to get OCR result.")]
    public IEnumerable<string>? Pages { get; set; }

    [Display("Reading order", Description = "By default, the service outputs the text lines in the left to right order. Optionally, with the readingOrder request parameter, use natural for a more human-friendly reading order output as shown in the following example. This feature is only supported for Latin languages."), StaticDataSource(typeof(ReadingOrderDataSources))]
    public string? ReadingOrder { get; set; }
    
    [Display("Language", Description = "Only provide a language code if you want to force the document to be processed as that specific language. Otherwise, the service may return incomplete and incorrect text"), StaticDataSource(typeof(LanguageDataHandler))]
    public string? Language { get; set; }
}