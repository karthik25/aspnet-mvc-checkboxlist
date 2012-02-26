using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAppForCheckBoxList.Models
{
    public class CheckBoxListViewModel
    {
        public string HeaderText { get; set; }
        public List<CheckBoxListItem> Items { get; set; }

        public string[] GetSelectedItems()
        {
            return this.Items.Where(s => s.IsChecked).Select(s => s.Value).ToArray();
        }
    }
}
