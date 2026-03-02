using Academy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy;

class Academy(SubjectService _service)
{
    public async Task AddSubject()
    {
        try
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            _service.AddSubject(name, description);
            Console.WriteLine("Subject added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void GetAllSubjects()
    {
        try
        {
            _service.GetAllSubjects();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void GetSubjectById()
    {
        try
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            _service.GetSubjectById(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void UpdateSubject()
    {
        try
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter new name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter new description: ");
            string description = Console.ReadLine();

            _service.UpdateSubject(id, name, description);
            Console.WriteLine("Subject updated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void DeleteSubject()
    {
        try
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            _service.DeleteSubject(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
