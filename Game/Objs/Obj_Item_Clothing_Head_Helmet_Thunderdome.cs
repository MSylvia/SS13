// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Thunderdome : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "thunderdome";
			this.armor = new ByTable().Set( "melee", 40 ).Set( "bullet", 30 ).Set( "laser", 25 ).Set( "energy", 10 ).Set( "bomb", 25 ).Set( "bio", 10 ).Set( "rad", 0 );
			this.min_cold_protection_temperature = 2;
			this.max_heat_protection_temperature = 1500;
			this.strip_delay = 80;
			this.icon_state = "thunderdome";
		}

		public Obj_Item_Clothing_Head_Helmet_Thunderdome ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}