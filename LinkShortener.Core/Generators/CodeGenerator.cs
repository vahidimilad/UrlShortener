using System;
using System.Collections.Generic;
using System.Text;

namespace LinkShortener.Core.Generators
{
    public class CodeGenerator
    {
        public static string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0,7).ToLower();
        }
    }
}
