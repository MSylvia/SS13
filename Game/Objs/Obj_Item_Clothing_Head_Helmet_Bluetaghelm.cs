// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Bluetaghelm : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bluetaghelm";
			this.armor = new ByTable().Set( "melee", 15 ).Set( "bullet", 10 ).Set( "laser", 20 ).Set( "energy", 10 ).Set( "bomb", 20 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.icon_state = "bluetaghelm";
		}

		public Obj_Item_Clothing_Head_Helmet_Bluetaghelm ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}