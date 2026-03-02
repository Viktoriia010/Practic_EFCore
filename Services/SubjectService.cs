using Academy.Context;
using Academy.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Services;

public class SubjectService(AcademyDbContext _context)
{
    public void AddSubject(string name, string? description)
    {
        Subject sub = new Subject();
        sub.Name = name;
        sub.Description = description;
        _context.Add(sub);
        _context.SaveChanges();
    }

    public void GetAllSubjects()
    {
        var subjects = _context.Subjects.ToList();
        foreach (var subject in subjects)
        {
            Console.WriteLine($"Name: {subject.Name}, {subject.Description}");
        }
    }

    public void GetSubjectById(int id)
    {
        var sub = _context.Subjects.FirstOrDefault(x => x.Id == id);
        if (sub == null)
        {
            Console.WriteLine("Subject not found.");
            return;
        }
        Console.WriteLine($"Name: {sub.Name}, {sub.Description}");
    }

    public void UpdateSubject(int id, string name, string? description)
    {
        var sub = _context.Subjects.FirstOrDefault(x => x.Id == id);
        if (sub == null)
        {
            Console.WriteLine("Subject not found.");
            return;
        }

        Console.WriteLine($"Name: {sub.Name}, {sub.Description}");
        sub.Name = name;
        sub.Description = description;
        _context.SaveChanges();
        
    }

    public void DeleteSubject(int id)
    {
        var sub = _context.Subjects.Include(s => s.Grades).FirstOrDefault(x => x.Id == id);
        if (sub == null)
        {
            Console.WriteLine("Subject not found.");
            return;
        }

        if (sub.Grades.Any())
        {
            Console.WriteLine("Cannot delete subject because it has grades.");
            return;
        }

        _context.Subjects.Remove(sub);
        _context.SaveChanges();

    }
}
