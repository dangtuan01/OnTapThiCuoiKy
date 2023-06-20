namespace OnTapThiCuoiKy.Dtos.Filters
{
    public class PageResultDto<T>
    {
        public IEnumerable<T> Item { get; set; }
        public int TotalItem { get; set; }
    }
}
