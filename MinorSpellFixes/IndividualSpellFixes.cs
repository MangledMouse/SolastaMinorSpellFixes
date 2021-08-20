using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinorSpellFixes
{
    class IndividualSpellFixes
    {
        internal static void Load()
        {
            FixCharmPerson();
            FixBlackTentacles();
        }

        //Tabeltop Adventures implemenation of Blacktentacles deviates from the tabletop in the following ways:
        //It uses a strength Save instead of Dex
        //It uses a DC check to break out instead of spell save dc
        //It uses Athletics or Acrobatics check instead of straight Str/Dex
        //Easy enough to fix the save issue (done)
        
        //The Action granted to players is called Break Free and it lets them use their action to make a Athletics or Acrobatics save to end the restrained condition.
        //I can't seem to find where the breakFreeModes get defined, where the DC gets defined or where what goes into the breakFreeModes is defined
        //The BreakFreeModes each have text associated with them that I'd like to change as well but that is a lower priority issue to fix
        private static void FixBlackTentacles()
        {
            SpellDefinition blackTentacles = SolastaModApi.DatabaseHelper.SpellDefinitions.BlackTentacles;
            blackTentacles.EffectDescription.SavingThrowAbility = "Dexterity";
            //FeatureDefinitionActionAffinity actionAffinityBlackTentacles = SolastaModApi.DatabaseHelper.FeatureDefinitionActionAffinitys.ActionAffinityBlackTentacles;
            //ActionDefinition breakFree = SolastaModApi.DatabaseHelper.ActionDefinitions.BreakFree;
            //var x = 2;
        }

        private static void FixCharmPerson()
        {
            CreateConditionAffinity();
        }

        //Gives the save against being charmed disadvantage when surprised. This works to make Charm Person not grant advantage on the save when a creature is surprised to match the lack of advantage
        //On the save in tabletop outside of combat
        private static void CreateConditionAffinity()
        {
            ConditionDefinition ConditionSurprised = SolastaModApi.DatabaseHelper.ConditionDefinitions.ConditionSurprised;
            FeatureDefinitionConditionAffinity ConditionCharmedDisadvantage = new FeatureDefinitionConditionAffinity();
            var affinity_charmed = SolastaModHelpers.Helpers.ConditionAffinityBuilder.createConditionAffinity("CharmedSaveDisadvantageWhenSurprised",
                                                                                           "799da073-94cf-475a-9be1-9038b2f4f597",
                                                                                           "",
                                                                                           "",
                                                                                           null,
                                                                                           SolastaModHelpers.Helpers.Conditions.Charmed,
                                                                                           RuleDefinitions.ConditionAffinityType.None,
                                                                                           RuleDefinitions.AdvantageType.Disadvantage,
                                                                                           RuleDefinitions.AdvantageType.None
                                                                                           );
            ConditionSurprised.Features.Add(affinity_charmed);
        }


    }
}
