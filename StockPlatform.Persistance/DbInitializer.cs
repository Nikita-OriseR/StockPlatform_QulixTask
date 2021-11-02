using StockPlatform.Domain;
using System;

namespace StockPlatform.Persistance
{
    public class DbInitializer
    {
        public async static void Initialize(StockPlatformDbContext context)
        {
            context.Database.EnsureCreated();

            await context.Authors.AddAsync(new Author
            {
                Name = "Nikita",
                Nickname = "Or1Se",
                Age = 18,
                AccountСreationDate = DateTime.Now
            });

            await context.Authors.AddAsync(new Author
            {
                Name = "Denis",
                Nickname = "Dulin",
                Age = 22,
                AccountСreationDate = new DateTime(2015, 7, 20)
            });

            await context.Authors.AddAsync(new Author
            {
                Name = "Ivan",
                Nickname = "Deshenya",
                Age = 55,
                AccountСreationDate = new DateTime(2019, 9, 26)
            });

            await context.Photos.AddAsync(new Photo
            {
                Title = "Digital photo",
                ContentLink = "https://avatars.mds.yandex.net/i?id=96e0924d51b2a7da558d768b4af83215-4519141-images-thumbs&n=13",
                Height = 1080,
                Width = 1920,
                CreationDate = new DateTime(2003, 5, 3),
                Author = new Author
                {
                    Name = "Denis",
                    Nickname = "Dulin",
                    Age = 22,
                    AccountСreationDate = new DateTime(2015, 7, 20)
                },
                Cost = 215,
                NumberPurchases = 15
            });

            await context.Photos.AddAsync(new Photo
            {
                Title = "Grizzly",
                ContentLink = "https://avatars.mds.yandex.net/i?id=5b2f727764250c316b9c37e87bcfc35b-3858390-images-thumbs&n=13&exp=1",
                Height = 1200,
                Width = 1600,
                CreationDate = new DateTime(2012, 7, 15),
                Author = new Author
                {
                    Name = "Ivan",
                    Nickname = "Deshenya",
                    Age = 55,
                    AccountСreationDate = new DateTime(2019, 9, 26)
                },
                Cost = 1000,
                NumberPurchases = 267
            });

            await context.Photos.AddAsync(new Photo
            {
                Title = "Car picture",
                ContentLink = "https://im0-tub-by.yandex.net/i?id=0794c994de78bddde24c9174e70660a6-l&n=13",
                Height = 1005,
                Width = 1005,
                CreationDate = new DateTime(2021, 8, 1),
                Author = new Author
                {
                    Name = "Nikita",
                    Nickname = "Or1Se",
                    Age = 18,
                    AccountСreationDate = DateTime.Now
                },
                Cost = 20000,
                NumberPurchases = 5
            });

            await context.Texts.AddAsync(new Text
            {
                Title = "First text",
                Content = "Любовь всегда одна, ни выстрела, ни вздоха, Любовь – это когда хорошим людям плохо…",
                Size = 256,
                CreationDate = new DateTime(2020, 7, 9),
                Cost = 250,
                Author = new Author
                {
                    Name = "Ivan",
                    Nickname = "Deshenya",
                    Age = 55,
                    AccountСreationDate = new DateTime(2019, 9, 26)
                },
                NumberPurchases = 15
            });

            await context.Texts.AddAsync(new Text
            {
                Title = "Max Korzh",
                Content = "Есть 2 типа людей одни готовы лгать, пуская в глаза пыль, другие никогда не подставят друзей не скажут за себя, не удушат в ответ.",
                Size = 300,
                CreationDate = new DateTime(2019, 8, 1),
                Cost = 1000,
                Author = new Author
                {
                    Name = "Nikita",
                    Nickname = "Or1Se",
                    Age = 18,
                    AccountСreationDate = DateTime.Now
                },
                NumberPurchases = 556
            });

            await context.Texts.AddAsync(new Text
            {
                Title = "Random",
                Content = "Я тебе доверял, а ты мне нож в спину",
                Size = 123,
                CreationDate = DateTime.Now,
                Cost = 10,
                Author = new Author
                {
                    Name = "Denis",
                    Nickname = "Dulin",
                    Age = 22,
                    AccountСreationDate = new DateTime(2015, 7, 20)
                },
                NumberPurchases = 228
            });

            context.SaveChanges();
        }
    }
}
