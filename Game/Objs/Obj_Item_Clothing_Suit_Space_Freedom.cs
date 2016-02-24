// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Freedom : Obj_Item_Clothing_Suit_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "freedom";
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Gun), 
				typeof(Obj_Item_AmmoBox), 
				typeof(Obj_Item_AmmoCasing), 
				typeof(Obj_Item_Weapon_Melee_Baton), 
				typeof(Obj_Item_Weapon_Restraints_Handcuffs), 
				typeof(Obj_Item_Weapon_Tank_Internals)
			 });
			this.armor = new ByTable().Set( "melee", 20 ).Set( "bullet", 40 ).Set( "laser", 30 ).Set( "energy", 25 ).Set( "bomb", 100 ).Set( "bio", 100 ).Set( "rad", 100 );
			this.strip_delay = 130;
			this.max_heat_protection_temperature = 35000;
			this.unacidable = true;
			this.icon_state = "freedom";
		}

		public Obj_Item_Clothing_Suit_Space_Freedom ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}