// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_Sting_Mute : Obj_Effect_ProcHolder_Changeling_Sting {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.helptext = "Does not provide a warning to the victim that they have been stung, until they try to speak and cannot.";
			this.sting_icon = "sting_mute";
			this.chemical_cost = 20;
			this.dna_cost = 2;
		}

		public Obj_Effect_ProcHolder_Changeling_Sting_Mute ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tiny_prick.dm
		public override dynamic sting_action( Mob user = null, Ent_Static target = null ) {
			GlobalFuncs.add_logs( user, target, "stung", "mute sting" );
			((dynamic)target).silent += 30;
			GlobalFuncs.feedback_add_details( "changeling_powers", "MS" );
			return 1;
		}

	}

}