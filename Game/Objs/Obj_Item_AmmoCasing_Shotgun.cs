// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Shotgun : Obj_Item_AmmoCasing {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.caliber = "shotgun";
			this.projectile_type = typeof(Obj_Item_Projectile_Bullet);
			this.materials = new ByTable().Set( "$metal", 4000 );
			this.icon_state = "blshell";
		}

		public Obj_Item_AmmoCasing_Shotgun ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}