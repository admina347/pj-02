
using EF.DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EF.DataAccessLibrary.Dataaccess
{
    public class LibraryContext : DbContext
    {
        //internal User user1;

        public LibraryContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Заполняем начальный данные
            //Авторы
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Александр", LastName = "Беляев" },
                new Author { Id = 3, FirstName = "Александр", LastName = "Грибоедов" },
                new Author { Id = 4, FirstName = "Александр", LastName = "Грин" },
                new Author { Id = 5, FirstName = "Александр", LastName = "Дюма" },
                new Author { Id = 6, FirstName = "Александр", LastName = "Островский" },
                new Author { Id = 7, FirstName = "Александр", LastName = "Пушкин" },
                new Author { Id = 8, FirstName = "Алексей", LastName = "Толстой" },
                new Author { Id = 9, FirstName = "Антон", LastName = "Чехов" },
                new Author { Id = 10, FirstName = "Аркадий", LastName = "Стругацкий" },
                new Author { Id = 11, FirstName = "Артур", LastName = "Конан Дойль" },
                new Author { Id = 12, FirstName = "Борис", LastName = "Васильев" },
                new Author { Id = 13, FirstName = "Борис", LastName = "Пастернак" },
                new Author { Id = 14, FirstName = "Борис", LastName = "Стругацкий" },
                new Author { Id = 15, FirstName = "Валентин", LastName = "Катаев" },
                new Author { Id = 16, FirstName = "Вениамин", LastName = "Каверин" },
                new Author { Id = 17, FirstName = "Виктор", LastName = "Гюго" },
                new Author { Id = 18, FirstName = "Владимир", LastName = "Богомолов" },
                new Author { Id = 19, FirstName = "Владимир", LastName = "Обручев" },
                new Author { Id = 20, FirstName = "Габриэль", LastName = "Гарсиа Маркес" },
                new Author { Id = 21, FirstName = "Григорий", LastName = "Белых" },
                new Author { Id = 22, FirstName = "Даниель", LastName = "Дефо" },
                new Author { Id = 23, FirstName = "Джек", LastName = "Лондон" },
                new Author { Id = 24, FirstName = "Джордж", LastName = "Оруэлл" },
                new Author { Id = 25, FirstName = "Евгений", LastName = "Петров" },
                new Author { Id = 26, FirstName = "Жюль", LastName = "Верн" },
                new Author { Id = 27, FirstName = "Иван", LastName = "Гончаров" },
                new Author { Id = 28, FirstName = "Иван", LastName = "Тургенев" },
                new Author { Id = 29, FirstName = "Илья", LastName = "Ильф" },
                new Author { Id = 30, FirstName = "Иоганн", LastName = "Вольфганг фон Гёте" },
                new Author { Id = 31, FirstName = "Константин", LastName = "Симонов" },
                new Author { Id = 32, FirstName = "Лев", LastName = "Толстой" },
                new Author { Id = 33, FirstName = "Леонид", LastName = "Филатов" },
                new Author { Id = 34, FirstName = "Л.", LastName = "Пантелеев" },
                new Author { Id = 35, FirstName = "Марк", LastName = "Твен" },
                new Author { Id = 36, FirstName = "Михаил", LastName = "Булгаков" },
                new Author { Id = 37, FirstName = "Михаил", LastName = "Лермонтов" },
                new Author { Id = 38, FirstName = "Михаил", LastName = "Шолохов" },
                new Author { Id = 39, FirstName = "Николай", LastName = "Гоголь" },
                new Author { Id = 40, FirstName = "Станислав", LastName = "Лем" },
                new Author { Id = 41, FirstName = "Федор", LastName = "Достоевский" },
                new Author { Id = 42, FirstName = "Шарлотта", LastName = "Бронте" },
                new Author { Id = 43, FirstName = "Эрих Мария", LastName = "Ремарк" },
                new Author { Id = 44, FirstName = "Эрнест", LastName = "Хемингуэй" },
                new Author { Id = 45, FirstName = "Юлиан", LastName = "Семенов" });
            //Жанры
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Автобиография" },
                new Genre { Id = 2, Name = "Антиутопия" },
                new Genre { Id = 3, Name = "Биография" },
                new Genre { Id = 4, Name = "Готика" },
                new Genre { Id = 5, Name = "Детектив" },
                new Genre { Id = 6, Name = "Детская литература" },
                new Genre { Id = 7, Name = "Для подростков" },
                new Genre { Id = 8, Name = "Драма" },
                new Genre { Id = 9, Name = "История" },
                new Genre { Id = 10, Name = "Классика" },
                new Genre { Id = 11, Name = "Комедия" },
                new Genre { Id = 12, Name = "Магический реализм" },
                new Genre { Id = 13, Name = "Мистика" },
                new Genre { Id = 14, Name = "Неоромантизм" },
                new Genre { Id = 15, Name = "О войне" },
                new Genre { Id = 16, Name = "О животных" },
                new Genre { Id = 17, Name = "О любви" },
                new Genre { Id = 18, Name = "Пародия" },
                new Genre { Id = 19, Name = "Плутовской роман" },
                new Genre { Id = 20, Name = "Повесть" },
                new Genre { Id = 21, Name = "Поэзия" },
                new Genre { Id = 22, Name = "Поэма" },
                new Genre { Id = 23, Name = "Приключения" },
                new Genre { Id = 24, Name = "Проза" },
                new Genre { Id = 25, Name = "Психология" },
                new Genre { Id = 26, Name = "Пьеса" },
                new Genre { Id = 27, Name = "Рассказ" },
                new Genre { Id = 28, Name = "Реализм" },
                new Genre { Id = 29, Name = "Роман" },
                new Genre { Id = 30, Name = "Роман в письмах" },
                new Genre { Id = 31, Name = "Сатира" },
                new Genre { Id = 32, Name = "Сборник" },
                new Genre { Id = 33, Name = "Сказка" },
                new Genre { Id = 34, Name = "Современная проза" },
                new Genre { Id = 35, Name = "Трагедия" },
                new Genre { Id = 36, Name = "Фантастика" },
                new Genre { Id = 37, Name = "Философия" },
                new Genre { Id = 38, Name = "Юмор" });

            //modelBuilder.Entity<Author>()
            //    .HasIndex(a => new { a.FirstName, a.LastName })
            //    .IsUnique(true);
        }
    }
}