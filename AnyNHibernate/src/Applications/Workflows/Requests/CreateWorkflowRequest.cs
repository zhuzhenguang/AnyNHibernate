using System.Collections.Generic;

namespace AnyNHibernate.Applications.Workflows.Requests
{
    public class CreateWorkflowRequest
    {
        public string WorkflowName { get; set; }
        public List<CreateWorkflowTaskRequest> Tasks { get; set; }
    }
}