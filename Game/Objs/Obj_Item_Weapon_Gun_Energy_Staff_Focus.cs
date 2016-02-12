// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Staff_Focus : Obj_Item_Weapon_Gun_Energy_Staff {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "focus";
			this.projectile_type = "/obj/item/projectile/forcebolt";
			this.icon = "icons/obj/wizard.dmi";
			this.icon_state = "focus";
		}

		public Obj_Item_Weapon_Gun_Energy_Staff_Focus ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: special.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.projectile_type == "/obj/item/projectile/forcebolt" ) {
				this.charge_cost = 250;
				GlobalFuncs.to_chat( user, "<span class='warning'>The " + this.name + " will now strike a small area.</span>" );
				this.projectile_type = "/obj/item/projectile/forcebolt/strong";
			} else {
				this.charge_cost = 100;
				GlobalFuncs.to_chat( user, "<span class='warning'>The " + this.name + " will now strike only a single person.</span>" );
				this.projectile_type = "/obj/item/projectile/forcebolt";
			}
			return null;
		}

	}

}