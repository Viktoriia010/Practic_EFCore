using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Entity;

public class Grade
{
    public int Id { get; set; }
    public int Value { get; set; }
    public DateTime DateAssigned { get; set; }
    public Student Student { get; set; }
    public int StudentId { get; set; }
    public Subject Subject { get; set; }
    public int SubjectId { get; set; }  
}
