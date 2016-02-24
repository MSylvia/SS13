// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Magic_Wand_Fireball : Obj_Item_Weapon_Gun_Magic_Wand {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.fire_sound = "sound/magic/Fireball.ogg";
			this.ammo_type = typeof(Obj_Item_AmmoCasing_Magic_Fireball);
			this.max_charges = 8;
			this.icon_state = "firewand";
		}

		public Obj_Item_Weapon_Gun_Magic_Wand_Fireball ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wand.dm
		public override void zap_self( dynamic user = null ) {
			GlobalFuncs.explosion( user.loc, -1, 0, 2, 3, 0, null, 2 );
			this.charges--;
			base.zap_self( (object)(user) );
			return;
		}

	}

}