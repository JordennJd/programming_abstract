using System;
using Microsoft.EntityFrameworkCore.Diagnostics;
using programm.Entities;

namespace programm;

class program
{
    static void Main()
    {

        using (var context = new Context())
        {
            Person Andrey = new Person();
            Person Oleg = new Person();
            Andrey.Name = "Andrey";
            Andrey.Surname = "Smirnov";
            Andrey.Phone = "88005553535";
            Andrey.Address = new Address("Yaroslavl", "Russia");
            Oleg.Name = "Oleg";
            Oleg.Surname = "Smirnov";
            Oleg.Phone = "88005553535";
            Oleg.Address = new Address("1", "2");
            context.Persons.Add(Andrey);
            context.Persons.Add(Oleg);
            context.SaveChanges();


            var persons = from p in context.Persons
                where p.Id == 1
                select new
                {
                    Id = p.Id,
                    Name = p.Name
                };
            foreach (var items in persons)
            {
                Console.WriteLine(items.Name);
            }

        }
    }
}