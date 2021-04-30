using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct,
                       AllowMultiple = true)]
    public class PathAttribute : System.Attribute
    {
        private string PathToLibrary { get; set; }

        public PathAttribute(string pathToLibrary)
        {
            this.PathToLibrary = pathToLibrary;
        }

        public string GetPath()
        {
            return PathToLibrary;
        }
    }
}
