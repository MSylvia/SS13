// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Jacket_Puffer : Obj_Item_Clothing_Suit_Jacket {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "hostrench";
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 50 ).Set( "rad", 0 );
			this.icon_state = "pufferjacket";
		}

		public Obj_Item_Clothing_Suit_Jacket_Puffer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}