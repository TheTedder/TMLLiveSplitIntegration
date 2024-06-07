using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace LiveSplitIntegration
{
    public class LiveSplitIntegrationConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        public bool Autostart;

        [Header("Splits")]
        [DefaultValue(false)]
        public bool KingSlime;

        [DefaultValue(false)]
        public bool EyeOfCthulhu;

        [DefaultValue(false)]
        public bool Boss2;

        [DefaultValue(false)]
        public bool QueenBee;

        [DefaultValue(true)]
        public bool Skeletron;

        [DefaultValue(false)]
        public bool Deerclops;

        [DefaultValue(true)]
        public bool WallOfFlesh;
        
        [DefaultValue(false)]
        public bool QueenSlime;

        [DefaultValue(true)]
        public bool Destroyer;

        [DefaultValue(false)]
        public bool Twins;
        
        [DefaultValue(false)]
        public bool SkeletronPrime;

        [DefaultValue(false)]
        public bool Plantera;

        [DefaultValue(true)]
        public bool Golem;
        
        [DefaultValue(false)]
        public bool DukeFishron;

        [DefaultValue(false)]
        public bool EmpressOfLight;

        [DefaultValue(true)]
        public bool LunaticCultist;

        [DefaultValue(false)]
        public bool NebulaPillar;

        [DefaultValue(false)]
        public bool SolarPillar;

        [DefaultValue(false)]
        public bool StardustPillar;

        [DefaultValue(false)]
        public bool VortexPillar;

        [DefaultValue(true)]
        public bool MoonLord;

        [DefaultValue(true)]
        public bool AllMechBosses;

        [DefaultValue(false)]
        public bool FirstTwoPillars;

        [DefaultValue(false)]
        public bool AllPillars;
    }
}
