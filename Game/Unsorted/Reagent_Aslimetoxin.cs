// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Aslimetoxin : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Advanced Mutation Toxin";
			this.id = "amutationtoxin";
			this.description = "An advanced corruptive toxin produced by slimes.";
			this.color = "#13BC5E";
		}

		// Function from file: other_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			
			if ( method != GlobalVars.TOUCH ) {
				((Mob)M).ForceContractDisease( new Disease_Transformation_Slime( /* Pruned args, no ctor exists. */ ) );
			}
			return 0;
		}

	}

}