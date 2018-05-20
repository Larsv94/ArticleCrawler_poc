using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticleCrawler_poc.Models
{
    public partial class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleID { get; set; }

        [Index(IsUnique =true)]
        public string Title { get; set; }

        public string Text { get; set; }
        public string Abstract { get; set; }



        public DateTime PublishedOn { get; set; }

        

        public virtual ICollection<ArticleCategorie> Categories { get; set; }
        public virtual Writer Writer { get; set; }
        public virtual ExternalLink Links { get; set; }
        public virtual GenerationInfo GenerationInfo { get; set; }

    }
}
