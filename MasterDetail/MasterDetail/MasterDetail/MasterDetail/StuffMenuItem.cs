using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDetail
{

    public class StuffMenuItem
    {
        public StuffMenuItem()
        {
            TargetType = typeof(StuffDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}