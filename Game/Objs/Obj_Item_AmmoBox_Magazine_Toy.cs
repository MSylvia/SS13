// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine_Toy : Obj_Item_AmmoBox_Magazine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_Caseless_FoamDart);
			this.caliber = "foam_force";
		}

		public Obj_Item_AmmoBox_Magazine_Toy ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}