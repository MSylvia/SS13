// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Magic_Wand_Polymorph : Obj_Item_Weapon_Gun_Magic_Wand {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_Magic_Change);
			this.fire_sound = "sound/magic/Staff_Change.ogg";
			this.max_charges = 10;
			this.icon_state = "polywand";
		}

		public Obj_Item_Weapon_Gun_Magic_Wand_Polymorph ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wand.dm
		public override void zap_self( dynamic user = null ) {
			base.zap_self( (object)(user) );
			GlobalFuncs.wabbajack( user );
			this.charges--;
			return;
		}

	}

}