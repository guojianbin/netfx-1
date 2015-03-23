using System;

namespace LianZhao
{
    public static class GuidExtensions
    {
        public static bool IsNullOrEmpty(this Guid? id)
        {
            return id == null || id.Value.IsEmpty();
        }

        public static bool IsEmpty(this Guid id)
        {
            return id.Equals(Guid.Empty);
        }
    }
}