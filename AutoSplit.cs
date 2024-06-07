﻿using LiveSplitInterop.Commands;
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
        private static readonly BossStatus[] bosses =
        [
        #region bosses
            new()
            {
                Downed = () => NPC.downedSlimeKing,
                Enabled = config => config.KingSlime
            },
            new()
            {
                Downed = () => NPC.downedBoss1,
                Enabled = config => config.EyeOfCthulhu
            },
            new()
            {
                Downed = () => NPC.downedBoss2,
                Enabled = config => config.Boss2
            },
            new()
            {
                Downed = () => NPC.downedQueenBee,
                Enabled = config => config.QueenBee
            },
            new()
            {
                Downed = () => NPC.downedBoss3,
                Enabled = config => config.Skeletron
            },
            new()
            {
                Downed = () => NPC.downedDeerclops,
                Enabled = config => config.Deerclops
            },
            new()
            {
                Downed = () => Main.hardMode,
                Enabled = config => config.WallOfFlesh
            },
            new()
            {
                Downed = () => NPC.downedQueenSlime,
                Enabled = config => config.QueenSlime
            },
            new()
            {
                Downed = () => NPC.downedMechBoss1,
                Enabled = config => config.Destroyer
            },
            new()
            {
                Downed = () => NPC.downedMechBoss2,
                Enabled = config => config.Twins
            },
            new()
            {
                Downed = () => NPC.downedMechBoss3,
                Enabled = config => config.SkeletronPrime
            },
            new()
            {
                Downed = () => NPC.downedPlantBoss,
                Enabled = config => config.Plantera
            },
            new()
            {
                Downed = () => NPC.downedGolemBoss,
                Enabled = config => config.Golem
            },
            new()
            {
                Downed = () => NPC.downedFishron,
                Enabled = config => config.DukeFishron
            },
            new()
            {
                Downed = () => NPC.downedEmpressOfLight,
                Enabled = config => config.EmpressOfLight
            },
            new()
            {
                Downed = () => NPC.downedAncientCultist,
                Enabled = config => config.LunaticCultist
            },
            new()
            {
                Downed = () => NPC.downedTowerNebula,
                Enabled = config => config.NebulaPillar
            },
            new()
            {
                Downed = () => NPC.downedTowerSolar,
                Enabled = config => config.SolarPillar
            },
            new()
            {
                Downed = () => NPC.downedTowerStardust,
                Enabled = config => config.StardustPillar
            },
            new()
            {
                Downed = () => NPC.downedTowerVortex,
                Enabled = config => config.VortexPillar
            },
            new()
            {
                Downed = () => NPC.downedMoonlord,
                Enabled = config => config.MoonLord
            }
        #endregion
        ];

        public override void PostUpdateNPCs()
        {
            LiveSplitIntegrationConfig config = ModContent.GetInstance<LiveSplitIntegrationConfig>();

            if (bosses.Any(boss => boss.Update(config)))
            {
                LiveSplitIntegration.TrySendLsMsg(client => client.Split());
            }
        }
    }
}