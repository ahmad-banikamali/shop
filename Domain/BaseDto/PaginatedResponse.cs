namespace Domain.BaseResponse
{
    public class PaginatedResponse<TEntity>
    {
        public int PageIndex { get;   set; }
        public int MaxItemsPerPage { get;   set; }
        public long ItemCountInPage { get;   set; }
        public IEnumerable<TEntity> Data { get;   set; }
    }
}