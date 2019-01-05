using AnyNHibernate.Domains;
using AnyNHibernate.Domains.Workflow;
using FluentNHibernate.Mapping;

namespace AnyNHibernate.Infrastructures
{
    public class ResponsibilityMapping: ClassMap<Responsibility>
    {
        public ResponsibilityMapping()
        {
            Table("workflow_responsibility");
            Id(t => t.Id).Column("id");
            Map(w => w.Email).Column("email");
            References(t => t.Task).Column("workflow_task_id").Not.Nullable();
        }
    }
}