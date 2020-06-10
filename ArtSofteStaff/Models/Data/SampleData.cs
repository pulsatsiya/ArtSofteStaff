using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSofteStaff.Models.Data
{
    public class SampleData
    {
        /// <summary>
        /// Добавление в справочник Отделы и Языки программирования
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new WorkContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WorkContext>>());
            if (context.Units.Any())
            {
                return;
            }

            context.Units.AddRange(
                new Unit { Name = "Digital", Floor = 6 },
                new Unit { Name = "Abanking", Floor = 6 },
                new Unit { Name = "Trade-dealer", Floor = 5 },
                new Unit { Name = "Profitbase", Floor = 4 },
                new Unit { Name = "MarketingHub", Floor = 3 }
                );
            context.SaveChanges();

            if (context.Languages.Any())
            {
                return;
            }

            context.Languages.AddRange(
                new Language { Name = "C#" },
                new Language { Name = "Python" },
                new Language { Name = "Assembler" },
                new Language { Name = "C++" },
                new Language { Name = "Java" },
                new Language { Name = "VB.Net" },
                new Language { Name = "F#" },
                new Language { Name = "Pascal" }
                );

            if (context.Persons.Any())
            {
                return;
            }
            context.Persons.AddRange(
                new Person { Login = "1234", Password = "1234", Role = "admin"},
                new Person { Login = "User", Password = "User", Role = "user" }
               

                );

            context.SaveChanges();
        }
    }
}
