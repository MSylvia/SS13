// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Hooded_CarpCostume : Obj_Item_Clothing_Suit_Hooded {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "labcoat";
			this.body_parts_covered = 390;
			this.cold_protection = 390;
			this.min_cold_protection_temperature = 60;
			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item_Weapon_Tank_Internals_EmergencyOxygen), typeof(Obj_Item_Weapon_Gun_Projectile_Automatic_Speargun) });
			this.hooded = true;
			this.action_button_name = "Toggle Carp Hood";
			this.hoodtype = typeof(Obj_Item_Clothing_Head_CarpHood);
			this.icon_state = "carp_casual";
		}

		public Obj_Item_Clothing_Suit_Hooded_CarpCostume ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}