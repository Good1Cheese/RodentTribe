using RodentTribe.Data.Models;

namespace RodentTribe.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var database = serviceProvider.GetRequiredService<Database>();
        var connection = database.Connection;

        var closets = connection.Table<Сloset>();
        if (closets.CountAsync().Result == 0)
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
        if (boxes.CountAsync().Result == 0)
        {
            var data = new List<Box>
            {
                new Box
                {
                    Name = "Бокс 1"
                },
                new Box
                {
                    Name = "Бокс 2"
                },
                new Box
                {
                    Name = "Бокс 3"
                },
                new Box
                {
                    Name = "Бокс 4"
                }
            };

            connection.InsertAllAsync(data);
        }
    }
}
