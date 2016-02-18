// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Operative : RoundEvent {

		public string key_of_operative = null;

		// Function from file: operative.dm
		public override bool start(  ) {
			this.get_operative();
			return false;
		}

		// Function from file: operative.dm
		public void find_operative(  ) {
			GlobalFuncs.message_admins( "Attempted to spawn a operative but there was no players available. Will try again momentarily." );
			Task13.Schedule( 50, (Task13.Closure)(() => {
				
				if ( this.get_operative( true ) ) {
					GlobalFuncs.message_admins( "Situation has been resolved, " + this.key_of_operative + " has been spawned as a operative." );
					GlobalFuncs.log_game( "" + this.key_of_operative + " was spawned as a operative by an event." );
					return;
				}
				GlobalFuncs.message_admins( "Unfortunately, no candidates were available for becoming a operative. Shutting down." );
				return;
			}));
			this.kill(); return;
		}

		// Function from file: operative.dm
		public bool get_operative( bool? end_if_fail = null ) {
			end_if_fail = end_if_fail ?? false;

			ByTable candidates = null;
			dynamic C = null;
			Mind player_mind = null;
			ByTable spawn_locs = null;
			Obj_Effect_Landmark L = null;
			Mob_Living_Carbon_Human operative = null;
			Preferences A = null;
			Mind Mind = null;
			dynamic nuke = null;
			dynamic nuke_code = null;
			Objective_Nuclear O = null;

			this.key_of_operative = null;

			if ( !Lang13.Bool( this.key_of_operative ) ) {
				candidates = GlobalFuncs.get_candidates( "operative", 3000, "operative" );

				if ( !( candidates.len != 0 ) ) {
					
					if ( end_if_fail == true ) {
						return false;
					}
					this.find_operative(); return false;
				}
				C = Rand13.PickFromTable( candidates );
				this.key_of_operative = C.key;
			}

			if ( !Lang13.Bool( this.key_of_operative ) ) {
				
				if ( end_if_fail == true ) {
					return false;
				}
				this.find_operative(); return false;
			}
			player_mind = new Mind( this.key_of_operative );
			player_mind.active = true;
			spawn_locs = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.landmarks_list, typeof(Obj_Effect_Landmark) )) {
				L = _a;
				

				if ( new ByTable(new object [] { "ninjaspawn", "carpspawn" }).Contains( L.name ) ) {
					spawn_locs.Add( L.loc );
				}
			}

			if ( !( spawn_locs.len != 0 ) ) {
				this.kill(); return false;
			}
			operative = new Mob_Living_Carbon_Human( Rand13.PickFromTable( spawn_locs ) );
			A = new Preferences();
			A.copy_to( operative );
			operative.dna.update_dna_identity();
			operative.equipOutfit( typeof(Outfit_Syndicate_Full) );
			Mind = new Mind( this.key_of_operative );
			Mind.assigned_role = "Lone Operative";
			Mind.special_role = "Lone Operative";
			GlobalVars.ticker.mode.traitors.Or( Mind );
			Mind.active = true;
			nuke = Lang13.FindIn( typeof(Obj_Machinery_Nuclearbomb_Selfdestruct), GlobalVars.machines );

			if ( Lang13.Bool( nuke ) ) {
				nuke_code = null;

				if ( !Lang13.Bool( nuke.r_code ) || nuke.r_code == "ADMIN" ) {
					nuke_code = "" + Rand13.Int( 10000, 99999 );
					nuke.r_code = nuke_code;
				} else {
					nuke_code = nuke.r_code;
				}
				Mind.store_memory( "<B>Station Self-Destruct Device Code</B>: " + nuke_code );
				Mind.current.WriteMsg( "The nuclear authorization code is: <B>" + nuke_code + "</B>" );
				O = new Objective_Nuclear();
				O.owner = Mind;
				Mind.objectives.Add( O );
			}
			Mind.transfer_to( operative );
			GlobalFuncs.message_admins( "" + this.key_of_operative + " has been made into lone operative by an event." );
			GlobalFuncs.log_game( "" + this.key_of_operative + " was spawned as a lone operative by an event." );
			return true;
		}

	}

}