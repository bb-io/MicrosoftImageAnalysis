using static System.String;

namespace Apps.AzureImageAnalysis.Models.Response;

public class RecognizeTextResponse
{
    public string Status { get; set; }
 
    public string Text { get; set; }
 
    public List<PageResponse> Pages { get; set; }

    public RecognizeTextResponse(ReadTextEntity entity)
    {
        Status = entity.Status;
        Text = Join(" ", entity.AnalyzeResult.ReadResults
            .SelectMany(x => x.Lines)
            .Select(x => x.Text));
        Pages = entity.AnalyzeResult.ReadResults.Select(x => new PageResponse
        {
            Number = x.Page,
            Lines = x.Lines.Select(y => new LineResponse
            {
                Text = y.Text,
                Confidence = y.Appearance?.Style?.Confidence ?? 0,
                Words = y.Words.Select(z => z.Text).ToList()
            }).ToList(),
        
            Text = string.Join(" ", x.Lines.Select(y => y.Text))
        }).ToList();
    }
}

public class PageResponse
{
    public int Number { get; set; }
 
    public List<LineResponse> Lines { get; set; } = [];

    public string Text { get; set; } = Empty;
}

public class LineResponse
{
    public string Text { get; set; } = Empty;
 
    public double Confidence { get; set; }

    public List<string> Words { get; set; } = [];
}

