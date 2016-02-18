// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Haloperidol : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Haloperidol";
			this.id = "haloperidol";
			this.description = "Increases depletion rates for most stimulating/hallucinogenic drugs. Reduces druggy effects and jitteriness. Severe stamina regeneration penalty, causes drowsiness. Small chance of brain damage.";
			this.color = "#27870a";
			this.metabolization_rate = 0.16;
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			Reagent_Drug R = null;

			
			foreach (dynamic _a in Lang13.Enumerate( M.reagents.reagent_list, typeof(Reagent_Drug) )) {
				R = _a;
				
				((Reagents)M.reagents).remove_reagent( R.id, 5 );
			}
			M.drowsyness += 2;

			if ( M.jitteriness >= 3 ) {
				M.jitteriness -= 3;
			}

			if ( M.hallucination >= 5 ) {
				M.hallucination -= 5;
			}

			if ( Rand13.PercentChance( 20 ) ) {
				((Mob_Living)M).adjustBrainLoss( 1 );
			}
			((Mob_Living)M).adjustStaminaLoss( 2.5 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}