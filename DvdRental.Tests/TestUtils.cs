using Dapper;
using Newtonsoft.Json;
using DvdRental.Library.Mappers;

namespace DvdRental.Tests
{
    public class TestUtils
    {
        public const string INTEGRATION_TEST = "integration";
        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static void InitializeDbHandlers()
        {
            TypeMapper.Initialize("DvdRental.Library.Models");

            SqlMapper.AddTypeHandler(new StringTypeHandler());            
            SqlMapper.AddTypeHandler(new ProvinceTypeHandler());            
        }

        public static T? JsonFileToObject<T>(String filePath)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? throw new DirectoryNotFoundException();
            var path = System.IO.Path.Combine(directory, filePath);
            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<T?> JsonFileToObjectAsync<T>(String filePath)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? throw new DirectoryNotFoundException();
            var path = System.IO.Path.Combine(directory, filePath);
            var json = await File.ReadAllTextAsync(path);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void JsonObjectToFile(String filePath, string json)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? throw new DirectoryNotFoundException();
            var path = System.IO.Path.Combine(directory, filePath);

            File.WriteAllText(path, json);
        }

        public static async Task JsonObjectToFileAsync(String filePath, string json)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? throw new DirectoryNotFoundException();
            var path = System.IO.Path.Combine(directory, filePath);            

            await File.WriteAllTextAsync(path, json);
        }
    }

}
