using System.Collections.Generic;
using System.Linq;
using AnyNHibernate.Applications;
using AnyNHibernate.Applications.Workflows;
using AnyNHibernate.Applications.Workflows.Requests;
using AnyNHibernate.Domains;
using AnyNHibernate.Domains.Workflows;
using AnyNHibernate.Infrastructures;
using AnyNHibernate.Infrastructures.Mappings;
using Xunit;

namespace AnyNHibernate.test
{
    public class WorkflowApplicationServiceFacts : FactBase
    {
        [Fact]
        public void should_save_workflow()
        {
            var createWorkflowRequest = new CreateWorkflowRequest
            {
                WorkflowName = "workflow",
                Tasks = new List<CreateWorkflowTaskRequest>
                {
                    new CreateWorkflowTaskRequest {Name = "task 1"}
                }
            };
            var workflowApplicationService = new WorkflowApplicationService(
                new WorkflowRepository(ResolveSession()), 
                new TransactionExecutor(ResolveSession()));

            workflowApplicationService.Create(createWorkflowRequest);

            Workflow workflow = ResolveSession().Query<Workflow>().Single();
            Assert.Equal("workflow", workflow.Name);
            Assert.Single(workflow.Tasks);
            Assert.Equal("task 1", workflow.Tasks[0].Name);
        }
    }
}