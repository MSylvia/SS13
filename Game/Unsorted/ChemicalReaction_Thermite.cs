// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Thermite : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Thermite";
			this.id = "thermite";
			this.result = "thermite";
			this.required_reagents = new ByTable().Set( "aluminium", 1 ).Set( "iron", 1 ).Set( "oxygen", 1 );
			this.result_amount = 3;
		}

	}

}