// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_HotCoco : Reagent_Consumable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hot Chocolate";
			this.id = "hot_coco";
			this.description = "Made with love! And coco beans.";
			this.nutriment_factor = 1.2;
			this.color = "#403010";
		}

		// Function from file: food_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( Convert.ToDouble( M.bodytemperature ) < 310 ) {
				M.bodytemperature = Num13.MinInt( 310, Convert.ToInt32( M.bodytemperature + 7.5 ) );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}