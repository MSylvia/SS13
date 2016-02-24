// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "s_suit";
			this.w_class = 4;
			this.gas_transfer_coefficient = 0.01;
			this.permeability_coefficient = 0.11;
			this.flags = 8193;
			this.body_parts_covered = 2046;
			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item_Device_Flashlight), typeof(Obj_Item_Weapon_Tank_Internals) });
			this.slowdown = 1;
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 100 ).Set( "rad", 50 );
			this.flags_inv = 13;
			this.cold_protection = 2046;
			this.min_cold_protection_temperature = 2;
			this.heat_protection = 2046;
			this.max_heat_protection_temperature = 1500;
			this.strip_delay = 80;
			this.put_on_delay = 80;
			this.icon_state = "spaceold";
		}

		public Obj_Item_Clothing_Suit_Space ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}