using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinorSpellFixes
{
    class ClassSpellListFixes
    {

        internal static void Load()
        {
            fixSorcererSpellList();
        }

        static internal void fixSorcererSpellList()
        {
            var enhanceAbility = SolastaModApi.DatabaseHelper.SpellDefinitions.EnhanceAbility;
            var insectPlague = SolastaModApi.DatabaseHelper.SpellDefinitions.InsectPlague;
            var sorcererSpellList = SolastaModApi.DatabaseHelper.SpellListDefinitions.SpellListSorcerer;

            addSpellToSpelllist(sorcererSpellList, enhanceAbility);
            addSpellToSpelllist(sorcererSpellList, insectPlague);
        }

        static public void addSpellToSpelllist(SpellListDefinition spelllist, SpellDefinition spell)
        {
            if (spell.SpellLevel == 0 && !spelllist.HasCantrips)
            {
                throw new System.Exception($"Trying to add cantrip {spell.name} to spell list without cantrips {spelllist.name}");
            }

            if (spelllist.ContainsSpell(spell))
            {
                throw new System.Exception($"Spelllist {spelllist.name} already contains spell {spell}");
            }


            if (spelllist.HasCantrips)
            {
                spelllist.SpellsByLevel[spell.SpellLevel].Spells.Add(spell);
            }
            else
            {
                spelllist.SpellsByLevel[spell.SpellLevel - 1].Spells.Add(spell);
            }
        }

    }
}
