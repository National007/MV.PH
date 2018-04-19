using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV.PH.WebAdmin.Model.PageHelp
{
    public class PageListModel<T>
    {
            public PageListModel()
            {
                this.Data = new List<T>();
            }

            public PageListModel(IList<T> items, int pageIndex, int pageSize)
                : this()
            {
                PageSize = pageSize;
                TotalItemCount = items.Count;
                CurrentPageIndex = pageIndex;
                for (int i = StartRecordIndex - 1; i < EndRecordIndex; i++)
                {
                    this.Data.Add(items[i]);
                }
            }

            public PageListModel(IEnumerable<T> items, int pageIndex, int pageSize, int totalItemCount)
                : this()
            {
                //   this.Data.AddRange(items);
                this.Data = items.ToList();
                TotalItemCount = totalItemCount;
                CurrentPageIndex = pageIndex;
                PageSize = pageSize;
            }

            public int CurrentPageIndex { get; set; }
            public int PageSize { get; set; }
            public int TotalItemCount { get; set; }
            public int TotalPageCount { get { return (int)Math.Ceiling(TotalItemCount / (double)PageSize); } }
            public int StartRecordIndex { get { return (CurrentPageIndex - 1) * PageSize + 1; } }
            public int EndRecordIndex { get { return TotalItemCount > CurrentPageIndex * PageSize ? CurrentPageIndex * PageSize : TotalItemCount; } }

            public List<T> Data { get; set; }

}
}