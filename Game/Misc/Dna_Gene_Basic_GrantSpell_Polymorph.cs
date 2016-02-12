// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Basic_GrantSpell_Polymorph : Dna_Gene_Basic_GrantSpell {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Polymorphism";
			this.desc = "Enables the subject to reconfigure their appearance to mimic that of others.";
			this.spelltype = typeof(Spell_Targeted_Polymorph);
			this.activation_messages = new ByTable(new object [] { "You don't feel entirely like yourself somehow." });
			this.deactivation_messages = new ByTable(new object [] { "You feel secure in your identity." });
			this.drug_activation_messages = new ByTable();
			this.drug_deactivation_messages = new ByTable();
		}

		// Function from file: goon_powers.dm
		public Dna_Gene_Basic_GrantSpell_Polymorph (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.block = GlobalVars.POLYMORPHBLOCK;
			return;
		}

	}

}