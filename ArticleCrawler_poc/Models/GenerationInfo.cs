using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleCrawler_poc.Models
{
    [ComplexType]
    public partial class GenerationInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; }

    }
}