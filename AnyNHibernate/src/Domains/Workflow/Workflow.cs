using System.Collections.Generic;

namespace AnyNHibernate.Domains.Workflow
{
    public class Workflow : Entity
    {
        protected Workflow()
        {
        }

        public Workflow(string name)
        {
            Name = name;
            Tasks = new List<WorkflowTask>();
        }

        public virtual string Name { get; protected set; }
        public virtual IList<WorkflowTask> Tasks { get; protected set; }

        public virtual void AddTasks(WorkflowTask task)
        {
            task.Workflow = this;
            Tasks.Add(task);
        }
    }
}