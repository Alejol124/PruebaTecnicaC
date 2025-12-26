using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace PruebaTecnicaCosmo
{
    public class API
    {
        static string json = @"
[
  { ""id"": 1, ""name"": ""Ana"", ""role"": ""intern"", ""score"": 85, ""__key__"": ""x"" },
  { ""id"": 2, ""name"": ""Luis"", ""role"": ""dev"", ""score"": 60, ""__key__"": ""y"" },
  { ""id"": 3, ""name"": ""Sara"", ""role"": ""intern"", ""score"": 92, ""meta"": { ""__key__"": ""z"" } }
]
";
        public static void Procesar()
        {
            //Deserializo el JSON para trabajarlo
            var personas = JsonSerializer.Deserialize<List<Dictionary<String, object>>>(json);

            //Limpio
            foreach (var persona in personas)
            {
                LimpiarObjeto(persona);
            }

            //Parte A
            var filtrados = personas.Where(p =>
                p.ContainsKey("role") &&
                p.ContainsKey("score") &&
                p["role"].ToString() == "intern" &&
                int.Parse(p["score"].ToString()) >= 80
            ).ToList();
            
            //Parte B
            var resultadoFinal = filtrados.Select(p => new
            {
                id = p["id"],
                name = p["name"]
            }).ToList();

            //Impresión de resultados
            Console.WriteLine(JsonSerializer.Serialize(resultadoFinal, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }

        //Parte C
        private static void LimpiarObjeto(Dictionary<string, object> obj)
        {
            var clavesAEliminar = obj.Keys.Where(k => k.Contains("_")).ToList();

            foreach (var clave in clavesAEliminar)
            {
                obj.Remove(clave);
            }

            foreach (var valor in obj.Values)
            {
                if (valor is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Object)
                {
                    var subObj = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonElement.ToString());
                    LimpiarObjeto(subObj);
                }
            }
        }

    }
}
