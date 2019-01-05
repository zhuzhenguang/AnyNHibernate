namespace AnyNHibernate.Domains
{
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }
    }
}