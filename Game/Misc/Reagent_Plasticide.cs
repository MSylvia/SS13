// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Plasticide : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Plasticide";
			this.id = "plasticide";
			this.description = "Liquid plastic, do not eat.";
			this.reagent_state = 2;
			this.color = "#CF3600";
			this.custom_metabolism = 0.01;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.adjustToxLoss( 0.2 );
			return false;
		}

	}

}