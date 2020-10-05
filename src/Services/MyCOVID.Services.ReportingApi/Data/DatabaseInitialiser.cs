using System.Linq;
using MyCOVID.Services.ReportingApi.Model;

namespace MyCOVID.Services.ReportingApi.Data
{
    public static class DatabaseInitialiser
    {
        public static void Initialise(ReportingContext context)
        {
            context.Database.EnsureCreated();

            if (context.Blocks.Any())
                return;
            
            var blocks = new Block[]
            {
                // city campus
                new Block { Id = "Adsetts", Numbers = 0},
                new Block { Id = "Arundel", Numbers = 0},
                new Block { Id = "Aspect Court", Numbers = 0},
                new Block { Id = "Department of Art and Design", Numbers = 0},
                new Block { Id = "Eric Mensforth", Numbers = 0},
                new Block { Id = "Cantor", Numbers = 0},
                new Block { Id = "Charles Street", Numbers = 0},
                new Block { Id = "Harmer", Numbers = 0},
                new Block { Id = "Howard and Surrey", Numbers = 0},
                new Block { Id = "Sheaf", Numbers = 0},
                new Block { Id = "Stoddart", Numbers = 0},
                new Block { Id = "Surrey", Numbers = 0},
                
                // collegiate campus
                new Block { Id = "Chestnut Court", Numbers = 0},
                new Block { Id = "Collegiate Hall", Numbers = 0},
                new Block { Id = "Heart of the Campus", Numbers = 0},
                new Block { Id = "Library", Numbers = 0},
                new Block { Id = "Main Building", Numbers = 0},
                new Block { Id = "Robert Winston Building", Numbers = 0},
                new Block { Id = "Saunders Building", Numbers = 0},
                new Block { Id = "The Mews", Numbers = 0},
                new Block { Id = "Willow Court", Numbers = 0},
                new Block { Id = "Woodville", Numbers = 0},
            };
            
            context.Blocks.AddRange(blocks);
            context.SaveChanges();
        }
    }
}