// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_BioHood_Security : Obj_Item_Clothing_Head_BioHood {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 25 ).Set( "bullet", 15 ).Set( "laser", 25 ).Set( "energy", 10 ).Set( "bomb", 25 ).Set( "bio", 100 ).Set( "rad", 20 );
			this.icon_state = "bio_security";
		}

		public Obj_Item_Clothing_Head_BioHood_Security ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}