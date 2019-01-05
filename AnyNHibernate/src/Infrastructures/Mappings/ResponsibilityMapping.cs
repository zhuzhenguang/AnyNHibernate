using AnyNHibernate.Domains.Workflows;
using FluentNHibernate.Mapping;

namespace AnyNHibernate.Infrastructures.Mappings
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