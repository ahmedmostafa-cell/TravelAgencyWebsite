using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbArticleComment
    {
        public Guid ArticleCommentId { get; set; }
        public Guid? ArticleId { get; set; }
        public Guid? MemberId { get; set; }
        public string CommentText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual TbArticle Article { get; set; }
    }
}
