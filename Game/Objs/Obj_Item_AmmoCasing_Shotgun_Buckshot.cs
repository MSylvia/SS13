// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Shotgun_Buckshot : Obj_Item_AmmoCasing_Shotgun {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Bullet_Pellet);
			this.pellets = 6;
			this.variance = 0.8;
			this.icon_state = "gshell";
		}

		public Obj_Item_AmmoCasing_Shotgun_Buckshot ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}