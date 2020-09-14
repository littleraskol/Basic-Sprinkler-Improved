using System;
using StardewModdingAPI;

namespace BasicSprinklerImproved
{
    public class BasicSprinklerConfig
    {
        internal static BasicSprinklerConfig Instance { get; private set; }
        protected static IModHelper Helper => BasicSprinklerImproved.Instance.Helper;

        public String patternType { get; set; }

        public Int32 northArea { get; set; }
        public Int32 southArea { get; set; }
        public Int32 eastArea { get; set; }
        public Int32 westArea { get; set; }

        internal static void Load()
        {
            Instance = Helper.ReadConfig<BasicSprinklerConfig>();
        }

        internal static void Save()
        {
            Helper.WriteConfig(Instance);
        }

        internal static void Reset()
        {
            Instance = new BasicSprinklerConfig();
        }

        public BasicSprinklerConfig()
        {
            Instance = this;

            this.patternType = "horizontal";

            //Note: It doesn't actually matter what areas we're using with a default pattern. It will construct based on type. This just sets a good example.
            this.northArea = 0;
            this.southArea = 0;
            this.eastArea = 2;
            this.westArea = 2;
        }

        public BasicSprinklerConfig(string type, int[] dims)
        {
            Instance = this;

            this.patternType = type;

            this.northArea = dims[0];
            this.southArea = dims[1];
            this.eastArea = dims[2];
            this.westArea = dims[3];
        }

        public void SetUpGMCM()
        {
            //See if we can find GMCM, quit if not.
            var api = Helper.ModRegistry.GetApi<GenericModConfigMenu.GenericModConfigMenuAPI>
                ("spacechase0.GenericModConfigMenu");
            if (api == null)
                return;

            var manifest = BasicSprinklerImproved.Instance.ModManifest;
            api.RegisterModConfig(manifest, Reset, Save);

            //Pattern types
            api.RegisterLabel(manifest, "Improved Basic Sprinkler Settings", "Settings page for mod.");
            api.RegisterChoiceOption(manifest, "Watering Pattern", "Which watering pattern to use.", () => this.patternType, (string val) => this.patternType = val, WateringPattern.Instance.GetPatternTypes());
            api.RegisterLabel(manifest, "NOTE: Sum of values for custom pattern must not exceed 4.", "The improved basic sprinkler will have the same watering area as the default. Values entered here when custom pattern is selected will throw an error if they add up to more than 4. The game will use the default pattern.");
            api.RegisterClampedOption(manifest, "Custom North Area", "How far north the sprinkler should water.", () => this.northArea, (int val) => this.northArea = val, 1, 4);
            api.RegisterClampedOption(manifest, "Custom South Area", "How far south the sprinkler should water.", () => this.southArea, (int val) => this.southArea = val, 1, 4);
            api.RegisterClampedOption(manifest, "Custom East Area", "How far east the sprinkler should water.", () => this.eastArea, (int val) => this.eastArea = val, 1, 4);
            api.RegisterClampedOption(manifest, "Custom West Area", "How far west the sprinkler should water.", () => this.westArea, (int val) => this.westArea = val, 1, 4);
        }
    }
}
