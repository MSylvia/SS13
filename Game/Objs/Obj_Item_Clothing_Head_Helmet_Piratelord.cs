// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Piratelord : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 75 ).Set( "bullet", 75 ).Set( "laser", 75 ).Set( "energy", 75 ).Set( "bomb", 75 ).Set( "bio", 100 ).Set( "rad", 90 );
			this.icon_state = "piratelord";
		}

		public Obj_Item_Clothing_Head_Helmet_Piratelord ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}