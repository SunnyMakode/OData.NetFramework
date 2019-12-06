using OData.Business.DomainClasses;
using System.Collections.Generic;

namespace OData.InternalDataService.Implementation
{
    public interface IProjectRepository
    {
        void AddProject(Project project);
        Project GetProject(long id);
        IEnumerable<Project> GetProjects();
        void RemoveProject(Project project);
        void UpdateProject(Project project);
    }
}