using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbArticle
    {
        public TbArticle()
        {
            TbArticleComments = new HashSet<TbArticleComment>();
            TbArticleDetails = new HashSet<TbArticleDetail>();
            TbArticleMedia = new HashSet<TbArticleMedium>();
        }

        public Guid? ArticleId { get; set; }
        public Guid? PageId { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string TitleFr { get; set; }
        public string ShortDescriptionAr { get; set; }
        public string ShortDescriptionEn { get; set; }
        public string ShortDescriptionFr { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionFr { get; set; }
        public string MetaTags { get; set; }
        public string MetaDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CurrentState { get; set; }
        public bool ShowInHomePage { get; set; }

        public virtual ICollection<TbArticleComment> TbArticleComments { get; set; }
        public virtual ICollection<TbArticleDetail> TbArticleDetails { get; set; }
        public virtual ICollection<TbArticleMedium> TbArticleMedia { get; set; }
    }
}
