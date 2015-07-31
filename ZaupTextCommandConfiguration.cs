using Rocket.API;
using System;
using System.Collections.Generic;

namespace ZaupTextCommands
{
    public class ZaupTextCommandConfiguration : IRocketPluginConfiguration
    {
        public List<ZaupTextCommand> commands;

        public void LoadDefaults()
        {
            commands = new List<ZaupTextCommand>()
            {
                new ZaupTextCommand
                (
                    "rules", 
                    "Displays the server rules", 
                    new List<string>() {
                        "No harrasment",
                        "No cursing", 
                        "No griefing",
                        "Any of the above will get you banned.",
                        "The above is just a sample of what you could use this for."
                    }
                )
            };
        }
    }
}
