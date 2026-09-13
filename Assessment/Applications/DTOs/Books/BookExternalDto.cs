using System.Text.Json.Serialization;

namespace Applications.DTOs.Books
{
    public class BookExternalDto
    {
        [JsonPropertyName("chapter_no")]
        public int ChapterNo { get; set; }

        [JsonPropertyName("verse_no")]
        public int VerseNo { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; } = string.Empty;

        [JsonPropertyName("chapter_name")]
        public string ChapterName { get; set; } = string.Empty;

        [JsonPropertyName("verse")]
        public string Verse { get; set; } = string.Empty;

        [JsonPropertyName("transliteration")]
        public string Transliteration { get; set; } = string.Empty;

        [JsonPropertyName("synonyms")]
        public string Synonyms { get; set; } = string.Empty;

        [JsonPropertyName("audio_link")]
        public string AudioLink { get; set; } = string.Empty;

        [JsonPropertyName("translation")]
        public string Translation { get; set; } = string.Empty;

        [JsonPropertyName("purport")]
        public List<string> Purport { get; set; } = new();
    }
}
