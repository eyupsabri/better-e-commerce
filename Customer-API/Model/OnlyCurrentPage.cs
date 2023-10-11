namespace Customer_API.Model
{
    public class OnlyCurrentPage
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public Boolean SortAsc { get; set; }
        
    }
}
