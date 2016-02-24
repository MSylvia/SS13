// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_ResonantShriek : Obj_Effect_ProcHolder_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.helptext = "Emits a high-frequency sound that confuses and deafens humans, blows out nearby lights and overloads cyborg sensors.";
			this.chemical_cost = 20;
			this.dna_cost = 1;
			this.req_human = true;
		}

		public Obj_Effect_ProcHolder_Changeling_ResonantShriek ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shriek.dm
		public override dynamic sting_action( Mob user = null, Ent_Static target = null ) {
			Mob_Living M = null;
			Obj_Machinery_Light L = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_hearers_in_view( 4, user ), typeof(Mob_Living) )) {
				M = _a;
				

				if ( M is Mob_Living_Carbon ) {
					
					if ( !( M.mind != null ) || !( M.mind.changeling != null ) ) {
						M.adjustEarDamage( 0, 30 );
						M.confused += 25;
						M.Jitter( 50 );
					} else {
						M.WriteMsg( new Sound( "sound/effects/screech.ogg" ) );
					}
				}

				if ( M is Mob_Living_Silicon ) {
					M.WriteMsg( new Sound( "sound/weapons/flash.ogg" ) );
					M.Weaken( Rand13.Int( 5, 10 ) );
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRange( user, 4 ), typeof(Obj_Machinery_Light) )) {
				L = _b;
				
				L.on = true;
				L.broken();
			}
			GlobalFuncs.feedback_add_details( "changeling_powers", "RS" );
			return 1;
		}

	}

}