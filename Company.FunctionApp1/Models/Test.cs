namespace Company.FunctionApp1.Models;

public class Test : QueryParamDto
{
    public string? Blah { get; set; }
    
    public bool? IsThing { get; set; }

    public Test(Dictionary<string, string?> query)
    {
        var isThing = query.GetValueOrDefault("isThing", null);
        Blah = query.GetValueOrDefault("blah", null);
        IsThing = string.IsNullOrEmpty(isThing) ? null : bool.TryParse(isThing, out bool val) && val;
    }
}