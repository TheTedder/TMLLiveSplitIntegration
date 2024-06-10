using LiveSplitInterop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace LiveSplitIntegration
{
    public class AutoSplit : ModSystem
    {
        private readonly LiveSplitIntegration mod = ModContent.GetInstance<LiveSplitIntegration>();

        private readonly BossStatus[] bosses =
        [
        #region bosses
            new()
            {
                IsDowned = () => NPC.downedSlimeKing,
                Enabled = config => config.KingSlime
            },
            new()
            {
                IsDowned = () => NPC.downedBoss1,
                Enabled = config => config.EyeOfCthulhu
            },
            new()
            {
                IsDowned = () => NPC.downedBoss2,
                Enabled = config => config.Boss2
            },
            new()
            {
                IsDowned = () => NPC.downedQueenBee,
                Enabled = config => config.QueenBee
            },
            new()
            {
                IsDowned = () => NPC.downedBoss3,
                Enabled = config => config.Skeletron
            },
            new()
            {
                IsDowned = () => NPC.downedDeerclops,
                Enabled = config => config.Deerclops
            },
            new()
            {
                IsDowned = () => Main.hardMode,
                Enabled = config => config.WallOfFlesh
            },
            new()
            {
                IsDowned = () => NPC.downedQueenSlime,
                Enabled = config => config.QueenSlime
            },
            new()
            {
                IsDowned = () => NPC.downedMechBoss1,
                Enabled = config => config.Destroyer
            },
            new()
            {
                IsDowned = () => NPC.downedMechBoss2,
                Enabled = config => config.Twins
            },
            new()
            {
                IsDowned = () => NPC.downedMechBoss3,
                Enabled = config => config.SkeletronPrime
            },
            new()
            {
                IsDowned = () => NPC.downedPlantBoss,
                Enabled = config => config.Plantera
            },
            new()
            {
                IsDowned = () => NPC.downedGolemBoss,
                Enabled = config => config.Golem
            },
            new()
            {
                IsDowned = () => NPC.downedFishron,
                Enabled = config => config.DukeFishron
            },
            new()
            {
                IsDowned = () => NPC.downedEmpressOfLight,
                Enabled = config => config.EmpressOfLight
            },
            new()
            {
                IsDowned = () => NPC.downedAncientCultist,
                Enabled = config => config.LunaticCultist
            },
            new()
            {
                IsDowned = () => NPC.downedTowerNebula,
                Enabled = config => config.NebulaPillar
            },
            new()
            {
                IsDowned = () => NPC.downedTowerSolar,
                Enabled = config => config.SolarPillar
            },
            new()
            {
                IsDowned = () => NPC.downedTowerStardust,
                Enabled = config => config.StardustPillar
            },
            new()
            {
                IsDowned = () => NPC.downedTowerVortex,
                Enabled = config => config.VortexPillar
            },
            new()
            {
                IsDowned = () => NPC.downedMoonlord,
                Enabled = config => config.MoonLord
            },
            new()
            {
                IsDowned = () => NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3,
                Enabled = config => config.AllMechBosses
            },
            new()
            {
                IsDowned = () => NPC.downedTowerVortex && NPC.downedTowerStardust,
                Enabled = config => config.FirstTwoPillars
            },
            new()
            {
                IsDowned = () => NPC.downedTowers,
                Enabled = config => config.AllPillars
            }
        #endregion
        ];

        public override void PostUpdateNPCs()
        {
            if (bosses.Any(boss => boss.Update()))
            {
                mod.TrySendLsMsg(client => client.Split());
            }
        }
    }
}
