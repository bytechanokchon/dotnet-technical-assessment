namespace Applications.DTOs.Books
{
    public class BookDto
    {
        public required string Url { get; set; }
        public required string Method { get; set; }
        public object? Response { get; set; }
    }
}
