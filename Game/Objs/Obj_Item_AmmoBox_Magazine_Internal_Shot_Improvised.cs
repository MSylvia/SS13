// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine_Internal_Shot_Improvised : Obj_Item_AmmoBox_Magazine_Internal_Shot {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_Shotgun_Improvised);
			this.max_ammo = 1;
		}

		public Obj_Item_AmmoBox_Magazine_Internal_Shot_Improvised ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}