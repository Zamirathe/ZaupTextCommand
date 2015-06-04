using Rocket.API;
using System;
using System.Collections.Generic;

namespace ZaupTextCommands
{
    public class ZaupTextCommandConfiguration : IRocketPluginConfiguration
    {
        public List<TextCommand> commands;
        public IRocketPluginConfiguration DefaultConfiguration
        {
            get
            {
                return new ZaupTextCommandConfiguration()
                {
                    commands = new List<TextCommand>()
                    {
                        new TextCommand{
                            Name = "rules", 
                            Help = "Displays the server rules", 
                            Text = new List<string>() {
                                "No harrasment",
                                "No cursing", 
                                "No griefing",
                                "Any of the above will get you banned.",
                                "The above is just a sample of what you could use this for."
                            }
                        }
                    }
                };
            }
        }
    }
}
