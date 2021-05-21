using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public class Alias
    {
        public string Value { get; }

        public Alias()
        {
        }

        public Alias(string value)
        {
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Alias other)
            {
                if (Value == other.Value)
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}