// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Cultrobes : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cultrobes";
			this.body_parts_covered = 414;
			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item_Weapon_Tome), typeof(Obj_Item_Weapon_Melee_Cultblade) });
			this.armor = new ByTable().Set( "melee", 50 ).Set( "bullet", 30 ).Set( "laser", 50 ).Set( "energy", 20 ).Set( "bomb", 25 ).Set( "bio", 10 ).Set( "rad", 0 );
			this.flags_inv = 4;
			this.cold_protection = 414;
			this.min_cold_protection_temperature = 160;
			this.heat_protection = 414;
			this.max_heat_protection_temperature = 600;
			this.icon_state = "cultrobes";
		}

		public Obj_Item_Clothing_Suit_Cultrobes ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}