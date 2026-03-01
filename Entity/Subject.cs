using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Entity;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Student> Students { get; set; }
    public ICollection<Grade> Grades { get; set; }
}
