using System.Collections.Generic;

namespace AnyNHibernate.Domains.Workflows
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

        public virtual void AddTask(WorkflowTask task)
        {
            task.Workflow = this;
            Tasks.Add(task);
        }

        public virtual void ReplaceTasks(IEnumerable<WorkflowTask> tasks)
        {
            foreach (WorkflowTask task in tasks)
            {
                AddTask(task);
            }
        }
    }
}