// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Eva : Obj_Item_Clothing_Suit_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 100 ).Set( "rad", 20 );
			this.icon_state = "space";
		}

		public Obj_Item_Clothing_Suit_Space_Eva ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}