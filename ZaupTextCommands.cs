using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                foreach (TextCommand command in this.Configuration.Instance.commands)
                {
                    Commander.register(new ZaupTextCommand(command.Name, command.Help, command.Text));
                }
            }
        }
        protected override void Unload()
        {
            if (this.Configuration.Instance.commands.Count > 0 && this.Configuration != null && this.Configuration.Instance.commands != null)
            {
                foreach (Command command in (
                    from c in Commander.Commands
                    where c is ZaupTextCommand
                    select c).ToList<Command>())
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
			this._command = cName;
			this._help = cHelp;
			this._info = this._command + " - " + this._help;
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
