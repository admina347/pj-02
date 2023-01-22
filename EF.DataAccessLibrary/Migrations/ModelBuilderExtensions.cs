using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EF.DataAccessLibrary.Migrations
{
    public class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
           //Пользователи
            modelBuilder.Entity<User>().HasData(
                new User { Id =1, FirstName = "Артём", Email = "artem86@bk.ru" },
                new User { Id =2, FirstName = "Артур", Email = "artur79@bk.ru" },
                new User { Id =3, FirstName = "Руслан", Email = "Rus96@mail.ru" },
                new User { Id =4, FirstName = "Олег", Email = "Oleg83@mail.ru" },
                new User { Id =5, FirstName = "Алексей", Email = "alex.a@bk.ru" },
                new User { Id =6, FirstName = "Павел", Email = "Pasha-87@bk.ru" },
                new User { Id =7, FirstName = "Тимур", Email = "tima-s00@bk.ru" },
                new User { Id =8, FirstName = "Женя", Email = "zheka77@list.ru" },
                new User { Id =9, FirstName = "Марат", Email = "marik-94@bk.ru" },
                new User { Id =10, FirstName = "Рустем", Email = "rust02@bk.ru" }
            );
        }
    }
}