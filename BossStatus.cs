using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace LiveSplitIntegration
{
    internal class BossStatus(bool initialState = false)
    {
        public Func<bool> IsDowned { private get; init; }
        public bool Downed { get; private set; } = initialState;
        public bool DownedLast { get; private set; } = initialState;
        public Func<LiveSplitIntegrationConfig, bool> Enabled { get; init; }
        private readonly LiveSplitIntegrationConfig config = ModContent.GetInstance<LiveSplitIntegrationConfig>();

        public bool Update()
        {
            Downed = IsDowned();
            bool split = Downed && !DownedLast && Enabled(config);
            DownedLast = Downed;
            return split;
        }
    }
}
