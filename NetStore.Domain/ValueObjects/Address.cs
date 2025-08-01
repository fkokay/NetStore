using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.ValueObjects
{
    public sealed class Address : IEquatable<Address>
    {
        public string Street { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string Country { get; }

        public Address(string street, string city, string postalCode, string country)
        {
            if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Cadde boş olamaz.", nameof(street));
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("Şehir boş olamaz.", nameof(city));
            if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentException("Posta kodu boş olamaz.", nameof(postalCode));
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Ülke boş olamaz.", nameof(country));

            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public override bool Equals(object? obj)
            => Equals(obj as Address);

        public bool Equals(Address? other)
            => other is not null &&
               Street == other.Street &&
               City == other.City &&
               PostalCode == other.PostalCode &&
               Country == other.Country;

        public override int GetHashCode()
            => HashCode.Combine(Street, City, PostalCode, Country);

        public static bool operator ==(Address? left, Address? right)
            => EqualityComparer<Address>.Default.Equals(left, right);

        public static bool operator !=(Address? left, Address? right)
            => !(left == right);
    }
}
