using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF.DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SampleDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BookGenres_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Александр", "Беляев" },
                    { 2, "Александр", "Волков" },
                    { 3, "Александр", "Грибоедов" },
                    { 4, "Александр", "Грин" },
                    { 5, "Александр", "Дюма" },
                    { 6, "Александр", "Островский" },
                    { 7, "Александр", "Пушкин" },
                    { 8, "Алексей", "Толстой" },
                    { 9, "Антон", "Чехов" },
                    { 10, "Аркадий", "Стругацкий" },
                    { 11, "Артур", "Конан Дойль" },
                    { 12, "Борис", "Васильев" },
                    { 13, "Борис", "Пастернак" },
                    { 14, "Борис", "Стругацкий" },
                    { 15, "Валентин", "Катаев" },
                    { 16, "Вениамин", "Каверин" },
                    { 17, "Виктор", "Гюго" },
                    { 18, "Владимир", "Богомолов" },
                    { 19, "Владимир", "Обручев" },
                    { 20, "Габриэль", "Гарсиа Маркес" },
                    { 21, "Григорий", "Белых" },
                    { 22, "Даниель", "Дефо" },
                    { 23, "Джек", "Лондон" },
                    { 24, "Джордж", "Оруэлл" },
                    { 25, "Евгений", "Петров" },
                    { 26, "Жюль", "Верн" },
                    { 27, "Иван", "Гончаров" },
                    { 28, "Иван", "Тургенев" },
                    { 29, "Илья", "Ильф" },
                    { 30, "Иоганн", "Вольфганг фон Гёте" },
                    { 31, "Константин", "Симонов" },
                    { 32, "Лев", "Толстой" },
                    { 33, "Леонид", "Филатов" },
                    { 34, "Л.", "Пантелеев" },
                    { 35, "Марк", "Твен" },
                    { 36, "Михаил", "Булгаков" },
                    { 37, "Михаил", "Лермонтов" },
                    { 38, "Михаил", "Шолохов" },
                    { 39, "Николай", "Гоголь" },
                    { 40, "Станислав", "Лем" },
                    { 41, "Федор", "Достоевский" },
                    { 42, "Шарлотта", "Бронте" },
                    { 43, "Эрих Мария", "Ремарк" },
                    { 44, "Эрнест", "Хемингуэй" },
                    { 45, "Юлиан", "Семенов" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PublicationDate", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1929, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мастер и Маргарита", null },
                    { 2, new DateTime(1925, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Собачье сердце", null },
                    { 3, new DateTime(1928, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Двенадцать стульев", null },
                    { 4, new DateTime(1842, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мёртвые души", null },
                    { 5, new DateTime(1844, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Граф Монте-Кристо", null },
                    { 6, new DateTime(1931, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Золотой теленок", null },
                    { 7, new DateTime(1936, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Три товарища", null },
                    { 8, new DateTime(1862, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отверженные", null },
                    { 9, new DateTime(1866, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Преступление и наказание", null },
                    { 10, new DateTime(1865, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Война и мир", null },
                    { 11, new DateTime(1825, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Евгений Онегин", null },
                    { 12, new DateTime(1836, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ревизор", null },
                    { 13, new DateTime(1831, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Повести Белкина", null },
                    { 14, new DateTime(1860, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отцы и дети", null },
                    { 15, new DateTime(1859, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Село Степанчиково и его обитатели", null },
                    { 16, new DateTime(1892, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Палата № 6", null },
                    { 17, new DateTime(1844, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Три мушкетера", null },
                    { 18, new DateTime(1879, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Братья Карамазовы", null },
                    { 19, new DateTime(1868, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Идиот", null },
                    { 20, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Собака Баскервилей", null },
                    { 21, new DateTime(1855, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Рудин", null },
                    { 22, new DateTime(1887, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Приключения Шерлока Холмса", null },
                    { 23, new DateTime(1833, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дубровский", null },
                    { 24, new DateTime(1884, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Драма на охоте", null },
                    { 25, new DateTime(1836, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Капитанская дочка", null },
                    { 26, new DateTime(1828, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Горе от ума", null },
                    { 27, new DateTime(1861, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Униженные и оскорблённые", null },
                    { 28, new DateTime(1859, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дворянское гнездо", null },
                    { 29, new DateTime(1899, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Воскресение", null },
                    { 30, new DateTime(1883, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Рассказы", null },
                    { 31, new DateTime(1945, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Триумфальная арка", null },
                    { 32, new DateTime(1875, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Подросток", null },
                    { 33, new DateTime(1952, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старик и море", null },
                    { 34, new DateTime(1873, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Анна Каренина", null },
                    { 35, new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Двадцать тысяч лье под водой", null },
                    { 36, new DateTime(1969, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "А зори здесь тихие", null },
                    { 37, new DateTime(1719, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Робинзон Крузо", null },
                    { 38, new DateTime(1839, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Герой нашего времени", null },
                    { 39, new DateTime(1847, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Джейн Эйр", null },
                    { 40, new DateTime(1820, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Руслан и Людмила", null },
                    { 41, new DateTime(1868, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дети капитана Гранта", null },
                    { 42, new DateTime(1870, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бесы", null },
                    { 43, new DateTime(1956, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Черный обелиск", null },
                    { 44, new DateTime(1926, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тихий Дон", null },
                    { 45, new DateTime(1847, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Виконт де Бражелон, или Десять лет спустя", null },
                    { 46, new DateTime(1845, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Двадцать лет спустя", null },
                    { 47, new DateTime(1848, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Обломов", null },
                    { 48, new DateTime(1906, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Белый Клык", null },
                    { 49, new DateTime(1852, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Детство. Отрочество. Юность", null },
                    { 50, new DateTime(1903, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вишневый сад", null },
                    { 51, new DateTime(1924, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Белая гвардия", null },
                    { 52, new DateTime(1926, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Республика ШКИД", null },
                    { 53, new DateTime(1938, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Два капитана", null },
                    { 54, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Про Федота-стрельца, удалого молодца", null },
                    { 55, new DateTime(1969, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Семнадцать мгновений весны", null },
                    { 56, new DateTime(1924, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Земля Санникова", null },
                    { 57, new DateTime(1866, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Игрок", null },
                    { 58, new DateTime(1846, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Графиня де Монсоро", null },
                    { 59, new DateTime(1831, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вечера на хуторе близ Диканьки", null },
                    { 60, new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пикник на обочине", null },
                    { 61, new DateTime(1834, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пиковая дама", null },
                    { 62, new DateTime(1961, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Солярис", null },
                    { 63, new DateTime(1929, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пётр Первый", null },
                    { 64, new DateTime(1957, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Судьба человека", null },
                    { 65, new DateTime(1896, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дядя Ваня", null },
                    { 66, new DateTime(1939, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Волшебник Изумрудного города", null },
                    { 67, new DateTime(1905, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Возвращение Шерлока Холмса", null },
                    { 68, new DateTime(1835, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тарас Бульба", null },
                    { 69, new DateTime(1928, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Человек-амфибия", null },
                    { 70, new DateTime(1845, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бедные люди", null },
                    { 71, new DateTime(1916, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алые паруса", null },
                    { 72, new DateTime(1922, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Хождение по мукам", null },
                    { 73, new DateTime(1860, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Записки из Мёртвого дома", null },
                    { 74, new DateTime(1833, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Медный всадник", null },
                    { 75, new DateTime(1825, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Борис Годунов", null },
                    { 76, new DateTime(1945, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Доктор Живаго", null },
                    { 77, new DateTime(1896, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чайка", null },
                    { 78, new DateTime(1926, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Морфий", null },
                    { 79, new DateTime(1947, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984", null },
                    { 80, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван Васильевич", null },
                    { 81, new DateTime(1963, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Трудно быть богом", null },
                    { 82, new DateTime(1925, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Записки юного врача", null },
                    { 83, new DateTime(1974, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Момент истины (В августе 44-го)", null },
                    { 84, new DateTime(1926, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бег", null },
                    { 85, new DateTime(1959, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Живые и мертвые", null },
                    { 86, new DateTime(1872, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Кавказский пленник", null },
                    { 87, new DateTime(1936, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Белеет парус одинокий", null },
                    { 88, new DateTime(1876, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Приключения Тома Сойера", null },
                    { 89, new DateTime(1884, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Приключения Гекльберри Финна", null },
                    { 90, new DateTime(1852, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Записки охотника", null },
                    { 91, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Три сестры", null },
                    { 92, new DateTime(1896, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Хаджи-Мурат", null },
                    { 93, new DateTime(1848, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сорок пять", null },
                    { 94, new DateTime(1878, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бесприданница", null },
                    { 95, new DateTime(1842, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Шинель", null },
                    { 96, new DateTime(1874, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Таинственный остров", null },
                    { 97, new DateTime(1831, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Собор Парижской Богоматери", null },
                    { 98, new DateTime(1909, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мартин Иден", null },
                    { 99, new DateTime(1967, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сто лет одиночества", null },
                    { 100, new DateTime(1774, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фауст", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Автобиография" },
                    { 2, "Антиутопия" },
                    { 3, "Биография" },
                    { 4, "Готика" },
                    { 5, "Детектив" },
                    { 6, "Детская литература" },
                    { 7, "Для подростков" },
                    { 8, "Драма" },
                    { 9, "История" },
                    { 10, "Классика" },
                    { 11, "Комедия" },
                    { 12, "Магический реализм" },
                    { 13, "Мистика" },
                    { 14, "Неоромантизм" },
                    { 15, "О войне" },
                    { 16, "О животных" },
                    { 17, "О любви" },
                    { 18, "Пародия" },
                    { 19, "Плутовской роман" },
                    { 20, "Повесть" },
                    { 21, "Поэзия" },
                    { 22, "Поэма" },
                    { 23, "Приключения" },
                    { 24, "Проза" },
                    { 25, "Психология" },
                    { 26, "Пьеса" },
                    { 27, "Рассказ" },
                    { 28, "Реализм" },
                    { 29, "Роман" },
                    { 30, "Роман в письмах" },
                    { 31, "Сатира" },
                    { 32, "Сборник" },
                    { 33, "Сказка" },
                    { 34, "Современная проза" },
                    { 35, "Трагедия" },
                    { 36, "Фантастика" },
                    { 37, "Философия" },
                    { 38, "Юмор" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName" },
                values: new object[,]
                {
                    { 1, "artem86@bk.ru", "Артём" },
                    { 2, "artur79@bk.ru", "Артур" },
                    { 3, "Rus96@mail.ru", "Руслан" },
                    { 4, "Oleg83@mail.ru", "Олег" },
                    { 5, "alex.a@bk.ru", "Алексей" },
                    { 6, "Pasha-87@bk.ru", "Павел" },
                    { 7, "tima-s00@bk.ru", "Тимур" },
                    { 8, "zheka77@list.ru", "Женя" },
                    { 9, "marik-94@bk.ru", "Марат" },
                    { 10, "rust02@bk.ru", "Рустем" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 69 },
                    { 2, 66 },
                    { 3, 26 },
                    { 4, 71 },
                    { 5, 5 },
                    { 5, 17 },
                    { 5, 45 },
                    { 5, 46 },
                    { 5, 58 },
                    { 5, 93 },
                    { 6, 94 },
                    { 7, 11 },
                    { 7, 13 },
                    { 7, 23 },
                    { 7, 25 },
                    { 7, 40 },
                    { 7, 61 },
                    { 7, 74 },
                    { 7, 75 },
                    { 8, 63 },
                    { 8, 72 },
                    { 9, 16 },
                    { 9, 24 },
                    { 9, 30 },
                    { 9, 50 },
                    { 9, 65 },
                    { 9, 77 },
                    { 9, 91 },
                    { 10, 81 },
                    { 11, 20 },
                    { 11, 22 },
                    { 11, 67 },
                    { 12, 36 },
                    { 13, 76 },
                    { 14, 60 },
                    { 15, 87 },
                    { 16, 53 },
                    { 17, 8 },
                    { 17, 97 },
                    { 18, 83 },
                    { 19, 56 },
                    { 20, 99 },
                    { 21, 52 },
                    { 22, 37 },
                    { 23, 48 },
                    { 23, 98 },
                    { 24, 79 },
                    { 26, 35 },
                    { 26, 41 },
                    { 26, 96 },
                    { 27, 47 },
                    { 28, 14 },
                    { 28, 21 },
                    { 28, 28 },
                    { 28, 90 },
                    { 29, 3 },
                    { 29, 6 },
                    { 30, 100 },
                    { 31, 85 },
                    { 32, 10 },
                    { 32, 29 },
                    { 32, 34 },
                    { 32, 49 },
                    { 32, 86 },
                    { 32, 92 },
                    { 33, 54 },
                    { 35, 88 },
                    { 35, 89 },
                    { 36, 1 },
                    { 36, 2 },
                    { 36, 51 },
                    { 36, 78 },
                    { 36, 80 },
                    { 36, 82 },
                    { 36, 84 },
                    { 37, 38 },
                    { 38, 44 },
                    { 38, 64 },
                    { 39, 4 },
                    { 39, 12 },
                    { 39, 59 },
                    { 39, 68 },
                    { 39, 95 },
                    { 40, 62 },
                    { 41, 9 },
                    { 41, 15 },
                    { 41, 18 },
                    { 41, 19 },
                    { 41, 27 },
                    { 41, 32 },
                    { 41, 42 },
                    { 41, 57 },
                    { 41, 70 },
                    { 41, 73 },
                    { 42, 39 },
                    { 43, 7 },
                    { 43, 31 },
                    { 43, 43 },
                    { 44, 33 },
                    { 45, 55 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 29 },
                    { 1, 31 },
                    { 1, 37 },
                    { 2, 10 },
                    { 2, 20 },
                    { 2, 31 },
                    { 2, 36 },
                    { 3, 10 },
                    { 3, 19 },
                    { 3, 31 },
                    { 3, 38 },
                    { 4, 10 },
                    { 4, 22 },
                    { 4, 24 },
                    { 4, 29 },
                    { 5, 7 },
                    { 5, 23 },
                    { 5, 29 },
                    { 6, 10 },
                    { 6, 19 },
                    { 6, 31 },
                    { 6, 38 },
                    { 7, 10 },
                    { 7, 17 },
                    { 7, 29 },
                    { 8, 8 },
                    { 8, 9 },
                    { 8, 10 },
                    { 8, 29 },
                    { 9, 10 },
                    { 9, 25 },
                    { 9, 29 },
                    { 9, 37 },
                    { 10, 10 },
                    { 10, 15 },
                    { 10, 17 },
                    { 10, 29 },
                    { 11, 10 },
                    { 11, 17 },
                    { 11, 21 },
                    { 11, 29 },
                    { 12, 10 },
                    { 12, 11 },
                    { 12, 26 },
                    { 13, 8 },
                    { 13, 10 },
                    { 13, 17 },
                    { 13, 20 },
                    { 13, 32 },
                    { 14, 10 },
                    { 14, 29 },
                    { 15, 10 },
                    { 15, 20 },
                    { 15, 31 },
                    { 15, 38 },
                    { 16, 10 },
                    { 16, 20 },
                    { 16, 25 },
                    { 17, 7 },
                    { 17, 9 },
                    { 17, 23 },
                    { 17, 29 },
                    { 18, 5 },
                    { 18, 8 },
                    { 18, 10 },
                    { 18, 25 },
                    { 18, 29 },
                    { 18, 37 },
                    { 19, 10 },
                    { 19, 25 },
                    { 19, 29 },
                    { 19, 37 },
                    { 20, 5 },
                    { 20, 20 },
                    { 20, 23 },
                    { 21, 10 },
                    { 21, 17 },
                    { 21, 29 },
                    { 22, 5 },
                    { 22, 27 },
                    { 22, 32 },
                    { 23, 8 },
                    { 23, 10 },
                    { 23, 17 },
                    { 23, 20 },
                    { 24, 5 },
                    { 24, 8 },
                    { 24, 10 },
                    { 24, 20 },
                    { 25, 8 },
                    { 25, 9 },
                    { 25, 10 },
                    { 25, 17 },
                    { 25, 29 },
                    { 26, 10 },
                    { 26, 11 },
                    { 26, 26 },
                    { 27, 10 },
                    { 27, 25 },
                    { 27, 29 },
                    { 28, 10 },
                    { 28, 17 },
                    { 28, 29 },
                    { 29, 10 },
                    { 29, 29 },
                    { 30, 10 },
                    { 30, 17 },
                    { 30, 27 },
                    { 30, 32 },
                    { 30, 38 },
                    { 31, 10 },
                    { 31, 17 },
                    { 31, 29 },
                    { 32, 7 },
                    { 32, 10 },
                    { 32, 25 },
                    { 32, 29 },
                    { 33, 10 },
                    { 33, 20 },
                    { 34, 10 },
                    { 34, 17 },
                    { 34, 29 },
                    { 35, 7 },
                    { 35, 23 },
                    { 35, 29 },
                    { 35, 36 },
                    { 36, 8 },
                    { 36, 15 },
                    { 36, 20 },
                    { 37, 6 },
                    { 37, 10 },
                    { 37, 23 },
                    { 37, 29 },
                    { 38, 10 },
                    { 38, 17 },
                    { 38, 29 },
                    { 39, 4 },
                    { 39, 17 },
                    { 39, 29 },
                    { 40, 6 },
                    { 40, 7 },
                    { 40, 10 },
                    { 40, 17 },
                    { 40, 21 },
                    { 40, 22 },
                    { 40, 33 },
                    { 41, 6 },
                    { 41, 7 },
                    { 41, 23 },
                    { 41, 29 },
                    { 42, 10 },
                    { 42, 25 },
                    { 42, 29 },
                    { 43, 8 },
                    { 43, 10 },
                    { 43, 17 },
                    { 43, 29 },
                    { 44, 8 },
                    { 44, 9 },
                    { 44, 10 },
                    { 44, 15 },
                    { 44, 17 },
                    { 44, 29 },
                    { 45, 7 },
                    { 45, 9 },
                    { 45, 23 },
                    { 45, 29 },
                    { 46, 7 },
                    { 46, 9 },
                    { 46, 23 },
                    { 46, 29 },
                    { 47, 10 },
                    { 47, 29 },
                    { 48, 10 },
                    { 48, 16 },
                    { 48, 20 },
                    { 48, 23 },
                    { 49, 1 },
                    { 49, 6 },
                    { 49, 10 },
                    { 49, 20 },
                    { 50, 8 },
                    { 50, 10 },
                    { 50, 11 },
                    { 50, 26 },
                    { 51, 9 },
                    { 51, 10 },
                    { 51, 15 },
                    { 51, 29 },
                    { 52, 3 },
                    { 52, 7 },
                    { 52, 20 },
                    { 52, 23 },
                    { 53, 6 },
                    { 53, 7 },
                    { 53, 17 },
                    { 53, 23 },
                    { 53, 29 },
                    { 54, 18 },
                    { 54, 21 },
                    { 54, 26 },
                    { 54, 31 },
                    { 54, 33 },
                    { 54, 38 },
                    { 55, 15 },
                    { 55, 29 },
                    { 56, 23 },
                    { 56, 29 },
                    { 56, 36 },
                    { 57, 10 },
                    { 57, 29 },
                    { 58, 9 },
                    { 58, 17 },
                    { 58, 23 },
                    { 58, 29 },
                    { 59, 10 },
                    { 59, 20 },
                    { 59, 32 },
                    { 60, 34 },
                    { 60, 36 },
                    { 60, 37 },
                    { 61, 8 },
                    { 61, 10 },
                    { 61, 13 },
                    { 61, 20 },
                    { 62, 10 },
                    { 62, 29 },
                    { 62, 36 },
                    { 62, 37 },
                    { 63, 9 },
                    { 63, 10 },
                    { 63, 29 },
                    { 64, 8 },
                    { 64, 15 },
                    { 64, 27 },
                    { 65, 8 },
                    { 65, 10 },
                    { 65, 26 },
                    { 66, 6 },
                    { 66, 20 },
                    { 66, 23 },
                    { 66, 33 },
                    { 67, 5 },
                    { 67, 10 },
                    { 67, 23 },
                    { 67, 27 },
                    { 67, 32 },
                    { 68, 10 },
                    { 68, 15 },
                    { 68, 20 },
                    { 69, 7 },
                    { 69, 23 },
                    { 69, 29 },
                    { 69, 36 },
                    { 70, 10 },
                    { 70, 29 },
                    { 70, 30 },
                    { 71, 6 },
                    { 71, 7 },
                    { 71, 14 },
                    { 71, 17 },
                    { 71, 20 },
                    { 71, 33 },
                    { 72, 15 },
                    { 72, 17 },
                    { 72, 29 },
                    { 73, 10 },
                    { 73, 28 },
                    { 73, 29 },
                    { 73, 37 },
                    { 74, 10 },
                    { 74, 21 },
                    { 74, 22 },
                    { 75, 8 },
                    { 75, 9 },
                    { 75, 22 },
                    { 75, 26 },
                    { 75, 35 },
                    { 76, 8 },
                    { 76, 9 },
                    { 76, 10 },
                    { 76, 17 },
                    { 76, 29 },
                    { 77, 10 },
                    { 77, 11 },
                    { 77, 26 },
                    { 78, 20 },
                    { 78, 27 },
                    { 79, 2 },
                    { 79, 10 },
                    { 79, 29 },
                    { 80, 26 },
                    { 80, 31 },
                    { 80, 36 },
                    { 80, 38 },
                    { 81, 20 },
                    { 81, 36 },
                    { 81, 37 },
                    { 82, 27 },
                    { 82, 32 },
                    { 83, 5 },
                    { 83, 15 },
                    { 83, 29 },
                    { 84, 8 },
                    { 84, 15 },
                    { 84, 26 },
                    { 85, 15 },
                    { 85, 24 },
                    { 85, 29 },
                    { 86, 6 },
                    { 86, 7 },
                    { 86, 15 },
                    { 86, 27 },
                    { 87, 6 },
                    { 87, 20 },
                    { 88, 6 },
                    { 88, 7 },
                    { 88, 10 },
                    { 88, 19 },
                    { 88, 23 },
                    { 88, 29 },
                    { 88, 38 },
                    { 89, 6 },
                    { 89, 7 },
                    { 89, 10 },
                    { 89, 19 },
                    { 89, 23 },
                    { 89, 29 },
                    { 89, 31 },
                    { 90, 10 },
                    { 90, 27 },
                    { 90, 28 },
                    { 90, 32 },
                    { 91, 8 },
                    { 91, 10 },
                    { 91, 26 },
                    { 92, 10 },
                    { 92, 15 },
                    { 92, 20 },
                    { 92, 28 },
                    { 93, 9 },
                    { 93, 23 },
                    { 93, 29 },
                    { 94, 8 },
                    { 94, 17 },
                    { 94, 26 },
                    { 95, 10 },
                    { 95, 20 },
                    { 96, 6 },
                    { 96, 7 },
                    { 96, 23 },
                    { 96, 29 },
                    { 96, 36 },
                    { 97, 8 },
                    { 97, 9 },
                    { 97, 10 },
                    { 97, 17 },
                    { 97, 29 },
                    { 98, 8 },
                    { 98, 17 },
                    { 98, 29 },
                    { 99, 10 },
                    { 99, 12 },
                    { 99, 13 },
                    { 99, 29 },
                    { 100, 10 },
                    { 100, 13 },
                    { 100, 21 },
                    { 100, 35 },
                    { 100, 37 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GenreId",
                table: "BookGenres",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "BookGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Author_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresId",
                table: "BookGenre",
                column: "GenresId");
        }
    }
}
