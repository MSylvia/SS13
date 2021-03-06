// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Synthflesh : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Synthflesh";
			this.id = "synthflesh";
			this.result = "synthflesh";
			this.required_reagents = new ByTable().Set( "blood", 1 ).Set( "carbon", 1 ).Set( "styptic_powder", 1 );
			this.result_amount = 3;
		}

	}

}