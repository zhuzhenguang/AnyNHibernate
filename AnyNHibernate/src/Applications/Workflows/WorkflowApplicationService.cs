using AnyNHibernate.Applications.Workflows.Requests;
using AnyNHibernate.Domains.Workflows;

namespace AnyNHibernate.Applications.Workflows
{
    public class WorkflowApplicationService
    {
        readonly IWorkflowRepository workflowRepository;
        readonly ITransactionExecutor transactionExecutor;

        public WorkflowApplicationService(IWorkflowRepository workflowRepository, ITransactionExecutor transactionExecutor)
        {
            this.workflowRepository = workflowRepository;
            this.transactionExecutor = transactionExecutor;
        }

        public void Create(CreateWorkflowRequest createWorkflowRequest)
        {
            Workflow workflow = WorkflowFactory.Build(createWorkflowRequest);
            transactionExecutor.Execute(() => { workflowRepository.Create(workflow); });
        }
    }
}