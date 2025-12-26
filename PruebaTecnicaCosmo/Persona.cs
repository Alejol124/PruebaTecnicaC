using System.Collections.Generic;

namespace PruebaTecnicaCosmo
{
    public class Persona
    {
        public int id { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public int score { get; set; }
        public Dictionary<string, object> meta { get; set; }
    }
}
