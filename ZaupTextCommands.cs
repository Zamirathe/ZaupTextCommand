using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rocket.API;
using Rocket.Core;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Plugins;
using SDG.Unturned;
using Steamworks;

namespace ZaupTextCommands
{
    public class ZaupTextCommands : RocketPlugin<ZaupTextCommandConfiguration>
    {
        protected override void Load()
        {
            if (this.Configuration.Instance.commands.Count > 0 && this.Configuration != null && this.Configuration.Instance.commands != null)
            {
                foreach (ZaupTextCommand command in this.Configuration.Instance.commands)
                {
                    Commander.register(command);
                }
            }
        }
        protected override void Unload()
        {
            if (this.Configuration.Instance.commands.Count > 0 && this.Configuration != null && this.Configuration.Instance.commands != null)
            {
                foreach (ZaupTextCommand command in this.Configuration.Instance.commands)
                {
                    Commander.deregister(command);
                }
            }
        }
    }
    public class ZaupTextCommand : Command
    {
        private List<string> text;
        public ZaupTextCommand(string cName, string cHelp, List<string> text)
		{
			this.commandName = cName;
			this.commandHelp = cHelp;
			this.commandInfo = this.commandName + " - " + this.commandHelp;
			this.text = text;
		}
        public ZaupTextCommand()
        { }
		protected override void execute(CSteamID caller, string command)
		{
			foreach (string str in this.text)
			{
				UnturnedChat.Say(caller, str);
			}
		}
    }
}
