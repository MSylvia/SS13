// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_TurfTeleport_Blink : Obj_Effect_ProcHolder_Spell_Targeted_TurfTeleport {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.school = "abjuration";
			this.charge_max = 20;
			this.invocation = "none";
			this.range = -1;
			this.include_user = true;
			this.cooldown_min = 5;
			this.smoke_spread = 1;
			this.inner_tele_radius = false;
			this.outer_tele_radius = 6;
			this.centcom_cancast = false;
			this.action_icon_state = "blink";
			this.sound1 = "sound/magic/blink.ogg";
			this.sound2 = "sound/magic/blink.ogg";
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_TurfTeleport_Blink ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}