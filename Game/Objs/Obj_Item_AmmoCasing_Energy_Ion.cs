// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Energy_Ion : Obj_Item_AmmoCasing_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Ion);
			this.select_name = "ion";
			this.fire_sound = "sound/weapons/IonRifle.ogg";
		}

		public Obj_Item_AmmoCasing_Energy_Ion ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}