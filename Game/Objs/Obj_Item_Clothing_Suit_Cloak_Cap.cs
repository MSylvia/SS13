// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Cloak_Cap : Obj_Item_Clothing_Suit_Cloak {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 30 ).Set( "laser", 30 ).Set( "energy", 10 ).Set( "bomb", 25 ).Set( "bio", 10 ).Set( "rad", 10 );
			this.icon_state = "capcloak";
		}

		public Obj_Item_Clothing_Suit_Cloak_Cap ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}