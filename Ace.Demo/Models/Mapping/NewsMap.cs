using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ace.Demo.Models.Mapping
{
    public class NewsMap : EntityTypeConfiguration<News>
    {
        public NewsMap()
        {
            // Primary Key
            this.HasKey(t => t.NewsID);

            // Properties
            this.Property(t => t.NewsTitle)
                .HasMaxLength(200);

            this.Property(t => t.ImageFile)
                .HasMaxLength(200);

            this.Property(t => t.CreDate)
                .HasMaxLength(50);

            this.Property(t => t.Source)
                .HasMaxLength(50);

            this.Property(t => t.Author)
                .HasMaxLength(50);

            this.Property(t => t.NewsType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("News");
            this.Property(t => t.NewsID).HasColumnName("NewsID");
            this.Property(t => t.NewsTitle).HasColumnName("NewsTitle");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.ImageFile).HasColumnName("ImageFile");
            this.Property(t => t.CreDate).HasColumnName("CreDate");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.ClickNumber).HasColumnName("ClickNumber");
            this.Property(t => t.NewsType).HasColumnName("NewsType");
        }
    }
}
