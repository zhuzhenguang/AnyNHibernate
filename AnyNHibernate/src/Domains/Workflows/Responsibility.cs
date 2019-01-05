namespace AnyNHibernate.Domains.Workflows
{
    public class Responsibility : Entity
    {
        protected Responsibility()
        {
        }

        public Responsibility(string email)
        {
            Email = email;
        }

        public virtual string Email { get; protected set; }
        public virtual WorkflowTask Task { get; set; }
    }
}