// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Shotgun_Pulseslug : Obj_Item_AmmoCasing_Shotgun {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Beam_Pulse_Shot);
			this.icon_state = "pshell";
		}

		public Obj_Item_AmmoCasing_Shotgun_Pulseslug ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}