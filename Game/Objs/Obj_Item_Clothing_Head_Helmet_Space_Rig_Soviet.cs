// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Rig_Soviet : Obj_Item_Clothing_Head_Helmet_Space_Rig {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "rig0-soviet";
			this.species_restricted = new ByTable(new object [] { "exclude", "Vox" });
			this.armor = new ByTable().Set( "melee", 40 ).Set( "bullet", 30 ).Set( "laser", 30 ).Set( "energy", 15 ).Set( "bomb", 35 ).Set( "bio", 100 ).Set( "rad", 20 );
			this._color = "soviet";
			this.pressure_resistance = 4053;
			this.icon_state = "rig0-soviet";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Rig_Soviet ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}