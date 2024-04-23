using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGIS.Models
{
    public class Result_HTTP
    {
        public Parameters result { get; set; }
    }
    public class Parameters
    {
        public int count { get; set; }
        public int start { get; set; }
        public int rows { get; set; }
        public List<Item> items { get; set; }
    }
    public class List_Item
    {
        public List<Item> items { get; set; }
    }
    public class Result
    {
        public List<Item> items { get; set; }
    }
}
