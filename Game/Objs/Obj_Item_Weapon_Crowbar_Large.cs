// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Crowbar_Large : Obj_Item_Weapon_Crowbar {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 12;
			this.throw_speed = 3;
			this.throw_range = 3;
			this.materials = new ByTable().Set( "$metal", 70 );
			this.toolspeed = 2;
			this.icon_state = "crowbar_large";
		}

		public Obj_Item_Weapon_Crowbar_Large ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}