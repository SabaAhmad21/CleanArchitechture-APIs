using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsEnable { get; set; }
    }
    public class CategoryCreateVM
    {
        [Required]
        public string CategoryName { get; set; } = null!;
        [Required]
        public bool IsEnable { get; set; }
    }
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; } = null!;
        [Required]
        public bool IsEnable { get; set; }
    }
}
