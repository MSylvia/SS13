// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Beret_Sec : Obj_Item_Clothing_Head_Beret {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 25 ).Set( "laser", 25 ).Set( "energy", 10 ).Set( "bomb", 25 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.strip_delay = 60;
			this.icon_state = "beret_badge";
		}

		public Obj_Item_Clothing_Head_Beret_Sec ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}