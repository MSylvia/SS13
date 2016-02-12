// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_AntiToxin : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Anti-Toxin (Dylovene)";
			this.id = "anti_toxin";
			this.result = "anti_toxin";
			this.required_reagents = new ByTable().Set( "silicon", 1 ).Set( "potassium", 1 ).Set( "nitrogen", 1 );
			this.result_amount = 3;
		}

	}

}