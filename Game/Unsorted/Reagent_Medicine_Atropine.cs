// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Atropine : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Atropine";
			this.id = "atropine";
			this.description = "If a patient is in critical condition, rapidly heals all damage types as well as regulating oxygen in the body. Excellent for stabilizing wounded patients.";
			this.color = "#C8A5DC";
			this.metabolization_rate = 0.1;
			this.overdose_threshold = 35;
		}

		// Function from file: medicine_reagents.dm
		public override void overdose_process( dynamic M = null ) {
			((Mob_Living)M).adjustToxLoss( 0.5 );
			((Mob)M).Dizzy( 1 );
			((Mob)M).Jitter( 1 );
			base.overdose_process( (object)(M) );
			return;
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( Convert.ToDouble( M.health ) < 0 ) {
				((Mob_Living)M).adjustToxLoss( -2 );
				((Mob_Living)M).adjustBruteLoss( -2 );
				((Mob_Living)M).adjustFireLoss( -2 );
				((Mob_Living)M).adjustOxyLoss( -5 );
			}
			M.losebreath = 0;

			if ( Rand13.PercentChance( 20 ) ) {
				((Mob)M).Dizzy( 5 );
				((Mob)M).Jitter( 5 );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}