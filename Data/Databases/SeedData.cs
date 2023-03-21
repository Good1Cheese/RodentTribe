using RodentTribe.Data.Models;

namespace RodentTribe.Data.Databases;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var database = serviceProvider.GetRequiredService<Database>();
        var connection = database.Connection;

        var closets = connection.Table<Сloset>();
        if (closets.CountAsync()?.Result == 0)
        {
            var data = new List<Сloset>
            {
                new Сloset
                {
                    Id = 1,
                    Name = "Шкаф 1"
                },
                new Сloset
                {
                    Id = 2,
                    Name = "Шкаф 2"
                },
                new Сloset
                {
                    Id = 3,
                    Name = "Шкаф 3"
                },
                new Сloset
                {
                    Id = 4,
                    Name = "Шкаф 4"
                }
            };

            connection.InsertAllAsync(data);
        }

        var boxes = connection.Table<Box>();
        if (boxes.CountAsync().Result == 0)
        {
            var data = new List<Box>
            {
                new Box
                {
                    Id = 1,
                    Name = "Бокс 1"
                },
                new Box
                {
                    Id = 2,
                    Name = "Бокс 2"
                },
                new Box
                {
                    Id = 3,
                    Name = "Бокс 3"
                },
                new Box
                {
                    Id = 4,
                    Name = "Бокс 4"
                }
            };

            connection.InsertAllAsync(data);
        }

        var rodents = connection.Table<Rodent>();
        //rodents.DeleteAsync(_ => true);
        if (rodents.CountAsync().Result == 0)
        {
            var data = new List<Rodent>
            {
                new Rodent
                {
                    Id = 1,
                    Category = AgeCategory.Categories.Germ,
                    IsMale = true,
                    IsPregnant = false,
                    Hallmarks = "черный капюшон",
                    BirthDay = DateTime.Today.AddMonths(-6),
                    ClosetId = 1,
                    BoxId = 1
                },
                new Rodent
                {
                    Id = 2,
                    Category = AgeCategory.Categories.Germ,
                    IsMale = false,
                    IsPregnant = false,
                    Hallmarks = "фиолетовый капюшон",
                    BirthDay = DateTime.Today.AddMonths(-7),
                    ClosetId = 1,
                    BoxId = 1
                },
                new Rodent
                {
                    Id = 3,
                    Category = AgeCategory.Categories.Adult,
                    IsMale = false,
                    IsPregnant = false,
                    Hallmarks = "красный капюшон",
                    BirthDay = DateTime.Today.AddMonths(-3),
                    ClosetId = 1,
                    BoxId = 1
                },
                new Rodent
                {
                    Id = 4,
                    Category = AgeCategory.Categories.Teenager,
                    IsMale = false,
                    IsPregnant = false,
                    Hallmarks = "какой-то капюшон",
                    BirthDay = DateTime.Today.AddMonths(-12),
                    ClosetId = 1,
                    BoxId = 1
                }
            };

            connection.InsertAllAsync(data);
        }
    }
}
