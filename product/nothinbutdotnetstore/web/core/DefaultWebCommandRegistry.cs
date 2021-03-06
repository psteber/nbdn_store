using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultWebCommandRegistry : WebCommandRegistry
    {
        IEnumerable<WebCommand> known_commands;

        public DefaultWebCommandRegistry(IEnumerable<WebCommand> known_commands)
        {
            this.known_commands = known_commands;
        }

        public WebCommand get_the_command_that_can_process(Request request)
        {
            return known_commands.FirstOrDefault(x => x.can_handle(request)) ??
                new MissingWebCommand();
        }
    }
}