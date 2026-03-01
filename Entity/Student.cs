using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Entity;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public DateTime? CreatedAt { get; set; }
    public ICollection<Subject> Subjects { get; set; }
    public ICollection<Grade> Grades { get; set; }
}