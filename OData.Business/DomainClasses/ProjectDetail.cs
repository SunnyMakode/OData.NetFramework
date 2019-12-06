using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OData.Business.DomainClasses
{
    public class ProjectDetail
    {
        [Key, ForeignKey("Project")]
        [Required]
        public long Id { get; set; }

        public Project Project { get; set; }

        public string TechnologiesUsed { get; set; }

        public string ManagerName { get; set; }

        public string Description { get; set; }

        public int TeamSize { get; set; }

        public double PlannedBudget { get; set; }
    }
}