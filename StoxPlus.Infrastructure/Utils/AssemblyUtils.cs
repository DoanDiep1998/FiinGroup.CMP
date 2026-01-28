using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace StoxPlus.Infrastructure.Utils
{
    public class AssemblyUtils
    {
        public static List<Assembly> GetAssemblies(params string[] prefix)
        {
            if (prefix?.Any() != true)
                prefix = new[] { "FiinTrade", "StoxPlus", "FiinGroup" };

            return _().ToList(); IEnumerable<Assembly> _()
            {
                var asm = Assembly.GetEntryAssembly();
                yield return asm;
                foreach (var an in asm.GetReferencedAssemblies().Where(an => prefix.Any(p => an.FullName.StartsWith(p))))
                    yield return Assembly.Load(an);
            }
        }
    }
}


