// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_HivemindDownload : Obj_Effect_ProcHolder_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.chemical_cost = 10;
		}

		public Obj_Effect_ProcHolder_Changeling_HivemindDownload ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: hivemind.dm
		public override dynamic sting_action( Mob user = null, Ent_Static target = null ) {
			Changeling changeling = null;
			ByTable names = null;
			Changelingprofile prof = null;
			dynamic S = null;
			Base_Data chosen_prof = null;
			dynamic downloaded_prof = null;

			changeling = user.mind.changeling;
			names = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.hivemind_bank, typeof(Changelingprofile) )) {
				prof = _a;
				

				if ( !changeling.stored_profiles.Contains( prof ) ) {
					names[prof.name] = prof;
				}
			}

			if ( names.len <= 0 ) {
				user.WriteMsg( "<span class='notice'>There's no new DNA to absorb from the air.</span>" );
				return null;
			}
			S = Interface13.Input( "Select a DNA absorb from the air: ", "Absorb DNA", null, null, names, InputType.Null | InputType.Any );

			if ( !Lang13.Bool( S ) ) {
				return null;
			}
			chosen_prof = names[S];

			if ( !( chosen_prof != null ) ) {
				return null;
			}
			downloaded_prof = Lang13.Call( chosen_prof.type );
			((dynamic)chosen_prof).copy_profile( downloaded_prof );
			changeling.add_profile( downloaded_prof );
			user.WriteMsg( "<span class='notice'>We absorb the DNA of " + S + " from the air.</span>" );
			GlobalFuncs.feedback_add_details( "changeling_powers", "HD" );
			return 1;
		}

		// Function from file: hivemind.dm
		public override bool can_sting( Mob user = null, Ent_Static target = null ) {
			Changeling changeling = null;
			dynamic first_prof = null;

			
			if ( !base.can_sting( user, target ) ) {
				return false;
			}
			changeling = user.mind.changeling;
			first_prof = changeling.stored_profiles[1];

			if ( first_prof.name == user.real_name ) {
				user.WriteMsg( "<span class='warning'>We have reached our capacity to store genetic information! We must transform before absorbing more.</span>" );
				return false;
			}
			return true;
		}

	}

}