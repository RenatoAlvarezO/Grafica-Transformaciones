using System;
using System.IO;
using System.Text.Json;

namespace Escenario
{
    public class JSONLoader
    {
        static public void SaveFile(string path, Object3D objectToSerialize)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            string jsonOutput = JsonSerializer.Serialize(objectToSerialize, options);

            File.WriteAllText(path, jsonOutput);
        }

        static public Object3D LoadFile(string path)
        {
            string outputString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Object3D>(outputString);
        }
    }
}