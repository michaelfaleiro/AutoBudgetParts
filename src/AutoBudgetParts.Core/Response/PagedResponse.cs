namespace AutoBudgetParts.Core.Response;

public class PagedResponse<TData>(IEnumerable<TData> data, int pageNumber, int pageSize, int totalRecords)
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);
    public int TotalRecords { get; set; } = totalRecords;
    public IEnumerable<TData> Data { get; set; } = data;
}