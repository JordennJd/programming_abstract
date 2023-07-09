using System;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore.Diagnostics;
using programm.Entities;

namespace programm;

class program
{
    static void Main()
    {
        byte[] bData = File.ReadAllBytes(@"/Users/danilalatyrev/Desktop/ForProjects/programming_abstract/entityFrameWork/YouTubelogo.svg");
        using (var context = new Context())
        {
            Sponsor spon1 = new Sponsor() { id = 2, image  = bData };
            // context.Sponsors.Add(spon1);
            // context.SaveChanges();
            // var location = Path.GetFullPath("~/Entities");
            //Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
            // var path = Path.GetDirectoryName(location);
            // Console.WriteLine(location);
            
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
//Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
            var path = Path.GetDirectoryName(location);
            Console.WriteLine(path);
            
            Sponsor spon = context.Sponsors.FirstOrDefault(sp => sp.id == 1);
            File.WriteAllBytes( path+"/imaga.svg", spon.image);
        
            // Console.WriteLine(new DirectoryInfo(@"/Users/danilalatyrev/Desktop/ForProjects/programming_abstract/entityFrameWork/Images").GetFiles().Length.ToString());
            //
            // Console.WriteLine(context.Sponsors.Count());
            // if (new DirectoryInfo(@"/Users/danilalatyrev/Desktop/ForProjects/programming_abstract/entityFrameWork/Images").GetFiles().Length != context.Sponsors.Count());
            // {
            //     foreach (var spons in context.Sponsors)
            //     {
            //         File.WriteAllBytes($"/Users/danilalatyrev/Desktop/ForProjects/programming_abstract/entityFrameWork/Images/{spons.id}.svg", spon.image);
            //
            //     }
            // }





            // Person Andrey = new Person();
            // Person Oleg = new Person();
            // Andrey.Name = "Andrey";
            // Andrey.Surname = "Smirnov";
            // Andrey.Phone = "88005553535";
            // Andrey.Address = new Address("Yaroslavl", "Russia");
            // Oleg.Name = "Oleg";
            // Oleg.Surname = "Smirnov";
            // Oleg.Phone = "88005553535";
            // Oleg.Address = new Address("1", "2");
            // context.Persons.Add(Andrey);
            // context.Persons.Add(Oleg);
            // context.SaveChanges();
            // var persons = from p in context.Persons
            //     where p.Id == 1
            //     select new
            //     {
            //         Id = p.Id,
            //         Name = p.Name
            //     };
            // foreach (var items in persons)
            // {
            //     Console.WriteLine(items.Name);
            // }

        }
    }
}