// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Impedrezene : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Impedrezene";
			this.id = "impedrezene";
			this.result = "impedrezene";
			this.required_reagents = new ByTable().Set( "mercury", 1 ).Set( "oxygen", 1 ).Set( "sugar", 1 );
			this.result_amount = 2;
		}

	}

}