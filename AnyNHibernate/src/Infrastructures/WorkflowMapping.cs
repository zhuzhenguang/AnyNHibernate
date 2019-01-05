using AnyNHibernate.Domains;
using AnyNHibernate.Domains.Workflow;
using FluentNHibernate.Mapping;

namespace AnyNHibernate.Infrastructures
{
    public class WorkflowMapping : ClassMap<Workflow>
    {
        public WorkflowMapping()
        {
            Table("workflow");
            Id(w => w.Id).Column("id");
            Map(w => w.Name).Column("name");
            HasMany(w => w.Tasks)
                .Not.LazyLoad()
                .Table("workflow_task")
                .KeyColumn("workflow_id")
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}