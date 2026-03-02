using Academy.Configurator;
using Academy.Context;
using Academy.Entity;
using Academy.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Academy;

internal class Program
{
    static void Main(string[] args)
    {

        var services = new ServiceCollection(); //Створюється контейнер DI (Dependency Injection)

        services.AddDbContext<AcademyDbContext>(options =>
        {
            DbContextConfigurator.Configure(options);
        });

        services.AddScoped<Academy>();
        services.AddScoped<SubjectService>();

        //Створюється вже «працюючий» контейнер.
        var provider = services.BuildServiceProvider();

        //"Один DbContext на одну операцію роботи з БД"

        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AcademyDbContext>();
        var academy = scope.ServiceProvider.GetRequiredService<Academy>();

        if (context.Database.CanConnect())
        {
            Console.WriteLine("Пiдключення до БД встановлено");

            academy.AddSubject(); 
            academy.AddSubject();

            Console.WriteLine("\n=== All Subjects ===");
            academy.GetAllSubjects();

            Console.WriteLine("\n=== Get Subject By Id ===");
            academy.GetSubjectById();

            Console.WriteLine("\n=== Update Subject ===");
            academy.UpdateSubject();

            Console.WriteLine("\n=== Delete Subject ===");
            academy.DeleteSubject();

            Console.WriteLine("\n=== Final Subjects List ===");
            academy.GetAllSubjects();
            //var math = new Subject
            //{
            //    Name = "Mathematics",
            //    Description = "Algebra and Geometry"
            //};

            //var physics = new Subject
            //{
            //    Name = "Physics",
            //    Description = "Mechanics and Thermodynamics"
            //};

            //var programming = new Subject
            //{
            //    Name = "Programming",
            //    Description = "C# and .NET"
            //};

            //context.Subjects.Add(math);
            //context.Subjects.Add(physics);
            //context.Subjects.Add(programming);
            //context.SaveChanges();

            //var grades = new List<Grade>
            //{
            //    new Grade { Value = 12, SubjectId = 1 },
            //    new Grade { Value = 10, SubjectId = 1 },
            //    new Grade { Value = 9, SubjectId = 3 }
            //};

            //context.Grades.AddRange(grades);
            //context.SaveChanges();
        }


        else
        {
            Console.WriteLine("Не вдалось підключитись до БД");
        }
        ////Конфігуратор
        //var configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json")
        //    .Build();

        ////Реєстрація AcademyDbContext у DI
        //services.AddDbContext<AcademyDbContext>(options =>
        //    options.UseSqlServer(
        //        configuration.GetConnectionString("MSSQLConnection")));


        ////Створюється вже «працюючий» контейнер.
        //var provider = services.BuildServiceProvider();

        ////"Один DbContext на одну операцію роботи з БД"

        //using var scope = provider.CreateScope();
        //var context = scope.ServiceProvider.GetRequiredService<AcademyDbContext>();

        //if (context.Database.CanConnect())
        //{
        //    Console.WriteLine("Пiдключення до БД встановлено");
        //}
        //else
        //{
        //    Console.WriteLine("Не вдалось підключитись до БД");
        //}
        //var services = new ServiceCollection();

        //var configuration = new ConfigurationBuilder()
        //                 .SetBasePath(Directory.GetCurrentDirectory())
        //                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //                 .Build();
        //var optionsBuilder = new DbContextOptionsBuilder<AcademyDbContext>();
        //optionsBuilder.UseSqlServer(configuration.GetConnectionString("MSSQLConnection"));

        //// Создаем контекст с этими опциями
        //using (var context = new AcademyDbContext(optionsBuilder.Options))
        //{
        //    //Student st1 = new Student();
        //    //st1.Name = "John";
        //    //st1.Surename = "Surname3";
        //    //st1.CreateAt = DateTime.Now;
        //    //context.Add(st1);
        //    //context.SaveChanges();

        //    //var students = context.Students.Where(st => st.Id == 1).ToList();
        //    //students.ForEach(st => Console.WriteLine(st.Name));
        //}

        //using (var context = new AcademyDbContext())
        //{
        //    //context.Database.EnsureCreated();
        //    context.Database.EnsureDeleted();
        //    //var student = new Student();
        //    //Console.WriteLine("Enter name: ");
        //    //student.Name = Console.ReadLine();
        //    //Console.WriteLine("Enter surname: ");
        //    //student.Surename = Console.ReadLine();
        //    //context.Students.Add(student);
        //    //context.SaveChanges();
        //    //var student = context.Students.FirstOrDefault(st => st.Id ==1);
        //    //if(student != null)
        //    //{
        //    //    Console.WriteLine($"name: {student.Name } {student.Surename}");
        //    //} 
        //} 
    }
}
