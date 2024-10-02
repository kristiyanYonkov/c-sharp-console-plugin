using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class PluginLoader
    {
        const string DIRECTORY_NAME = "Plugins";
        public static List<IPlugin> Plugins { get; set; }

        public void LoadPlugins()
        {
            //create a new empty list of type IPlugin
            Plugins = new List<IPlugin>();

            //check if a given directory exists
            if (Directory.Exists(DIRECTORY_NAME))
            {
                //loop through all of the files in a given directory
                //and check for files with extension ".dll"
                //if found load the files to the console app assembly
                foreach (string file in Directory.GetFiles(DIRECTORY_NAME))
                {
                    if (file.EndsWith(".dll"))
                    {
                        Assembly.LoadFile(file);
                    }
                }
            }

            //ensure that the loaded assemblies are of type IPlugin and are classes
            Type interfaceType = typeof(IPlugin);
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(assemblyType => interfaceType.IsAssignableFrom(assemblyType) && assemblyType.IsClass)
                .ToArray();

            foreach(Type type in types)
            {
                Plugins.Add((IPlugin)Activator.CreateInstance(type));
            }
        }
    }
}
