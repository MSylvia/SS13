// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Armor_Hos : Obj_Item_Clothing_Suit_Armor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "greatcoat";
			this.body_parts_covered = 414;
			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 30 ).Set( "laser", 30 ).Set( "energy", 10 ).Set( "bomb", 25 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.flags_inv = 4;
			this.cold_protection = 414;
			this.heat_protection = 414;
			this.strip_delay = 80;
			this.icon_state = "hos";
		}

		public Obj_Item_Clothing_Suit_Armor_Hos ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}