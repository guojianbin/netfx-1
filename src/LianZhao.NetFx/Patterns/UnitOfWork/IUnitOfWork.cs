using System;

namespace LianZhao.Patterns.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsCommitted { get; }

        void Commit();
    }
}