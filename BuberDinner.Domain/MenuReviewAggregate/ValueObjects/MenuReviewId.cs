﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects
{
    public sealed class MenuReviewId : ValueObject
    {
        public Guid Value { get; }

        private MenuReviewId(Guid value)
        {
            Value = value;
        }

        public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

        public static MenuReviewId Create(Guid value) => new(value);

        public override IEnumerable<object> GetEqualityComponnents()
        {
            yield return Value; 
        }
    }
}
