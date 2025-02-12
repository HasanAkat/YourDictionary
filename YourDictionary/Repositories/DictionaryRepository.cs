using System.Text.Json;
using YourDictionary.Models;


namespace YourDictionary.Repositories
{
    public class DictionaryRepository
    {
        private static readonly string FilePath = Path.Combine(AppContext.BaseDirectory, "dictionary.json");


        // JSON'dan kelimeleri yükleme
        public static List<Word> LoadWords()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Word>();
            }

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Word>>(json);
        }

        // JSON'a yeni kelime ekleme
        public static void AddWord(string term, string definition)
        {
            List<Word> words = LoadWords();
            words.Add(new Word { Term = term, Definition = definition });

            string json = JsonSerializer.Serialize(words, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        // JSON'dan kelime silme
        public static void DeleteWord(string term)
        {
            List<Word> words = LoadWords();
            words.RemoveAll(w => w.Term == term);

            string json = JsonSerializer.Serialize(words, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}