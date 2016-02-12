// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Paint : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Paint";
			this.id = "paint_";
			this.description = "Floor paint is used to color floor tiles.";
			this.reagent_state = 2;
			this.color = "#808080";
		}

		// Function from file: paint.dm
		public override bool reaction_turf( dynamic T = null, double volume = 0 ) {
			string ind = null;
			Icon overlay = null;

			
			if ( !( T is Tile ) || T is Tile_Space ) {
				return false;
			}
			ind = "" + Lang13.Initial( T, "icon" ) + this.color;

			if ( !Lang13.Bool( GlobalVars.cached_icons[ind] ) ) {
				overlay = new Icon( Lang13.Initial( T, "icon" ) );
				overlay.Blend( this.color, 2 );
				overlay.SetIntensity( 131 );
				T.icon = overlay;
				GlobalVars.cached_icons[ind] = T.icon;
			} else {
				T.icon = GlobalVars.cached_icons[ind];
			}
			return false;
		}

	}

}