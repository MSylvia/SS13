// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Storage_Labcoat_Oncologist : Obj_Item_Clothing_Suit_Storage_Labcoat {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_icon_state = "labcoat_onc";
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 60 );
			this.species_fit = new ByTable(new object [] { "Vox" });
		}

		public Obj_Item_Clothing_Suit_Storage_Labcoat_Oncologist ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}