using AnyNHibernate.Domains.Workflows;
using NHibernate;

namespace AnyNHibernate.Infrastructures
{
    public class WorkflowRepository : IWorkflowRepository
    {
        readonly ISession session;

        public WorkflowRepository(ISession session)
        {
            this.session = session;
        }

        public void Create(Workflow workflow)
        {
            session.Save(workflow);
        }
    }
}