// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Magic_Wand_Resurrection : Obj_Item_Weapon_Gun_Magic_Wand {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_Magic_Heal);
			this.fire_sound = "sound/magic/Staff_Healing.ogg";
			this.max_charges = 10;
			this.icon_state = "revivewand";
		}

		public Obj_Item_Weapon_Gun_Magic_Wand_Resurrection ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wand.dm
		public override void zap_self( dynamic user = null ) {
			user.revive();
			user.WriteMsg( "<span class='notice'>You feel great!</span>" );
			this.charges--;
			base.zap_self( (object)(user) );
			return;
		}

	}

}