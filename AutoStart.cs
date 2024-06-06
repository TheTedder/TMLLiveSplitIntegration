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
        public override void OnEnterWorld()
        {
            LiveSplitIntegration.TrySendLsMsg(Client => Client.Start());
        }
    }
}
