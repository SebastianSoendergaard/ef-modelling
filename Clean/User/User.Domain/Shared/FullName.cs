﻿using Shared;

namespace User.Domain.Shared
{
    public sealed class FullName : ValueObject
    {
        private FullName()
        {
        }

        private FullName(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }

        public static FullName From(string? firstName, string? lastName)
        {
            return new FullName(firstName, lastName);
        }
    }
}
