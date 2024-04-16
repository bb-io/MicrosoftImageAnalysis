using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.AzureImageAnalysis.DataSourceHandlers;

public class LanguageDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "ar", "Arabic" },
        { "az", "Azerbaijani" },
        { "bg", "Bulgarian" },
        { "bs", "Bosnian Latin" },
        { "ca", "Catalan" },
        { "cs", "Czech" },
        { "cy", "Welsh" },
        { "da", "Danish" },
        { "de", "German" },
        { "el", "Greek" },
        { "en", "English" },
        { "es", "Spanish" },
        { "et", "Estonian" },
        { "eu", "Basque" },
        { "fi", "Finnish" },
        { "fr", "French" },
        { "ga", "Irish" },
        { "gl", "Galician" },
        { "he", "Hebrew" },
        { "hi", "Hindi" },
        { "hr", "Croatian" },
        { "hu", "Hungarian" },
        { "id", "Indonesian" },
        { "it", "Italian" },
        { "ja", "Japanese" },
        { "kk", "Kazakh" },
        { "ko", "Korean" },
        { "lt", "Lithuanian" },
        { "lv", "Latvian" },
        { "mk", "Macedonian" },
        { "ms", "Malay Malaysia" },
        { "nb", "Norwegian (Bokmal)" },
        { "nl", "Dutch" },
        { "pl", "Polish" },
        { "prs", "Dari" },
        { "pt-BR", "Portuguese-Brazil" },
        { "pt", "Portuguese-Portugal" },
        { "pt-PT", "Portuguese-Portugal" },
        { "ro", "Romanian" },
        { "ru", "Russian" },
        { "sk", "Slovak" },
        { "sl", "Slovenian" },
        { "sr-Cryl", "Serbian - Cyrillic RS" },
        { "sr-Latn", "Serbian - Latin RS" },
        { "sv", "Swedish" },
        { "th", "Thai" },
        { "tr", "Turkish" },
        { "uk", "Ukrainian" },
        { "vi", "Vietnamese" },
        { "zh", "Chinese Simplified" },
        { "zh-Hans", "Chinese Simplified" },
        { "zh-Hant", "Chinese Traditional" }
    };
}