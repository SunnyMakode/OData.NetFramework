using System.Collections.Generic;
using OData.Business.DomainClasses;
using OData.ORM.Abstractions.RepositoryPattern;
using OData.ORM.Abstractions.UnitOfWorkPattern;

namespace OData.InternalDataService.Implementation
{
    public class ProjectDetailRepository : Service<ProjectDetail>, IProjectDetailRepository
    {
        private readonly IGenericRepository<ProjectDetail> _ProjectDetailRepository;

        public ProjectDetailRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._ProjectDetailRepository = unitOfWork.Repository<ProjectDetail>();
        }

        public ProjectDetail GetProjectDetail(long id)
        {
            return _ProjectDetailRepository.Get(id);
        }

        public IEnumerable<ProjectDetail> GetProjectDetails()
        {
            return _ProjectDetailRepository.GetAll();
        }

        public void AddProjectDetail(ProjectDetail ProjectDetail)
        {
            _ProjectDetailRepository.Add(ProjectDetail);
            _unitOfWork.SaveChanges();
        }

        public void UpdateProjectDetail(ProjectDetail ProjectDetail)
        {
            this._ProjectDetailRepository.Update(ProjectDetail);
            _unitOfWork.SaveChanges();
        }

        public void RemoveProjectDetail(ProjectDetail ProjectDetail)
        {
            this._ProjectDetailRepository.Remove(ProjectDetail);
            _unitOfWork.SaveChanges();
        }
    }
}
