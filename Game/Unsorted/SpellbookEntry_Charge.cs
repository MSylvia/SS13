// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpellbookEntry_Charge : SpellbookEntry {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Charge";
			this.spell_type = typeof(Obj_Effect_ProcHolder_Spell_Targeted_Charge);
			this.log_name = "CH";
			this.category = "Assistance";
			this.cost = 1;
		}

	}

}