// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_SpaceNinja : Obj_Item_Clothing_Head_Helmet_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "s-ninja_mask";
			this.armor = new ByTable().Set( "melee", 60 ).Set( "bullet", 50 ).Set( "laser", 30 ).Set( "energy", 15 ).Set( "bomb", 30 ).Set( "bio", 30 ).Set( "rad", 25 );
			this.strip_delay = 12;
			this.unacidable = true;
			this.blockTracking = true;
			this.icon_state = "s-ninja";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_SpaceNinja ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}