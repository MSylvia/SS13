// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_A762 : Obj_Item_AmmoCasing {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.caliber = "a762";
			this.projectile_type = typeof(Obj_Item_Projectile_Bullet);
			this.icon_state = "762-casing";
		}

		public Obj_Item_AmmoCasing_A762 ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}