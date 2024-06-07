using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplitIntegration
{
    internal class BossStatus(bool initialState = false)
    {
        public Func<bool> Downed { get; init; }
        public bool DownedLast { get; private set; } = initialState;
        public Func<LiveSplitIntegrationConfig, bool> Enabled { get; init; }

        public bool Update(LiveSplitIntegrationConfig config)
        {
            bool downed = Downed();
            bool split = downed && !DownedLast;
            DownedLast = downed;
            return split && Enabled(config);
        }
    }
}
