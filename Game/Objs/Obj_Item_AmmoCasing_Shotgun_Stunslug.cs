// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Shotgun_Stunslug : Obj_Item_AmmoCasing_Shotgun {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Bullet_Stunshot);
			this.materials = new ByTable().Set( "$metal", 250 );
			this.icon_state = "stunshell";
		}

		public Obj_Item_AmmoCasing_Shotgun_Stunslug ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}