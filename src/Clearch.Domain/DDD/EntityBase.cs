using System;

namespace Domain.DDD
{
    public abstract class EntityBase<TId> : Identifiable<TId>
        where TId : IComparable, IComparable<TId>, IEquatable<TId>
    {
        protected EntityBase() { }

        protected EntityBase(TId id)
        {
            Id = id;
        }

        public TId Id { get; protected set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as EntityBase<TId>);
        }

        public bool Equals(EntityBase<TId> other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                return (GetType().GetHashCode() * 97) ^ Id.GetHashCode();
            }
        }
    }
}
