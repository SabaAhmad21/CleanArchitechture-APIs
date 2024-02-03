using System;
using System.Collections.Generic;

namespace DbModels;

public partial class Student
{
    public Guid Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string RollNumber { get; set; } = null!;

    public int GenderId { get; set; }

    public int DepartementId { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string ImgName { get; set; } = null!;

    public virtual Department Departement { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;
}
