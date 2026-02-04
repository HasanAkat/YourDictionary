using System.Text;
using System.Text.Json;
using YourDictionary.Models;

namespace YourDictionary.Repositories
{
    public static class LessonRepository
    {
        private static readonly string LessonsDirectory = Path.Combine(AppContext.BaseDirectory, "Lessons");
        private static readonly string LessonsMetadataPath = Path.Combine(LessonsDirectory, "lessons.json");
        private static readonly string LegacyDictionaryPath = Path.Combine(AppContext.BaseDirectory, "dictionary.json");

        public static IReadOnlyList<LessonInfo> LoadLessons()
        {
            return LoadLessonsInternal()
                .OrderBy(lesson => lesson.Name, StringComparer.CurrentCultureIgnoreCase)
                .ToList();
        }

        public static LessonInfo CreateLesson(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Lesson name cannot be empty.", nameof(name));
            }

            EnsureStorageReady();
            string trimmedName = name.Trim();
            List<LessonInfo> lessons = LoadLessonsInternal();

            if (lessons.Any(lesson => lesson.Name.Equals(trimmedName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("A lesson with the same name already exists.");
            }

            string lessonId = GenerateUniqueLessonId(trimmedName, lessons);
            LessonInfo newLesson = new()
            {
                Id = lessonId,
                Name = trimmedName
            };

            lessons.Add(newLesson);
            SaveLessonsInternal(lessons);
            EnsureLessonFileExists(lessonId);

            return newLesson;
        }

        public static LessonInfo? GetLesson(string lessonId)
        {
            if (string.IsNullOrWhiteSpace(lessonId))
            {
                return null;
            }

            return LoadLessonsInternal()
                .FirstOrDefault(lesson => lesson.Id.Equals(lessonId, StringComparison.OrdinalIgnoreCase));
        }

        public static string GetLessonFilePath(string lessonId)
        {
            EnsureStorageReady();
            return Path.Combine(LessonsDirectory, $"{lessonId}.json");
        }

        public static void TryMigrateLegacyDictionary()
        {
            EnsureStorageReady();

            if (!File.Exists(LegacyDictionaryPath))
            {
                return;
            }

            List<LessonInfo> lessons = LoadLessonsInternal();
            if (lessons.Count > 0)
            {
                return;
            }

            LessonInfo defaultLesson = CreateLesson("Default Lesson");
            string destinationFile = GetLessonFilePath(defaultLesson.Id);
            File.Copy(LegacyDictionaryPath, destinationFile, true);
        }

        private static void EnsureLessonFileExists(string lessonId)
        {
            string filePath = GetLessonFilePath(lessonId);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]", Encoding.UTF8);
            }
        }

        private static void EnsureStorageReady()
        {
            if (!Directory.Exists(LessonsDirectory))
            {
                Directory.CreateDirectory(LessonsDirectory);
            }

            if (!File.Exists(LessonsMetadataPath))
            {
                File.WriteAllText(LessonsMetadataPath, "[]", Encoding.UTF8);
            }
        }

        private static List<LessonInfo> LoadLessonsInternal()
        {
            EnsureStorageReady();
            try
            {
                string rawJson = File.ReadAllText(LessonsMetadataPath);
                return JsonSerializer.Deserialize<List<LessonInfo>>(rawJson) ?? new List<LessonInfo>();
            }
            catch
            {
                return new List<LessonInfo>();
            }
        }

        private static void SaveLessonsInternal(IEnumerable<LessonInfo> lessons)
        {
            EnsureStorageReady();
            string json = JsonSerializer.Serialize(lessons, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(LessonsMetadataPath, json, Encoding.UTF8);
        }

        private static string GenerateUniqueLessonId(string lessonName, IEnumerable<LessonInfo> existingLessons)
        {
            string baseId = GenerateSlug(lessonName);
            string uniqueId = baseId;
            int suffix = 2;

            bool LessonIdExists(string id) =>
                existingLessons.Any(lesson => lesson.Id.Equals(id, StringComparison.OrdinalIgnoreCase)) ||
                File.Exists(GetLessonFilePath(id));

            while (LessonIdExists(uniqueId))
            {
                uniqueId = $"{baseId}-{suffix++}";
            }

            return uniqueId;
        }

        private static string GenerateSlug(string input)
        {
            string normalized = input.Trim().ToLowerInvariant();
            var builder = new StringBuilder();

            foreach (char ch in normalized)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    builder.Append(ch);
                }
                else if (ch == ' ' || ch == '-' || ch == '_')
                {
                    builder.Append('-');
                }
            }

            string slug = builder.ToString().Trim('-');
            return string.IsNullOrWhiteSpace(slug) ? $"lesson-{Guid.NewGuid():N}" : slug;
        }
    }
}
