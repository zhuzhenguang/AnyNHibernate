using System.Linq;
using AnyNHibernate.Domains.Workflow;
using Xunit;

namespace AnyNHibernate.test
{
    public class WorkflowFacts : FactBase
    {
        [Fact]
        public void should_create_workflow()
        {
            var initialTask = new WorkflowTask("task 1");
            initialTask.AssignTo(new Responsibility("zhu@google.com"));

            var endTask = new WorkflowTask("task 2");
            endTask.AssignTo(new Responsibility("zhen@google.com"));
            endTask.DependsOn(initialTask);

            var workflow = new Workflow("workflow");
            workflow.AddTasks(initialTask);
            workflow.AddTasks(endTask);

            ResolveSession().Save(workflow);

            ResolveSession().Clear();
            workflow = ResolveSession().Query<Workflow>().Single();

            Assert.True(workflow.Id > 0);
            Assert.Equal("workflow", workflow.Name);

            Assert.Equal(2, workflow.Tasks.Count);
            Assert.Equal("task 1", workflow.Tasks[0].Name);
            Assert.Single(workflow.Tasks[0].Responsibilities);
            Assert.Equal("zhu@google.com", workflow.Tasks[0].Responsibilities[0].Email);

            Assert.Equal("task 2", workflow.Tasks[1].Name);
            Assert.Single(workflow.Tasks[1].Responsibilities);
            Assert.Equal("zhen@google.com", workflow.Tasks[1].Responsibilities[0].Email);

            Assert.Single(workflow.Tasks[1].TaskDependsOns);
        }
    }
}