// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_AoeTurf_Conjure_Carp : Spell_AoeTurf_Conjure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Summon Carp";
			this.desc = "This spell conjures a simple carp.";
			this.charge_max = 1200;
			this.invocation = "NOUK FHUNMM SACP RISSKA";
			this.invocation_type = "shout";
			this.range = 1;
			this.summon_type = new ByTable(new object [] { typeof(Mob_Living_SimpleAnimal_Hostile_Carp) });
			this.hud_state = "wiz_carp";
		}

	}

}