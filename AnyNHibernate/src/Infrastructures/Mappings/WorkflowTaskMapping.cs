using AnyNHibernate.Domains.Workflows;
using FluentNHibernate.Mapping;

namespace AnyNHibernate.Infrastructures.Mappings
{
    public class WorkflowTaskMapping : ClassMap<WorkflowTask>
    {
        public WorkflowTaskMapping()
        {
            Table("workflow_task");
            Id(t => t.Id).Column("id");
            Map(w => w.Name).Column("name");
            References(t => t.Workflow).Column("workflow_id").Not.Nullable();
            HasMany(t => t.Responsibilities)
                .Not.LazyLoad()
                .Table("responsibility")
                .Inverse()
                .KeyColumn("workflow_task_id")
                .Cascade.AllDeleteOrphan();
            HasMany(t => t.TaskDependsOns)
                .Not.LazyLoad()
                .Table("workflow_task_depends_on")
                .Inverse()
                .KeyColumn("origin_task_id")
                .Cascade.AllDeleteOrphan();
        }
    }
}