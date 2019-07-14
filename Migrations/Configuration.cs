namespace Lighthouse.Migrations
{
    using Lighthouse.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //context.Messages.AddOrUpdate(i => i.Id,
            //    new Message
            //    {
            //        Id = 1,
            //        MessageDetails = "This is the first message",
            //        DateSubmitted = DateTime.UtcNow
            //    });

            //context.PrayerRequests.AddOrUpdate(i => i.Id,
            //    new PrayerRequest
            //    {
            //        Id = 1,
            //        RequestDetails = "This is a prayer request",
            //        DateSubmitted = DateTime.UtcNow
            //    });
        }
    }
}
