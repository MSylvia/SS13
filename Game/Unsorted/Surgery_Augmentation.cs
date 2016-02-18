// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Surgery_Augmentation : Surgery {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "augmentation";
			this.steps = new ByTable(new object [] { 
				typeof(SurgeryStep_Incise), 
				typeof(SurgeryStep_ClampBleeders), 
				typeof(SurgeryStep_RetractSkin), 
				typeof(SurgeryStep_Replace), 
				typeof(SurgeryStep_Saw), 
				typeof(SurgeryStep_AddLimb)
			 });
			this.species = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human) });
			this.possible_locs = new ByTable(new object [] { "r_arm", "l_arm", "r_leg", "l_leg", "chest", "head" });
		}

	}

}