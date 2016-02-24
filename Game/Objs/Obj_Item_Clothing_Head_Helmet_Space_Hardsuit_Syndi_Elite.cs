// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Syndi_Elite : Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Syndi {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.alt_desc = "An elite version of the syndicate helmet, with improved armour and fire shielding. It is in combat mode. Property of Gorlex Marauders.";
			this.item_color = "syndielite";
			this.armor = new ByTable().Set( "melee", 60 ).Set( "bullet", 60 ).Set( "laser", 50 ).Set( "energy", 25 ).Set( "bomb", 55 ).Set( "bio", 100 ).Set( "rad", 70 );
			this.max_heat_protection_temperature = 35000;
			this.icon_state = "hardsuit0-syndielite";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Syndi_Elite ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}