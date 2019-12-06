using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OData.Business.DomainClasses
{
    public class Project
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string ProjectNumber { get; set; }

        [Required]
        [MaxLength(300)]
        public string ProjectName { get; set; }

        public virtual ProjectDetail Detail { get; set; }
    }
}
