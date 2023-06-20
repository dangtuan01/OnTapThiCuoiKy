using Microsoft.AspNetCore.Mvc;

namespace OnTapThiCuoiKy.Dtos.Filters
{
    public class FilterDto
    {
        [FromQuery(Name = "PageIndex" )]
        public int PageIndex { get; set; }
        [FromQuery(Name = "PageSize")]
        public int PageSize { get; set; }
        private string _keyword;

        public string Keyword { get { return _keyword; } set {  _keyword = value.Trim(); } }
    }
}
