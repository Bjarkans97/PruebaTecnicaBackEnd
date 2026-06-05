namespace PruebaTecnica.Entities;
public class EpisodioEN
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string AirDate { get; set; } = string.Empty;
    public List<string> Characters { get; set; } = new();
    public string CharactersLinq { get; set; } = string.Empty;
    public string EpisodeCode { get; set; } = string.Empty;
}

public class ApiResponse
{
    public Info Info { get; set; } = new();
    public List<ApiEpisodio> Results { get; set; } = new();
}

public class Info
{
    public int Count { get; set; }
    public int Pages { get; set; }
    public string? Next { get; set; }
}

public class ApiEpisodio
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Air_date { get; set; } = string.Empty;
    public List<string> Characters { get; set; } = new();
    public string Episode { get; set; } = string.Empty;
}