namespace Sample.Data.Migrations
{
    using Contexts;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Models;
    using System.IO;
    using Newtonsoft.Json;

    public sealed class Configuration : DbMigrationsConfiguration<SampleDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SampleDbContext context)
        {
            this.SeedCountries(context);
        }

        private void SeedCountries(SampleDbContext context)
        {
            var countriesExist = context.Countries.Any();

            if (!countriesExist)
            {
                var path = "E:\\Telerik-Academy\\AngularJS\\AngularJS-Architecture\\Server\\Source\\Data\\Sample.Data\\Sources\\world-countries.json";

                using (StreamReader r = new StreamReader(path))
                {
                    var json = r.ReadToEnd();
                    var jsonDeserialized = JsonConvert.DeserializeObject<CountriesJSONModel>(json);
                    var countries = jsonDeserialized.Countries;
                    var length = countries.Length;

                    for (int i = 0, k = 0; i < length; i++, k++)
                    {
                        context.Countries.Add(countries[i]);

                        if (k % 100 >= 1)
                        {
                            context.SaveChanges();
                            k = 0;
                        }
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}