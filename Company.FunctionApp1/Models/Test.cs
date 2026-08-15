namespace Company.FunctionApp1.Models;

public class Test
{
    public string? Blah { get; set; }
    
    public bool IsThing { get; set; }

    public Test(Dictionary<string, string?> query)
    {
        Blah = query["blah"];
        IsThing = bool.TryParse(query["test"], out bool isThing) && isThing;
    }
}