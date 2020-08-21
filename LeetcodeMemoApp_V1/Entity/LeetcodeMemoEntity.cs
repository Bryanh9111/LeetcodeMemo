using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeetcodeMemoApp_V1.Entity
{
    [Table("LeetCodeMemo")]
    public class LeetcodeMemoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime? Entered_DateTime { get; set; }
        public int ProblemIndex { get; set; }
        public string ProblemName { get; set; }
        public string Note { get; set; }
        public DateTime? Last_Acted_On { get; set; }
        public int SubmitCount { get; set; }
    }
}
