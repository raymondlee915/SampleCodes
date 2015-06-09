using Dell.Client.Framework.Agent;
using Dell.Client.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCFPluginSample
{
    [PluginInfo(Name = "HelloWorld", Version = "2.3", Id = "08D2290F-7E28-4598-91BE-ED5C67B11032", Description = "This is a sample plugin. Hello world.")]
    public class DCFHelloWorldPlugin : IAgentPlugin
    {
        public DCFHelloWorldPlugin(IAgent agent)
        {
            var logger = agent.CreateLog("Hello");
            logger.Info("test log info from hello");
            logger.Debug("test  log debug from hello");
            logger.Fatal("test  log Fatal from hello");

            var logger2 = agent.CreateLog("World");
            logger2.Info("test log info from World");
            logger2.Debug("test  log debug from World");
            logger2.Fatal("test  log Fatal from World");       
        }

        public AgentPluginInfo GetAgentPluginInfo()
        {
            AgentPluginInfo info = new AgentPluginInfo();
            info.PluginName = "helloworld";
            return info;
        }

        public void OnSetPolicies(string strPolicies)
        {
           
        }

        public void OnStartPlugin()
        {
            Service1.terms = "hello world";
            
        }

        public void OnStopPlugin()
        {
           
        }

        public string PolicyId
        {
            get { return string.Empty; }
        }
    }
}
