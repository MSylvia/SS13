// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Energy : Obj_Item_Projectile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 0;
			this.damage_type = "fire";
			this.flag = "energy";
			this.icon_state = "spark";
		}

		public Obj_Item_Projectile_Energy ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}