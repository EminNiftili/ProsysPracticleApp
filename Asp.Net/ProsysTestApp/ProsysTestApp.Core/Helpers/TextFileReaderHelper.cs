namespace ProsysTestApp.Core.Helpers
{
    public static class TextFileReaderHelper
    {
        public static async Task<string> ReadAsStringAsync(string path)
        {
            using var reader = new StreamReader(path);
            var content = await reader.ReadToEndAsync();
            reader.Close();

            return content;
        }
    }
}
