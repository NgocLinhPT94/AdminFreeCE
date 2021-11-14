using Automanager.Entity.EntityModel;
using System.Data.Entity.ModelConfiguration;

namespace Automanager.RepoImpl.MapEntyConfig
{
    public class TestLoginConfig : EntityTypeConfiguration<Test_Login>
    {
        public TestLoginConfig()
           : this("dbo") { }
        public TestLoginConfig(string schema)
        {
            ToTable("Test_Login", schema);
            HasKey(x => x.username);

            Property(x => x.username).HasColumnName(@"username").HasColumnType("nvarchar").IsRequired();
            Property(x => x.pass).HasColumnName(@"pass").HasColumnType("nvarchar").IsOptional();
            //Tham khaor
            //    Property(x => x.UnsignedName).HasColumnName(@"UnsignedName").HasColumnType("nvarchar(max)").IsRequired();
            //    Property(x => x.Gender).HasColumnName(@"Gender").HasColumnType("tinyint").IsRequired();
            //    Property(x => x.Email).HasColumnName(@"Email").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            //    Property(x => x.Status).HasColumnName(@"Status").HasColumnType("tinyint").IsRequired();
            //    Property(x => x.Avatar).HasColumnName(@"Avatar").HasColumnType("nvarchar").IsOptional().HasMaxLength(2000);
            //    Property(x => x.IsDelete).HasColumnName(@"IsDelete").HasColumnType("bit").IsRequired();
            //    Property(x => x.IsLocked).HasColumnName(@"IsLocked").HasColumnType("bit").IsRequired();
            //    Property(x => x.LockedToDateTime).HasColumnName(@"LockedToDateTime").HasColumnType("datetime").IsOptional();
            //    Property(x => x.LockedDateTimeLast).HasColumnName(@"LockedDateTimeLast").HasColumnType("datetime")
            //        .IsOptional();
            //    Property(x => x.LoginFailureFirstDateTime).HasColumnName(@"LoginFailureFirstDateTime")
            //        .HasColumnType("datetime").IsOptional();
            //}
        }
    }
}
