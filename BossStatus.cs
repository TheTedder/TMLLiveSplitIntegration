using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace LiveSplitIntegration
{
    /// <summary>
    /// A class that tracks whether a certain boss has been defeated.
    /// </summary>
    /// <param name="initialState">
    /// The value to initialize <see cref="Downed"/> and <see cref="DownedLast"/> with.
    /// </param>
    internal class BossStatus(bool initialState = false)
    {
        // TODO: Use inheritance instead of Func properties.

        /// <summary>
        /// A <see cref="Func{TResult}"/> that returns whether or not the boss has been defeated.
        /// </summary>
        public Func<bool> IsDowned { private get; init; }

        /// <summary>
        /// Whether or not the boss has been defeated.
        /// </summary>
        public bool Downed { get; private set; } = initialState;

        /// <summary>
        /// Whether or not the boss was defeated during the previous <see cref="Update"/> call.
        /// </summary>
        public bool DownedLast { get; private set; } = initialState;

        /// <summary>
        /// A <see cref="Func{TResult}"/> that returns whether or not this boss is being tracked.
        /// </summary>
        public Func<LiveSplitIntegrationConfig, bool> Enabled { get; init; }

        /// <summary>
        /// A reference to the config.
        /// </summary>
        private readonly LiveSplitIntegrationConfig config = ModContent.GetInstance<LiveSplitIntegrationConfig>();

        /// <summary>
        /// Update the status of the boss.
        /// </summary>
        /// <returns>
        /// Whether or not the boss was defeated on this update cycle or `false` if this tracker is not enabled.
        /// </returns>
        public bool Update()
        {
            Downed = IsDowned();
            bool split = Downed && !DownedLast && Enabled(config);
            DownedLast = Downed;
            return split;
        }
    }
}
