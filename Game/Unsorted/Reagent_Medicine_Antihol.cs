// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Antihol : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Antihol";
			this.id = "antihol";
			this.description = "Purges alcoholic substance from the patient's body and eliminates its side effects.";
			this.color = "#C8A5DC";
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			M.dizziness = 0;
			M.drowsyness = 0;
			M.slurring = 0;
			M.confused = 0;
			((Reagents)M.reagents).remove_all_type( typeof(Reagent_Consumable_Ethanol), 3, false, true );
			((Mob_Living)M).adjustToxLoss( -0.2 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}