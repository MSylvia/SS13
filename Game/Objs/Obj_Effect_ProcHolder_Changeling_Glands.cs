// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_Glands : Obj_Effect_ProcHolder_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.helptext = "Allows us to store an extra 25 units of chemicals, and doubles production rate.";
			this.dna_cost = 2;
			this.chemical_cost = -1;
		}

		public Obj_Effect_ProcHolder_Changeling_Glands ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tgstation.dme
		public override void on_purchase( Mob user = null ) {
			Changeling changeling = null;

			base.on_purchase( user );
			changeling = user.mind.changeling;
			changeling.chem_storage += 25;
			changeling.chem_recharge_rate *= 2;
			return;
		}

	}

}