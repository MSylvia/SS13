// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_Shuttle_Smooth_Overblue : Tile_Simulated_Wall_Shuttle_Smooth {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.fixed_underlay = new ByTable().Set( "icon", "icons/turf/floors.dmi" ).Set( "icon_state", "shuttlefloor" );
			this.icon_state = "overblue";
		}

		public Tile_Simulated_Wall_Shuttle_Smooth_Overblue ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}