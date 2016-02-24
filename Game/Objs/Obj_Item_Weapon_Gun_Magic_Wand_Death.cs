// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Magic_Wand_Death : Obj_Item_Weapon_Gun_Magic_Wand {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.fire_sound = "sound/magic/WandoDeath.ogg";
			this.ammo_type = typeof(Obj_Item_AmmoCasing_Magic_Death);
			this.max_charges = 3;
			this.icon_state = "deathwand";
		}

		public Obj_Item_Weapon_Gun_Magic_Wand_Death ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wand.dm
		public override void zap_self( dynamic user = null ) {
			string message = null;

			message = "<span class='warning'>You irradiate yourself with pure energy! ";
			message += Rand13.Pick(new object [] { "Do not pass go. Do not collect 200 zorkmids.</span>", "You feel more confident in your spell casting skills.</span>", "You Die...</span>", "Do you want your possessions identified?</span>" });
			user.WriteMsg( message );
			((Mob_Living)user).adjustOxyLoss( 500 );
			this.charges--;
			base.zap_self( (object)(user) );
			return;
		}

	}

}