// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Energy_Disabler : Obj_Item_AmmoCasing_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Beam_Disabler);
			this.select_name = "disable";
			this.e_cost = 50;
			this.fire_sound = "sound/weapons/taser2.ogg";
		}

		public Obj_Item_AmmoCasing_Energy_Disabler ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}