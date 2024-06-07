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
        [DefaultValue(true)]
        public bool KingSlime;

        [DefaultValue(true)]
        public bool EyeOfCthulhu;

        [DefaultValue(true)]
        public bool Boss2;

        [DefaultValue(true)]
        public bool QueenBee;

        [DefaultValue(true)]
        public bool Skeletron;

        [DefaultValue(true)]
        public bool Deerclops;

        [DefaultValue(true)]
        public bool WallOfFlesh;
        
        [DefaultValue(true)]
        public bool QueenSlime;

        [DefaultValue(true)]
        public bool Destroyer;

        [DefaultValue(true)]
        public bool Twins;
        
        [DefaultValue(true)]
        public bool SkeletronPrime;

        [DefaultValue(true)]
        public bool Plantera;

        [DefaultValue(true)]
        public bool Golem;
        
        [DefaultValue(true)]
        public bool DukeFishron;

        [DefaultValue(true)]
        public bool EmpressOfLight;

        [DefaultValue(true)]
        public bool LunaticCultist;

        [DefaultValue(true)]
        public bool NebulaPillar;

        [DefaultValue(true)]
        public bool SolarPillar;

        [DefaultValue(true)]
        public bool StardustPillar;

        [DefaultValue(true)]
        public bool VortexPillar;

        [DefaultValue(true)]
        public bool MoonLord;
    }
}
