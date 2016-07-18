using System.Collections.Generic;
using System.Web.Mvc;

namespace DynamicTable.Models.ViewModel
{
    public class HomeViewModel
    {
    
        private List<RowItem> _RowList = new List<RowItem>();
        public List<RowItem> RowList
        {
            get { return _RowList ?? new List<RowItem>(); }
            set { _RowList = value; }
        }
    }

    public class RowItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Content { get; set; }
    }
}
