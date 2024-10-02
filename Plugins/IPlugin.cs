using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    //base information a plugin should have
    //name of the plugin
    //some description
    //method to describe what does the plugin do
    public interface IPlugin
    {
        public string Name { get; }
        public string Description {  get; }

        public void DesctiptionMethod(string parameters)
        {
            Console.WriteLine(parameters);
        }
    }
}
