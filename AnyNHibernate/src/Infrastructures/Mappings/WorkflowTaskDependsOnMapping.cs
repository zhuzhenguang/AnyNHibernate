using AnyNHibernate.Domains.Workflows;
using FluentNHibernate.Mapping;

namespace AnyNHibernate.Infrastructures.Mappings
{
    public class WorkflowTaskDependsOnMapping : ClassMap<WorkflowTaskDependsOn>
    {
        public WorkflowTaskDependsOnMapping()
        {
            Table("workflow_task_depends_on");
            Id(t => t.Id).Column("id");
            References(t => t.Origin).Column("origin_task_id").Not.Nullable();
            References(t => t.Dependent).Column("dependent_task_id").Not.Nullable();
        }
    }
}