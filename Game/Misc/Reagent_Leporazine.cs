// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Leporazine : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Leporazine";
			this.id = "leporazine";
			this.description = "Leporazine can be use to stabilize an individuals body temperature.";
			this.reagent_state = 2;
			this.color = "#C8A5DC";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}

			if ( Convert.ToDouble( M.bodytemperature ) > 310 ) {
				M.bodytemperature = Num13.MaxInt( 310, Convert.ToInt32( M.bodytemperature - 60 ) );
			} else if ( Convert.ToDouble( M.bodytemperature ) < 311 ) {
				M.bodytemperature = Num13.MinInt( 310, Convert.ToInt32( M.bodytemperature + 60 ) );
			}
			return false;
		}

	}

}