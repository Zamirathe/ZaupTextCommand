using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned;
using Rocket.Unturned.Logging;
using Rocket.Unturned.Plugins;
using SDG.Unturned;
using Steamworks;

namespace ZaupTextCommands
{
    public class ZaupTextCommands : RocketPlugin<ZaupTextCommandConfiguration>
    {
        protected override void Load()
        {
            if (this.Configuration.commands.Count > 0)
            {
                foreach (TextCommand command in this.Configuration.commands)
                {
                    List<Command> list = new List<Command>();
                    Command zcommand = new ZaupTextCommand(command.Name, command.Help, command.Text);
                    List<Command> commands = Commander.Commands;
                    bool flag = false;
                    for (int i = 0; i < commands.Count; i++)
                    {
                        Command command2 = commands[i];
                        if (command2.commandName.ToLower().Equals(zcommand.commandName.ToLower()))
                        {
                            Logger.LogWarning(string.Concat(new string[]
				            {
					        "Couldn't register RocketTextCommand.",
					        zcommand.commandName,
					        " because it would overwrite ",
					        command2.GetType().Assembly.GetName().Name,
					        ".",
					        command2.commandName
				            }));
                            flag = true;
                        }
                        else
                        {
                            list.Add(command2);
                        }
                    }
                    if (!flag)
                    {
                        // We add the command.
                        Logger.Log("Added command ZaupTextCommand." + zcommand.commandName);
                        Commander.register(zcommand);
                    }
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
		protected override void execute(CSteamID caller, string command)
		{
			foreach (string str in this.text)
			{
				RocketChat.Say(caller, str);
			}
		}
    }
}
