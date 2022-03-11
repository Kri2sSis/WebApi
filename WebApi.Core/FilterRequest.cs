namespace WebApi.Core
{
    public class FilterRequest
    {
        public PaginationConfiguration PaginationConfiguration { get; set; }

        public FilterConfiguration? FilterConfiguration { get; set; }
    }
}
