// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Paismoke : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Smoke";
			this.id = "paismoke";
			this.description = "A chemical smoke synthesized by personal AIs.";
			this.reagent_state = 3;
			this.color = "#FFFFFF";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			((Reagents)M.reagents).del_reagent( this.id );
			((Reagents)M.reagents).add_reagent( "potassium", 5 );
			((Reagents)M.reagents).add_reagent( "sugar", 5 );
			((Reagents)M.reagents).add_reagent( "phosphorus", 5 );
			return false;
		}

	}

}