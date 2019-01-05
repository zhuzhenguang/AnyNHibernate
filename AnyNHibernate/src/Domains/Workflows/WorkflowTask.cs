using System.Collections.Generic;

namespace AnyNHibernate.Domains.Workflows
{
    public class WorkflowTask : Entity
    {
        protected WorkflowTask()
        {
        }

        public WorkflowTask(string name)
        {
            Name = name;
            Responsibilities = new List<Responsibility>();
            TaskDependsOns = new List<WorkflowTaskDependsOn>();
        }

        public virtual string Name { get; protected set; }
        public virtual Workflow Workflow { get; set; }
        public virtual IList<Responsibility> Responsibilities { get; protected set; }
        public virtual IList<WorkflowTaskDependsOn> TaskDependsOns { get; protected set; }

        public virtual void AssignTo(Responsibility responsibility)
        {
            responsibility.Task = this;
            Responsibilities.Add(responsibility);
        }

        public virtual void DependsOn(WorkflowTask dependent)
        {
            TaskDependsOns.Add(new WorkflowTaskDependsOn(this, dependent));
        }
    }
}