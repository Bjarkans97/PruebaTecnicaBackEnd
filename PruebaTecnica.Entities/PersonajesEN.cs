namespace PruebaTecnica.Entities
{
    public class PersonajesEN
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string species { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public Localizacion origin { get; set; } = new();
        public string image { get; set; } = string.Empty;
        public List<string> episode { get; set; } = new();
    }

    public class Localizacion
    {
        public string name { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
    }

    public class ApiResponsePersonaje
    {
        public Info Info { get; set; } = new();
        public List<PersonajesEN> Results { get; set; } = new();
    }

}
