namespace AnyNHibernate.Domains.Workflows
{
    public class WorkflowTaskDependsOn : Entity
    {
        public WorkflowTaskDependsOn()
        {
        }

        public WorkflowTaskDependsOn(WorkflowTask origin, WorkflowTask dependent)
        {
            Origin = origin;
            Dependent = dependent;
        }

        public virtual WorkflowTask Origin { get; protected set; }
        public virtual WorkflowTask Dependent { get; protected set; }
    }
}