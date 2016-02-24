// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_Emplosion_DisableTech : Obj_Effect_ProcHolder_Spell_Targeted_Emplosion {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.charge_max = 400;
			this.invocation = "NEC CANTIO";
			this.invocation_type = "shout";
			this.range = -1;
			this.include_user = true;
			this.cooldown_min = 200;
			this.emp_heavy = 6;
			this.emp_light = 10;
			this.sound = "sound/magic/Disable_Tech.ogg";
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_Emplosion_DisableTech ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}