using System;

namespace AnyNHibernate.Applications
{
    public interface ITransactionExecutor
    {
        void Execute(Action executeBody);
    }
}