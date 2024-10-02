using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class Hello : IPlugin
    {
        const string PLUGIN_NAME = "hello";
        const string PLUGIN_DESCRIPTION = "This plugin greets the user whenever invoked";

        public string Name
        {
            get
            {
                return PLUGIN_NAME;
            }
        }

        public string Description
        {
            get
            {
                return PLUGIN_DESCRIPTION;
            }
        }

        public void DescriptionMethod(string parameters)
        {
            Console.WriteLine(parameters);
        }
    }
}
