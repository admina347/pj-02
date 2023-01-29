using Microsoft.AspNetCore.Mvc.Rendering;

namespace EF.Web.Models.ViewModels
{
    public class SearchViewModel
    {
        public int SelectedGenreId  { get; set; }
        public int SelectedAuthorId  { get; set; }
        public string BookTitle { get; set; }
        public DateTime SatrtDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}