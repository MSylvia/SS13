// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Pirate : Obj_Item_Clothing_Suit_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "pirate";
			this.flags_inv = 0;
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Gun), 
				typeof(Obj_Item_AmmoBox), 
				typeof(Obj_Item_AmmoCasing), 
				typeof(Obj_Item_Weapon_Melee_Baton), 
				typeof(Obj_Item_Weapon_Restraints_Handcuffs), 
				typeof(Obj_Item_Weapon_Tank_Internals), 
				typeof(Obj_Item_Weapon_Melee_Energy_Sword_Pirate), 
				typeof(Obj_Item_Clothing_Glasses_Eyepatch), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Rum)
			 });
			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 50 ).Set( "laser", 30 ).Set( "energy", 15 ).Set( "bomb", 30 ).Set( "bio", 30 ).Set( "rad", 30 );
			this.icon_state = "pirate";
		}

		public Obj_Item_Clothing_Suit_Space_Pirate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}