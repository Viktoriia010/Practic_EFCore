using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Entity;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Student> Students { get; set; }
    public Curators Curators { get; set; }
    public int CuratorId { get; set; }
}
