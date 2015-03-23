using System;

namespace LianZhao.Data.Entity
{
    public static class EntityExtensions
    {
        public static bool IdEquals(this IEntity<int> entity, int id)
        {
            return entity.Id == id;
        }

        public static bool IdEquals(this IEntity<int> left, IEntity<int> right)
        {
            return left.Id == right.Id;
        }

        public static bool IdEquals(this IEntity<long> entity, long id)
        {
            return entity.Id == id;
        }

        public static bool IdEquals(this IEntity<long> left, IEntity<long> right)
        {
            return left.Id == right.Id;
        }

        public static bool IdEquals(this IEntity<Guid> entity, Guid id)
        {
            return entity.Id == id;
        }

        public static bool IdEquals(this IEntity<Guid> left, IEntity<Guid> right)
        {
            return left.Id == right.Id;
        }

        public static bool IdEquals(
            this IEntity<string> entity,
            string id,
            StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            return entity.Id.Equals(id, comparisonType);
        }

        public static bool IdEquals<TId>(this IEntity<TId> entity, TId id)
            where TId : IEquatable<TId>
        {
            return entity.Id.Equals(id);
        }

        public static bool IdEquals(
            this IEntity<string> left,
            IEntity<string> right,
            StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            return left.Id.Equals(right.Id, comparisonType);
        }

        public static bool IdEquals<TId>(this IEntity<TId> left, IEntity<TId> right)
            where TId : IEquatable<TId>
        {
            return left.Id.Equals(right.Id);
        }

        public static bool IsNew(this IEntity<int> entity)
        {
            return entity.Id == 0;
        }

        public static bool IsNew(this IEntity<long> entity)
        {
            return entity.Id == 0;
        }

        public static bool IsNew(this IEntity<Guid> entity)
        {
            return entity.Id == Guid.Empty;
        }

        public static bool IsNew(this IEntity<string> entity)
        {
            return entity.Id == null;
        }

        public static bool IsNew<TId>(this IEntity<TId> entity)
            where TId : IEquatable<TId>
        {
            return entity.Id.Equals(default(TId));
        }
    }
}