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
