// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Syndicate_Tacticool : Obj_Item_Clothing_Under_Syndicate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_color = "tactifool";
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.icon_state = "tactifool";
		}

		public Obj_Item_Clothing_Under_Syndicate_Tacticool ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}