namespace Flags.Data.Migrations
{
    using System.IO;
    using System.Linq;
    using System.Data.Entity.Migrations;

    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FlagsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FlagsDbContext context)
        {
            this.SeedFlags(context);
            this.SeedScores(context);
        }

        private void SeedFlags(FlagsDbContext context)
        {
            if (!context.Flags.Any())
            {
                var directoryPath = "E:/Technical-University-of-Sofia/Current/PS/Flags/Desktop/Flags.Desktop.Views/Content/Flags";
                var filePaths = Directory.GetFiles(directoryPath);

                foreach (var filePath in filePaths)
                {
                    var endIndex = filePath.LastIndexOf(".png");
                    var startIndex = filePath.LastIndexOf('\\');
                    var length = endIndex - startIndex - 1;
                    var name = filePath.Substring(startIndex + 1, length);

                    var flag = new Flag()
                    {
                        ImagePath = filePath,
                        Name = name
                    };

                    context.Flags.AddOrUpdate(flag);
                }

                context.SaveChanges();
            }
        }

        private void SeedScores(FlagsDbContext context)
        {
            if (!context.Scores.Any())
            {
                for (int i = 1; i <= 20; i++)
                {
                    var score = new Score()
                    {
                        PlayerName = "Name " + i,
                        Value = i * 1000
                    };

                    context.Scores.AddOrUpdate(score);
                }

                context.SaveChanges();
            }
        }
    }
}
