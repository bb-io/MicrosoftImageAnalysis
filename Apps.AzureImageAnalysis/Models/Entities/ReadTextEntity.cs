public class ReadTextEntity
{
    public string Status { get; set; } = string.Empty;
    
    public DateTime CreatedDateTime { get; set; }
    
    public DateTime LastUpdatedDateTime { get; set; }
    
    public AnalyzeResult AnalyzeResult { get; set; } = new();
}

public class AnalyzeResult
{
    public string Version { get; set; } = string.Empty;
    
    public string ModelVersion { get; set; } = string.Empty;
    
    public List<ReadResult> ReadResults { get; set; } = new();
}

public class ReadResult
{
    public int Page { get; set; }
    
    public double Angle { get; set; }
    
    public double Width { get; set; }
    
    public double Height { get; set; }
    
    public string Unit { get; set; } = string.Empty;
    
    public List<Line> Lines { get; set; } = new();
}

public class Line
{
    public List<double> BoundingBox { get; set; } = new();
    
    public string Text { get; set; } = string.Empty;
    
    public Appearance Appearance { get; set; } = new();
    
    public List<Word> Words { get; set; } = new();
}

public class Appearance
{
    public Style Style { get; set; } = new();
}

public class Style
{
    public string Name { get; set; } = string.Empty;
    
    public double Confidence { get; set; } 
}

public class Word
{
    public List<int> BoundingBox { get; set; } = new();
    
    public string Text { get; set; } = string.Empty;
    
    public double Confidence { get; set; }
}
