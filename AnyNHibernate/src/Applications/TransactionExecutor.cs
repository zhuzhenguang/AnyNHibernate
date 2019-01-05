using System;
using NHibernate;

namespace AnyNHibernate.Applications
{
    public class TransactionExecutor : ITransactionExecutor
    {
        readonly ISession session;

        public TransactionExecutor(ISession session)
        {
            this.session = session;
        }

        public void Execute(Action executeBody)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                executeBody();
                transaction.Commit();
            }
        }
    }
}