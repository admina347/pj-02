namespace EF.DataAccessLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset PublicationDate { get; set; }
    }
}