using OData.Business.DomainClasses;
using System.Collections.Generic;

namespace OData.InternalDataService.Interface
{
    public interface IProjectDetailRepository
    {
        void AddProjectDetail(ProjectDetail ProjectDetail);
        ProjectDetail GetProjectDetail(long id);
        IEnumerable<ProjectDetail> GetProjectDetails();
        void RemoveProjectDetail(ProjectDetail ProjectDetail);
        void UpdateProjectDetail(ProjectDetail ProjectDetail);
    }
}