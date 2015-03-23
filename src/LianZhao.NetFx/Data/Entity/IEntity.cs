using System;

namespace LianZhao.Data.Entity
{
    public interface IEntity<out TId>
        where TId : IEquatable<TId>
    {
         TId Id { get; }
    }
}