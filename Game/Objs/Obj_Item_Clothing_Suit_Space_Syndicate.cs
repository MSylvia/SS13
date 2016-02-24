// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Syndicate : Obj_Item_Clothing_Suit_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "space_suit_syndicate";
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Gun), 
				typeof(Obj_Item_AmmoBox), 
				typeof(Obj_Item_AmmoCasing), 
				typeof(Obj_Item_Weapon_Melee_Baton), 
				typeof(Obj_Item_Weapon_Melee_Energy_Sword_Saber), 
				typeof(Obj_Item_Weapon_Restraints_Handcuffs), 
				typeof(Obj_Item_Weapon_Tank_Internals)
			 });
			this.armor = new ByTable().Set( "melee", 40 ).Set( "bullet", 50 ).Set( "laser", 30 ).Set( "energy", 15 ).Set( "bomb", 30 ).Set( "bio", 30 ).Set( "rad", 30 );
			this.icon_state = "syndicate";
		}

		public Obj_Item_Clothing_Suit_Space_Syndicate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}