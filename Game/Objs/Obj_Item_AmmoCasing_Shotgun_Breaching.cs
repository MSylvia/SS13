// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Shotgun_Breaching : Obj_Item_AmmoCasing_Shotgun {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Bullet_Meteorshot_Weak);
			this.icon_state = "mshell";
		}

		public Obj_Item_AmmoCasing_Shotgun_Breaching ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}