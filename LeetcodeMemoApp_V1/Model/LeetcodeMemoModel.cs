using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeMemoApp_V1.Model
{
    public class LeetcodeMemoModel
    {
        public int ID { get; set; }
        public DateTime? Entered_DateTime { get; set; }
        public int ProblemIndex { get; set; }
        public string ProblemName { get; set; }
        public string Note { get; set; }
        public DateTime? Last_Acted_On { get; set; }
        public int SubmitCount { get; set; }
    }
}
