using Plugins;

namespace ConsoleAppHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plugin app has started...");

            try
            {
                PluginLoader loader = new PluginLoader();
                loader.LoadPlugins();
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Plugins couldn't be loaded: {0}", ex.Message));
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            while (true)
            {
                try
                {
                    Console.Write("> ");
                    string userInput = Console.ReadLine();
                    string pluginName = userInput.Split(new char[] { ' ' }).FirstOrDefault();

                    if (userInput == "exit")
                    {
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                    }

                    IPlugin plugin = PluginLoader.Plugins.Where(plugIn => plugIn.Name == pluginName).FirstOrDefault();
                    if (plugin != null)
                    {
                        string parameters = userInput.Replace(string.Format("{0}", pluginName), string.Format("---{0}---", pluginName));
                        plugin.DesctiptionMethod(parameters);
                    }
                    else
                    {
                        //if the plugin is found
                        Console.WriteLine("No plugin with name: {0}, has been found", pluginName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Caught exception: {0}", ex.Message));
                }
            }
        }
    }
}
