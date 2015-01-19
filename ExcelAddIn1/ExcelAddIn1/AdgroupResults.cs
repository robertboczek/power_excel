using GraphCaller;
using System;
using System.Collections.Generic;
using System.Data;

namespace ExcelAddIn1
{
    public class AdgroupResults
    {
        public List<AdGroups> Adgroups { get; set; }
        public HashSet<string> Fields { get; set; }

        public AdgroupResults()
        {
        }
    }
}