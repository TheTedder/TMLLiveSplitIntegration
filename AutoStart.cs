using LiveSplitInterop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace LiveSplitIntegration
{
    public class AutoStart : ModPlayer
    {
        private readonly LiveSplitIntegration mod = ModContent.GetInstance<LiveSplitIntegration>();
        private readonly LiveSplitIntegrationConfig config = ModContent.GetInstance<LiveSplitIntegrationConfig>();

        public override void OnEnterWorld()
        {
            if (config.Autostart)
            {
                mod.TrySendLsMsg(client => client.Start());
            }
        }
    }
}
