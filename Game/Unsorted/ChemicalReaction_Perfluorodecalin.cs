// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Perfluorodecalin : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Perfluorodecalin";
			this.id = "perfluorodecalin";
			this.result = "perfluorodecalin";
			this.required_reagents = new ByTable().Set( "hydrogen", 1 ).Set( "fluorine", 1 ).Set( "oil", 1 );
			this.result_amount = 3;
			this.required_temp = 370;
			this.mix_message = "The mixture rapidly turns into a dense pink liquid.";
		}

	}

}