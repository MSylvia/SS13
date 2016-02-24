// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Shadowling : Obj_Item_Clothing_Suit_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.body_parts_covered = 2047;
			this.cold_protection = 2047;
			this.unacidable = true;
			this.armor = new ByTable().Set( "melee", 25 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 25 ).Set( "bio", 100 ).Set( "rad", 100 );
			this.flags = 8322;
			this.icon_state = "shadowling";
		}

		public Obj_Item_Clothing_Suit_Space_Shadowling ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}