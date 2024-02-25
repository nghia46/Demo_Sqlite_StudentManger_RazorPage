using System;
using System.Collections.Generic;

namespace Repo.Models;

public partial class Student
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public int? Age { get; set; }

    public double? Gpa { get; set; }
}
