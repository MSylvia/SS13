// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_Sting_ExtractDna : Obj_Effect_ProcHolder_Changeling_Sting {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.helptext = "Will give you the DNA of your target, allowing you to transform into them.";
			this.sting_icon = "sting_extract";
			this.chemical_cost = 25;
			this.dna_cost = 0;
		}

		public Obj_Effect_ProcHolder_Changeling_Sting_ExtractDna ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tiny_prick.dm
		public override dynamic sting_action( Mob user = null, Ent_Static target = null ) {
			GlobalFuncs.add_logs( user, target, "stung", "extraction sting" );

			if ( !user.mind.changeling.has_dna( ((dynamic)target).dna ) ) {
				user.mind.changeling.add_new_profile( target, user );
			}
			GlobalFuncs.feedback_add_details( "changeling_powers", "ED" );
			return 1;
		}

		// Function from file: tiny_prick.dm
		public override bool can_sting( Mob user = null, Ent_Static target = null ) {
			
			if ( base.can_sting( user, target ) ) {
				return user.mind.changeling.can_absorb_dna( user, target );
			}
			return false;
		}

	}

}