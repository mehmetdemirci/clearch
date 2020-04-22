using System;
namespace Domain.DDD
{
    public interface Identifiable<TId>
        where TId : IComparable, IComparable<TId>, IEquatable<TId>
    {
        TId Id { get; }
    }
}
