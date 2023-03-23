using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.BLL.Interface.Enums;

namespace TaskList.BLL.Interface.Dtos
{
    public class SearchTaskListDto
    {
        public int Take { get; set; } = 10;
        public int Skip { get; set; } = 0;
        public string Search { get; set; }

        public SearchTaskListOrder OrderField { get; set; } = SearchTaskListOrder.CreatedDate;
        public OrderBy OrderBy { get; set; } = OrderBy.Desc;
    }
}
