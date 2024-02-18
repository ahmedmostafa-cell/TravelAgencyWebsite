using System;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VipAssistProject.Models
{
    public partial class VipAssistDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public VipAssistDatabaseContext()
        {
        }

        public VipAssistDatabaseContext(DbContextOptions<VipAssistDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAboutU> TbAboutUs { get; set; }
        public virtual DbSet<TbAdvertisingMethod> TbAdvertisingMethods { get; set; }
        public virtual DbSet<TbArticle> TbArticles { get; set; }
        public virtual DbSet<TbArticleComment> TbArticleComments { get; set; }
        public virtual DbSet<TbArticleDetail> TbArticleDetails { get; set; }
        public virtual DbSet<TbArticleMedium> TbArticleMedia { get; set; }
        public virtual DbSet<TbCart> TbCarts { get; set; }
        public virtual DbSet<TbCurrency> TbCurrencies { get; set; }
        public virtual DbSet<TbDiscount> TbDiscounts { get; set; }
        public virtual DbSet<TbEmailTemplate> TbEmailTemplates { get; set; }
        public virtual DbSet<TbErrorLog> TbErrorLogs { get; set; }
        public virtual DbSet<TbFaq> TbFaqs { get; set; }
        public virtual DbSet<TbLanguage> TbLanguages { get; set; }
        public virtual DbSet<TbMessage> TbMessages { get; set; }
        public virtual DbSet<TbNewsLetter> TbNewsLetters { get; set; }
        public virtual DbSet<TbPaymentMethod> TbPaymentMethods { get; set; }
        public virtual DbSet<TbReview> TbReviews { get; set; }
        public virtual DbSet<TbSalesInvoice> TbSalesInvoices { get; set; }
        public virtual DbSet<TbSalesInvoiceService> TbSalesInvoiceServices { get; set; }
        public virtual DbSet<TbService> TbServices { get; set; }
        public virtual DbSet<TbServiceCategory> TbServiceCategories { get; set; }
        public virtual DbSet<TbServiceFeature> TbServiceFeatures { get; set; }
        public virtual DbSet<TbServiceMedium> TbServiceMedia { get; set; }
        public virtual DbSet<TbSetting> TbSettings { get; set; }
        public virtual DbSet<TbSliderImage> TbSliderImages { get; set; }
        public virtual DbSet<TbVideo> TbVideos { get; set; }
        public virtual DbSet<TbWhyU> TbWhyUs { get; set; }
        public virtual DbSet<TbWishList> TbWishLists { get; set; }
        public virtual DbSet<VwGetServiceList> VwGetServiceList { get; set; }
        public virtual DbSet<VwViewServiceMemberOrder> VwViewServiceMemberOrder { get; set; }
        public virtual DbSet<VwViewServiceMemberOrderr> VwViewServiceMemberOrderr { get; set; }
        public virtual DbSet<InvoicesSummary> InvoicesSummary { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<InvoiceDetailsNew> InvoiceDetailsNew { get; set; }
        public virtual DbSet<VwLoyalityPoints> VwLoyalityPoints { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAboutU>(entity =>
            {
                entity.HasKey(e => e.AboutUsId);

                entity.Property(e => e.AboutUsId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.TitleAr).HasMaxLength(200);

                entity.Property(e => e.TitleEn).HasMaxLength(200);

                entity.Property(e => e.TitleFr).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbAdvertisingMethod>(entity =>
            {
                entity.HasKey(e => e.AdvertiseMethodId);

                entity.Property(e => e.AdvertiseMethodId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DescriptionAr)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.DescriptionEn)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TitleAr)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TitleEn)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TitleFr)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbArticle>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.Property(e => e.ArticleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.MetaDescription).HasMaxLength(200);

                entity.Property(e => e.MetaTags).HasMaxLength(200);

                entity.Property(e => e.ShortDescriptionAr).HasMaxLength(200);

                entity.Property(e => e.ShortDescriptionEn).HasMaxLength(200);

                entity.Property(e => e.ShortDescriptionFr).HasMaxLength(200);

                entity.Property(e => e.TitleAr).HasMaxLength(200);

                entity.Property(e => e.TitleEn).HasMaxLength(200);

                entity.Property(e => e.TitleFr).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbArticleComment>(entity =>
            {
                entity.HasKey(e => e.ArticleCommentId);

                entity.Property(e => e.ArticleCommentId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.TbArticleComments)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_TbArticleComments_TbArticles");
            });

            modelBuilder.Entity<TbArticleDetail>(entity =>
            {
                entity.HasKey(e => e.ArticleDetailsId);

                entity.Property(e => e.ArticleDetailsId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DetailsTitleAr).HasMaxLength(250);

                entity.Property(e => e.DetailsTitleEn).HasMaxLength(250);

                entity.Property(e => e.DetailsTitleFr).HasMaxLength(250);

                entity.Property(e => e.Path).HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.TbArticleDetails)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_TbArticleDetails_TbArticles");
            });

            modelBuilder.Entity<TbArticleMedium>(entity =>
            {
                entity.HasKey(e => e.ArticleMediaId);

                entity.Property(e => e.ArticleMediaId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDefault).HasDefaultValueSql("((0))");

                entity.Property(e => e.Path).HasMaxLength(250);

                entity.Property(e => e.TitleAr).HasMaxLength(200);

                entity.Property(e => e.TitleEn).HasMaxLength(200);

                entity.Property(e => e.TitleFr).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.TbArticleMedia)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_TbArticleMedia_TbArticles");
            });

            modelBuilder.Entity<TbCart>(entity =>
            {
                entity.HasKey(e => e.CartId);

                entity.ToTable("TbCart");

                entity.Property(e => e.CartId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BookingPrice).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.NewSalePrice).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Qty).HasDefaultValueSql("((1))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TitleAr).HasMaxLength(200);

                entity.Property(e => e.TitleEn).HasMaxLength(200);

                entity.Property(e => e.TitleFr).HasMaxLength(200);

                entity.Property(e => e.TotalByItem).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbCarts)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbCart_TbServices");
            });

            modelBuilder.Entity<TbCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.ToTable("TbCurrency");

                entity.Property(e => e.CurrencyId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.CurrencySymbol)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbDiscount>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.ToTable("TbDiscount");

                entity.Property(e => e.DiscountId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DiscountValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsPermanent).HasDefaultValueSql("((0))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbDiscounts)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbDiscount_TbServices");
            });

            modelBuilder.Entity<TbEmailTemplate>(entity =>
            {
                entity.HasKey(e => e.EmailTemplateId);

                entity.ToTable("TbEmailTemplate");

                entity.Property(e => e.EmailTemplateId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Categories).HasMaxLength(600);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Files)
                    .HasMaxLength(600)
                    .HasColumnName("files");

                entity.Property(e => e.MessageTitle).HasMaxLength(300);

                entity.Property(e => e.Services).HasMaxLength(600);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbErrorLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("TbErrorLog");

                entity.Property(e => e.LogId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClassName).HasMaxLength(150);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MethodName).HasMaxLength(150);
            });

            modelBuilder.Entity<TbFaq>(entity =>
            {
                entity.HasKey(e => e.Faqid)
                    .HasName("PK_TbFaq");

                entity.ToTable("TbFAQ");

                entity.Property(e => e.Faqid)
                    .HasColumnName("FAQId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Question).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbLanguage>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.ToTable("TbLanguage");

                entity.Property(e => e.LanguageId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDefault)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbMessage>(entity =>
            {
                entity.HasKey(e => e.MessagesId);

                entity.Property(e => e.MessagesId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbNewsLetter>(entity =>
            {
                entity.HasKey(e => e.NewsLetterId);

                entity.Property(e => e.NewsLetterId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).HasMaxLength(315);
            });

            modelBuilder.Entity<TbPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId);

                entity.Property(e => e.PaymentMethodId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.NameAr).HasMaxLength(50);

                entity.Property(e => e.NameEn).HasMaxLength(50);

                entity.Property(e => e.NameFr).HasMaxLength(50);

                entity.Property(e => e.Path).HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId);

                entity.Property(e => e.ReviewId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReviewText)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbReviews)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbReviews_TbServices");
            });

            modelBuilder.Entity<TbSalesInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.ToTable("TbSalesInvoice");

                entity.Property(e => e.InvoiceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.TbSalesInvoices)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_TbSalesInvoice_TbPaymentMethods");
            });

            modelBuilder.Entity<TbSalesInvoiceService>(entity =>
            {
                entity.HasKey(e => e.InvoiceServiceId);

                entity.Property(e => e.InvoiceServiceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoicePrice).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Qty).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.TbSalesInvoiceServices)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_TbSalesInvoiceServices_TbSalesInvoice");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbSalesInvoiceServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbSalesInvoiceServices_TbServices");
            });

            modelBuilder.Entity<TbService>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.ServiceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BookingPrice).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.MetaDescription).HasMaxLength(200);

                entity.Property(e => e.MetaTags).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.ServiceCode).HasMaxLength(10);

                entity.Property(e => e.ShortDescriptionAr).HasMaxLength(200);

                entity.Property(e => e.ShortDescriptionEn).HasMaxLength(200);

                entity.Property(e => e.ShortDescriptionFr).HasMaxLength(200);

                entity.Property(e => e.TitleAr).HasMaxLength(200);

                entity.Property(e => e.TitleEn).HasMaxLength(200);

                entity.Property(e => e.TitleFr).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.TbServices)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .HasConstraintName("FK_TbServices_TbServiceCategory");
            });

            modelBuilder.Entity<TbServiceCategory>(entity =>
            {
                entity.HasKey(e => e.ServiceCategoryId);

                entity.ToTable("TbServiceCategory");

                entity.Property(e => e.ServiceCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.TitleAr).HasMaxLength(200);

                entity.Property(e => e.TitleEn).HasMaxLength(200);

                entity.Property(e => e.TitleFr).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbServiceFeature>(entity =>
            {
                entity.HasKey(e => e.FeatureId);

                entity.Property(e => e.FeatureId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.FeatureTextAr).HasMaxLength(200);

                entity.Property(e => e.FeatureTextEn).HasMaxLength(200);

                entity.Property(e => e.FeatureTextFr)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbServiceFeatures)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbServiceFeatures_TbServices");
            });

            modelBuilder.Entity<TbServiceMedium>(entity =>
            {
                entity.HasKey(e => e.ServiceMediaId);

                entity.Property(e => e.ServiceMediaId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Path).HasMaxLength(100);

                entity.Property(e => e.TitleAr).HasMaxLength(200);

                entity.Property(e => e.TitleEn).HasMaxLength(200);

                entity.Property(e => e.TitleFr).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbServiceMedia)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbServiceMedia_TbServices");
            });

            modelBuilder.Entity<TbSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.Property(e => e.SettingId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(315)
                    .IsUnicode(false);

                entity.Property(e => e.Logo).HasMaxLength(100);

                entity.Property(e => e.MainImage).HasMaxLength(100);

                entity.Property(e => e.MainVideo).HasMaxLength(250);

                entity.Property(e => e.MetaTags).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.SiteNameAr).HasMaxLength(100);

                entity.Property(e => e.SiteNameEn).HasMaxLength(100);

                entity.Property(e => e.SiteNameFr).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WhatsNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<TbSliderImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.ImageOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImagePath).HasMaxLength(100);

                entity.Property(e => e.ImageTextAr).HasMaxLength(200);

                entity.Property(e => e.ImageTextEn).HasMaxLength(200);

                entity.Property(e => e.ImageTextFr).HasMaxLength(200);

                entity.Property(e => e.ImageTitleAr).HasMaxLength(100);

                entity.Property(e => e.ImageTitleEn).HasMaxLength(100);

                entity.Property(e => e.ImageTitleFr).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbVideo>(entity =>
            {
                entity.HasKey(e => e.VideoId);

                entity.Property(e => e.VideoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DescriptionAr).HasMaxLength(500);

                entity.Property(e => e.DescriptionEn).HasMaxLength(500);

                entity.Property(e => e.DescriptionFr).HasMaxLength(500);

                entity.Property(e => e.TitleAr).HasMaxLength(200);

                entity.Property(e => e.TitleEn).HasMaxLength(200);

                entity.Property(e => e.TitleFr).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbWhyU>(entity =>
            {
                entity.HasKey(e => e.WhyUsId);

                entity.Property(e => e.WhyUsId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.TitleAr).HasMaxLength(200);

                entity.Property(e => e.TitleEn).HasMaxLength(200);

                entity.Property(e => e.TitleFr).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwGetServiceList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwGetServiceList");


            });
            modelBuilder.Entity<InvoiceDetailsNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("InvoiceDetailsNew");


            });

            modelBuilder.Entity<VwLoyalityPoints>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwLoyalityPoints");


            });



            

            modelBuilder.Entity<VwViewServiceMemberOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwViewServiceMemberOrder");


            });
            modelBuilder.Entity<VwViewServiceMemberOrderr>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwViewServiceMemberOrderr");


            });

            modelBuilder.Entity<InvoicesSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("InvoicesSummary");


            });

            modelBuilder.Entity<InvoiceDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("InvoiceDetails");


            });



            modelBuilder.Entity<TbWishList>(entity =>
            {
                entity.HasKey(e => e.WishListId);

                entity.ToTable("TbWishList");

                entity.Property(e => e.WishListId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BookingPrice).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.NewSalePrice).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TitleAr).HasMaxLength(200);

                entity.Property(e => e.TitleEn).HasMaxLength(200);

                entity.Property(e => e.TitleFr).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TbWishLists)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_TbWishList_TbServices");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
