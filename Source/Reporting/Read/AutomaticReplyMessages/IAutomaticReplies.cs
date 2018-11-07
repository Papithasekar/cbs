using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using Concepts.Project;
using Concepts.AutomaticReply;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplies : IExtendedReadModelRepositoryFor<AutomaticReply>
    {
        AutomaticReply GetByProjectTypeAndLanguage(ProjectId projectId, AutomaticReplyType type, string language);

        IEnumerable<AutomaticReply> GetAll();

        IEnumerable<AutomaticReply> GetByProject(ProjectId projectId);

        void SaveAutomaticReply(Guid id, int type, string language, string message, Guid projectId);
    }
}
