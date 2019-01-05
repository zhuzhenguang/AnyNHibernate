using System.Collections.Generic;
using System.Linq;
using AnyNHibernate.Applications.Workflows.Requests;
using AnyNHibernate.Domains.Workflows;

namespace AnyNHibernate.Applications.Workflows
{
    public class WorkflowFactory
    {
        public static Workflow Build(CreateWorkflowRequest createWorkflowRequest)
        {
            List<WorkflowTask> workflowTasks = createWorkflowRequest.Tasks
                .Select(task => new WorkflowTask(task.Name))
                .ToList();

            var workflow = new Workflow(createWorkflowRequest.WorkflowName);
            workflow.ReplaceTasks(workflowTasks);
            return workflow;
        }
    }
}