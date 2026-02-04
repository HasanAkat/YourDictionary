using System.Text.Json;
using YourDictionary.Models;

namespace YourDictionary.Repositories
{
    public static class DictionaryRepository
    {
        public static List<Word> LoadWords(string lessonId)
        {
            string filePath = LessonRepository.GetLessonFilePath(lessonId);
            if (!File.Exists(filePath))
            {
                return new List<Word>();
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Word>>(json) ?? new List<Word>();
        }

        public static void AddWord(string lessonId, string term, string definition)
        {
            List<Word> words = LoadWords(lessonId);
            words.Add(new Word { Term = term, Definition = definition });
            SaveWords(lessonId, words);
        }

        public static void DeleteWord(string lessonId, string term)
        {
            List<Word> words = LoadWords(lessonId);
            words.RemoveAll(w => w.Term == term);
            SaveWords(lessonId, words);
        }

        private static void SaveWords(string lessonId, List<Word> words)
        {
            string filePath = LessonRepository.GetLessonFilePath(lessonId);
            string json = JsonSerializer.Serialize(words, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
