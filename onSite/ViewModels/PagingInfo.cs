using System;

namespace onSite.ViewModels
{
    public class PagingInfo
    {
        public int TotalRecords { get; set; }
        public int RecordsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalRecords / RecordsPerPage);
    }
}
