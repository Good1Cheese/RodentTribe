﻿using RodentTribe.Data.Models;

namespace RodentTribe.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var database = serviceProvider.GetRequiredService<Database>();
        var connection = database.Connection;

        var closets = connection.Table<Сloset>();
        if (!closets.Any())
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

            connection.InsertAll(data);
        }
    }
}