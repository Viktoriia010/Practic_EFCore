using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Entity;

public class Curators
{
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int GroupId { get; set; }
    public Group Groups { get; set; }
}
