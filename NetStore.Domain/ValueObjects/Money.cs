using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.ValueObjects
{
    public sealed class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0) throw new ArgumentException("Tutar negatif olamaz.", nameof(amount));
            if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentException("Para birimi boş olamaz.", nameof(currency));

            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money other)
        {
            if (other.Currency != Currency)
                throw new InvalidOperationException("Farklı para birimleri toplanamaz.");

            return new Money(Amount + other.Amount, Currency);
        }

        public override bool Equals(object? obj)
            => Equals(obj as Money);

        public bool Equals(Money? other)
            => other is not null &&
               Amount == other.Amount &&
               Currency == other.Currency;

        public override int GetHashCode()
            => HashCode.Combine(Amount, Currency);

        public static bool operator ==(Money? left, Money? right)
            => EqualityComparer<Money>.Default.Equals(left, right);

        public static bool operator !=(Money? left, Money? right)
            => !(left == right);

        public override string ToString() => $"{Amount} {Currency}";
    }
}
