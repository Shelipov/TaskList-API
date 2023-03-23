using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.BLL.Interface.Common
{
    public class PagedResponse<TItem>
    {
        public int TotalCount { get; }

        public IEnumerable<TItem> Items { get; }

        public PagedResponse(int totalCount, IEnumerable<TItem> items)
        {
            TotalCount = totalCount;
            Items = items;
        }
    }
}
