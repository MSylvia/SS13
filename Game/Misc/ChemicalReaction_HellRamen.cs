// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_HellRamen : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hell Ramen";
			this.id = "hell_ramen";
			this.result = "hell_ramen";
			this.required_reagents = new ByTable().Set( "capsaicin", 1 ).Set( "hot_ramen", 6 );
			this.result_amount = 6;
		}

	}

}