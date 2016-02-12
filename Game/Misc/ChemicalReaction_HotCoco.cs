// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_HotCoco : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hot Coco";
			this.id = "hot_coco";
			this.result = "hot_coco";
			this.required_reagents = new ByTable().Set( "water", 5 ).Set( "coco", 1 );
			this.result_amount = 5;
		}

	}

}