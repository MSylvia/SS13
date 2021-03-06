// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Swat : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "swatsyndie";
			this.armor = new ByTable().Set( "melee", 40 ).Set( "bullet", 30 ).Set( "laser", 30 ).Set( "energy", 30 ).Set( "bomb", 50 ).Set( "bio", 90 ).Set( "rad", 20 );
			this.min_cold_protection_temperature = 2;
			this.max_heat_protection_temperature = 1500;
			this.flags = 1;
			this.strip_delay = 80;
			this.icon_state = "swatsyndie";
		}

		public Obj_Item_Clothing_Head_Helmet_Swat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}