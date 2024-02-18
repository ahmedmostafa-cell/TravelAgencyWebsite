using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbArticleDetail
    {
        public Guid ArticleDetailsId { get; set; }
        public Guid? ArticleId { get; set; }
        public int? ParagraphOrder { get; set; }
        public string DetailsTitleAr { get; set; }
        public string DetailsTitleEn { get; set; }
        public string DetailsTitleFr { get; set; }
        public string DetailsDescriptionAr { get; set; }
        public string DetailsDescriptionEn { get; set; }
        public string DetailsDescriptionFr { get; set; }
        public int? MediaType { get; set; }
        public string Path { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbArticle Article { get; set; }
    }
}
