using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerSaveEditor
{
    // TODO: Sort this
    public enum TreeComponentName // Specifically sorted so that (int)name is the same number as in the games code
    {
        KarutaPlates,
        SerendipitousBodies,
        PathOfResilience,
        KusariJacket,
        EnergyShuriken,
        SerendipitousMinds,
        PreparedMind,
        Meditation,


        // Unsorted below
        StrikeOfTheNinja = 11,
        SecondWind = 12,
        CurrentsMaster = 13,
        AerobaticsWarrior = 14,
        TimeSense = 16,
        RejuvenativeSpirit,
        CenteredMind,
        DemonsBane,
        DevilsDue,
        PowerSense,
        FocusedPowerSense
    }

    public enum ItemComponentName
    {
        MapUpgrade = 3,
        RopeDart = 4,
        Wingsuit = 6,
        ClimbingClaws = 7,
        Seashell = 19,
        PowerThistle = 25,
        AstralSeed = 56,
        AstralTeaLeaves = 57,
        Candle = 29,
        LightFootTabi = 40,
        DemonCrown = 51,
        Map = 52,
        RuxxtinsAmulet = 55,
        SunCrest = 58,
        MoonCrest = 59,
        Firefly = 60,

        // Upgraded map, Cloudstep, ClimbingClaws are either 3, 7 or 52
        KarutaPlates = 2,
        EnergyShuriken = 26,
        SecondWind = 37,
        ShurikenUpgrade = 38,
        CurrentsMaster = 39,
        AerobaticsWarrior = 41,
        SerendipitousMinds = 61,
        SerendipitousBodies = 62,
        DemonsBane = 63,
        StrikeOfTheNinja = 64,

        KeyOfCourage = 11,
        KeyOfHope = 12,
        KeyOfLove = 13,
        KeyOfStrength = 14,
        KeyOfChaos = 15,
        KeyOfSymbiosis = 16,

        Necro = 20,
        Acro = 21,
        Claustro = 22,
        Pyro = 23,

        // MoneyWrench? = 77? Idk i got it after buying shuriken in the archipelago and that had moneywrench
        // Jukebox = 73
    }
}
