using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Infrastructure.Read.MongoDb;
using Concepts;
using Concepts.Project;

namespace Read.Projects
{
    public interface IProjects : IExtendedReadModelRepositoryFor<Project>
    {
        IEnumerable<Project> GetAll();
        Project GetById(ProjectId project);

        void SaveProject(ProjectId id, string name);

        UpdateResult UpdateProject(ProjectId id, string name);
    }
}
