namespace WebApi.Core
{
    public class PaginationConfiguration
    {
		const uint maxPageSize = 50;
		public uint PageNumber { get; set; } = 1;

		private uint _pageSize = 10;
		public uint PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}
	}
}
