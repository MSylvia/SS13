// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Galoshes_Dry : Obj_Item_Clothing_Shoes_Galoshes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "galoshes_dry";
		}

		public Obj_Item_Clothing_Shoes_Galoshes_Dry ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: miscellaneous.dm
		public override void step_action(  ) {
			dynamic t_loc = null;

			t_loc = GlobalFuncs.get_turf( this );

			if ( t_loc is Tile_Simulated && Lang13.Bool( t_loc.wet ) ) {
				((Tile_Simulated)t_loc).MakeDry( 1 );
			}
			return;
		}

	}

}