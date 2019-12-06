using System.Collections.Generic;
using OData.Business.DomainClasses;
using OData.ORM.Abstractions.RepositoryPattern;
using OData.ORM.Abstractions.UnitOfWorkPattern;

namespace OData.InternalDataService.Implementation
{
    public class ProjectRepository : Service<Project>, IProjectRepository
    {
        private readonly IGenericRepository<Project> _ProjectRepository;

        public ProjectRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._ProjectRepository = unitOfWork.Repository<Project>();
        }

        public Project GetProject(long id)
        {
            return _ProjectRepository.Get(id,
                proj => proj.Detail, proj => proj.Id == id);
        }

        public IEnumerable<Project> GetProjects()
        {
            return _ProjectRepository.GetAll();
        }

        public void AddProject(Project project)
        {
            _ProjectRepository.Add(project);
            _unitOfWork.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            this._ProjectRepository.Update(project);
            _unitOfWork.SaveChanges();
        }

        public void RemoveProject(Project project)
        {
            this._ProjectRepository.Remove(project);
            _unitOfWork.SaveChanges();
        }
    }
}
