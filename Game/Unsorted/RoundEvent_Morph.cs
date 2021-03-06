// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Morph : RoundEvent {

		public string key_of_morph = null;

		// Function from file: morph.dm
		public override bool start(  ) {
			this.get_morph();
			return false;
		}

		// Function from file: morph.dm
		public void find_morph(  ) {
			GlobalFuncs.message_admins( "Attempted to spawn a morph but there was no players available. Will try again momentarily." );
			Task13.Schedule( 50, (Task13.Closure)(() => {
				
				if ( this.get_morph( true ) ) {
					GlobalFuncs.message_admins( "Situation has been resolved, " + this.key_of_morph + " has been spawned as a morph." );
					GlobalFuncs.log_game( "" + this.key_of_morph + " was spawned as a morph by an event." );
					return;
				}
				GlobalFuncs.message_admins( "Unfortunately, no candidates were available for becoming a morph. Shutting down." );
				return;
			}));
			this.kill(); return;
		}

		// Function from file: morph.dm
		public bool get_morph( bool? end_if_fail = null ) {
			end_if_fail = end_if_fail ?? false;

			ByTable candidates = null;
			dynamic C = null;
			Mind player_mind = null;
			Mob_Living_SimpleAnimal_Hostile_Morph S = null;

			this.key_of_morph = null;

			if ( !Lang13.Bool( this.key_of_morph ) ) {
				candidates = GlobalFuncs.get_candidates( "xenomorph" );

				if ( !( candidates.len != 0 ) ) {
					
					if ( end_if_fail == true ) {
						return false;
					}
					this.find_morph(); return false;
				}
				C = Rand13.PickFromTable( candidates );
				this.key_of_morph = C.key;
			}

			if ( !Lang13.Bool( this.key_of_morph ) ) {
				
				if ( end_if_fail == true ) {
					return false;
				}
				this.find_morph(); return false;
			}
			player_mind = new Mind( this.key_of_morph );
			player_mind.active = true;

			if ( !( GlobalVars.xeno_spawn != null ) ) {
				this.find_morph(); return false;
			}
			S = new Mob_Living_SimpleAnimal_Hostile_Morph( Rand13.PickFromTable( GlobalVars.xeno_spawn ) );
			player_mind.transfer_to( S );
			player_mind.assigned_role = "Morph";
			player_mind.special_role = "Morph";
			GlobalVars.ticker.mode.traitors.Or( player_mind );
			S.WriteMsg( S.playstyle_string );
			S.WriteMsg( "sound/magic/Mutate.ogg" );
			GlobalFuncs.message_admins( "" + this.key_of_morph + " has been made into morph by an event." );
			GlobalFuncs.log_game( "" + this.key_of_morph + " was spawned as a morph by an event." );
			return true;
		}

	}

}