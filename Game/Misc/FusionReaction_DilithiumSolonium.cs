// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class FusionReaction_DilithiumSolonium : FusionReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.primary_reactant = "Dilithium";
			this.secondary_reactant = "Solonium";
			this.energy_consumption = 1;
			this.energy_production = 1;
			this.radiation = 3;
			this.products = new ByTable().Set( "Tritium", 1 ).Set( "Dilithium", 1 );
		}

	}

}