using RodentTribe.Data.Models;

namespace RodentTribe.Data.Databases;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var database = serviceProvider.GetRequiredService<Database>();
        var connection = database.Connection;

        //connection.DropTableAsync<Сloset>();
        //connection.DropTableAsync<Box>();
        //connection.DropTableAsync<Rodent>();

        var closets = connection.Table<Сloset>();
        if (closets.CountAsync()?.Result == 0)
        {
            var data = new List<Сloset>
            {
                new Сloset
                {
                    Name = "Шкаф 1"
                },
                new Сloset
                {
                    Name = "Шкаф 2"
                },
                new Сloset
                {
                    Name = "Шкаф 3"
                },
                new Сloset
                {
                    Name = "Шкаф 4"
                }
            };

            connection.InsertAllAsync(data);
        }

        var boxes = connection.Table<Box>();
        if (boxes.CountAsync()?.Result == 0)
        {
            var data = new List<Box>
            {
                new Box
                {
                    ClosetId = 1,
                    Name = "Бокс 1"
                },
                new Box
                {
                    ClosetId = 1,
                    Name = "Бокс 2"
                },
                new Box
                {
                    ClosetId = 1,
                    Name = "Бокс 3"
                },
                new Box
                {
                    ClosetId = 1,
                    Name = "Бокс 4"
                }
            };

            connection.InsertAllAsync(data);
        }

        var rodents = connection.Table<Rodent>();
        if (rodents.CountAsync()?.Result == 0)
        {
            var data = new List<Rodent>
            {
                new Rodent
                {
                    Category = AgeCategory.Categories.Germ,
                    Type = Rodents.Types.Rat,
                    IsMale = true,
                    IsPregnant = false,
                    Hallmarks = "черный капюшон",
                    BirthDay = DateTime.Today.AddMonths(-6),
                    ClosetId = 1,
                    BoxId = 1
                },
                new Rodent
                {
                    Category = AgeCategory.Categories.Germ,
                    Type = Rodents.Types.Rat,
                    IsMale = false,
                    IsPregnant = false,
                    Hallmarks = "фиолетовый капюшон",
                    BirthDay = DateTime.Today.AddMonths(-7),
                    ClosetId = 1,
                    BoxId = 1
                },
                new Rodent
                {
                    Category = AgeCategory.Categories.Adult,
                    Type = Rodents.Types.Rat,
                    IsMale = false,
                    IsPregnant = false,
                    Hallmarks = "красный капюшон",
                    BirthDay = DateTime.Today.AddMonths(-3),
                    ClosetId = 1,
                    BoxId = 1
                },
                new Rodent
                {
                    Category = AgeCategory.Categories.Teenager,
                    Type = Rodents.Types.Rat,
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
