// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Surgery_TailAttachment : Surgery {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "tail attachment";
			this.steps = new ByTable(new object [] { 
				typeof(SurgeryStep_Incise), 
				typeof(SurgeryStep_ClampBleeders), 
				typeof(SurgeryStep_RetractSkin), 
				typeof(SurgeryStep_Replace), 
				typeof(SurgeryStep_AttachTail), 
				typeof(SurgeryStep_Close)
			 });
			this.species = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human) });
			this.possible_locs = new ByTable(new object [] { "groin" });
		}

		// Function from file: tail_modification.dm
		public override bool can_start( dynamic user = null, dynamic target = null ) {
			dynamic L = null;

			L = target;

			if ( !L.dna.species.mutant_bodyparts.Contains( "tail_lizard" ) && !L.dna.species.mutant_bodyparts.Contains( "waggingtail_lizard" ) ) {
				return true;
			}
			return false;
		}

	}

}