// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Cultrobes : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cultrobes";
			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item_Weapon_Tome), typeof(Obj_Item_Weapon_Melee_Cultblade) });
			this.armor = new ByTable().Set( "melee", 50 ).Set( "bullet", 30 ).Set( "laser", 50 ).Set( "energy", 20 ).Set( "bomb", 25 ).Set( "bio", 10 ).Set( "rad", 0 );
			this.icon_state = "cultrobes";
		}

		public Obj_Item_Clothing_Suit_Cultrobes ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cult_items.dm
		public override dynamic cultify(  ) {
			return null;
		}

	}

}