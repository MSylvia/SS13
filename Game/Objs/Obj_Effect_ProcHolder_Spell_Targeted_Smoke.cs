// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_Smoke : Obj_Effect_ProcHolder_Spell_Targeted {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.school = "conjuration";
			this.charge_max = 120;
			this.clothes_req = 0;
			this.invocation = "none";
			this.range = -1;
			this.include_user = true;
			this.cooldown_min = 20;
			this.smoke_spread = 2;
			this.smoke_amt = 4;
			this.action_icon_state = "smoke";
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_Smoke ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}