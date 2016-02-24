// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine_Uzim9mm : Obj_Item_AmmoBox_Magazine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_C9mm);
			this.caliber = "9mm";
			this.max_ammo = 32;
			this.icon_state = "uzi9mm-32";
		}

		public Obj_Item_AmmoBox_Magazine_Uzim9mm ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: magazines.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			this.icon_state = "uzi9mm-" + Num13.Round( this.ammo_count(), 4 );
			return false;
		}

	}

}