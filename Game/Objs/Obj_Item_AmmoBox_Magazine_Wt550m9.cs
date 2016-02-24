// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine_Wt550m9 : Obj_Item_AmmoBox_Magazine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_C46x30mm);
			this.caliber = "4.6x30mm";
			this.max_ammo = 20;
			this.icon_state = "46x30mmt-20";
		}

		public Obj_Item_AmmoBox_Magazine_Wt550m9 ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: magazines.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			this.icon_state = "46x30mmt-" + Num13.Round( this.ammo_count(), 4 );
			return false;
		}

	}

}