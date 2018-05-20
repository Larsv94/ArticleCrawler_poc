using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleCrawler_poc.Models
{
    public partial class Writer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WriterID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<ExternalLink> Pages { get; set; }

            
    }
}