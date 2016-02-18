// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Salbutamol : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Salbutamol";
			this.id = "salbutamol";
			this.description = "Rapidly restores oxygen deprivation as well as preventing more of it to an extent.";
			this.color = "#C8A5DC";
			this.metabolization_rate = 0.1;
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			((Mob_Living)M).adjustOxyLoss( -3 );

			if ( M.losebreath >= 4 ) {
				M.losebreath -= 2;
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}