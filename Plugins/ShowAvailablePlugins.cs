namespace Plugins
{
    public class ShowAvailablePlugins : IPlugin
    {
        const string PLUGIN_NAME = "ShowAvailablePlugins";
        const string PLUGIN_DESCRIPTION = "This plugin lists all available plugins.";
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

        public void DesctiptionMethod(string parameters)
        {
            Console.WriteLine("Available plugins:");
            foreach(IPlugin plugin in PluginLoader.Plugins)
            {
                if(plugin.Name != PLUGIN_NAME)
                {                   
                    Console.WriteLine(string.Format("{0}: {1}", plugin.Name, plugin.Description));
                }
            }
        }
    }
}
