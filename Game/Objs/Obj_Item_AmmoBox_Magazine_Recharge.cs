// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine_Recharge : Obj_Item_AmmoBox_Magazine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_Caseless_Laser);
			this.caliber = "laser";
			this.max_ammo = 20;
			this.icon_state = "oldrifle-20";
		}

		public Obj_Item_AmmoBox_Magazine_Recharge ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: rechargable_magazine.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			return null;
		}

		// Function from file: rechargable_magazine.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.desc = new Txt().item( Lang13.Initial( this, "desc" ) ).str( " It has " ).item( this.stored_ammo.len ).str( " shots" ).s().str( " left." ).ToString();
			this.icon_state = "oldrifle-" + Num13.Round( this.ammo_count(), 4 );
			return false;
		}

	}

}