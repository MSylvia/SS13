// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_AbsorbDNA : Obj_Effect_ProcHolder_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dna_cost = 0;
			this.req_human = true;
		}

		public Obj_Effect_ProcHolder_Changeling_AbsorbDNA ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: absorb.dm
		public override dynamic sting_action( Mob user = null, Ent_Static target = null ) {
			Changeling changeling = null;
			dynamic G = null;
			Mob_Living target2 = null;
			int? stage = null;
			ByTable recent_speech = null;
			dynamic spoken_memory = null;
			dynamic spoken_memory2 = null;

			changeling = user.mind.changeling;
			G = user.get_active_hand();
			target2 = G.affecting;
			changeling.isabsorbing = true;
			stage = null;
			stage = 1;

			while (( stage ??0) <= 3) {
				
				switch ((int?)( stage )) {
					case 1:
						user.WriteMsg( "<span class='notice'>This creature is compatible. We must hold still...</span>" );
						break;
					case 2:
						user.visible_message( "<span class='warning'>" + user + " extends a proboscis!</span>", "<span class='notice'>We extend a proboscis.</span>" );
						break;
					case 3:
						user.visible_message( "<span class='danger'>" + user + " stabs " + target2 + " with the proboscis!</span>", "<span class='notice'>We stab " + target2 + " with the proboscis.</span>" );
						target2.WriteMsg( "<span class='userdanger'>You feel a sharp stabbing pain!</span>" );
						target2.take_overall_damage( 40 );
						break;
				}
				GlobalFuncs.feedback_add_details( "changeling_powers", "A" + stage );

				if ( !GlobalFuncs.do_mob( user, target2, 150 ) ) {
					user.WriteMsg( "<span class='warning'>Our absorption of " + target2 + " has been interrupted!</span>" );
					changeling.isabsorbing = false;
					return null;
				}
				stage++;
			}
			user.visible_message( "<span class='danger'>" + user + " sucks the fluids from " + target2 + "!</span>", "<span class='notice'>We have absorbed " + target2 + ".</span>" );
			target2.WriteMsg( "<span class='userdanger'>You are absorbed by the changeling!</span>" );

			if ( !changeling.has_dna( ((dynamic)target2).dna ) ) {
				changeling.add_new_profile( target2, user );
			}

			if ( user.nutrition < 450 ) {
				user.nutrition = Num13.MinInt( ((int)( user.nutrition + target2.nutrition )), 450 );
			}

			if ( target2.mind != null ) {
				target2.mind.show_memory( this, false );
				recent_speech = new ByTable();

				if ( target2.say_log.len > 8 ) {
					recent_speech = target2.say_log.Copy( target2.say_log.len - 8 + 1, 0 );
				} else {
					
					foreach (dynamic _b in Lang13.Enumerate( target2.say_log )) {
						spoken_memory = _b;
						

						if ( recent_speech.len >= 8 ) {
							break;
						}
						recent_speech.Add( spoken_memory );
					}
				}

				if ( recent_speech.len != 0 ) {
					user.mind.store_memory( "<B>Some of " + target2 + "'s speech patterns, we should study these to better impersonate them!</B>" );
					user.WriteMsg( "<span class='boldnotice'>Some of " + target2 + "'s speech patterns, we should study these to better impersonate them!</span>" );

					foreach (dynamic _c in Lang13.Enumerate( recent_speech )) {
						spoken_memory2 = _c;
						
						user.mind.store_memory( "\"" + spoken_memory2 + "\"" );
						user.WriteMsg( "<span class='notice'>\"" + spoken_memory2 + "\"</span>" );
					}
					user.mind.store_memory( "<B>We have no more knowledge of " + target2 + "'s speech patterns.</B>" );
					user.WriteMsg( "<span class='boldnotice'>We have no more knowledge of " + target2 + "'s speech patterns.</span>" );
				}

				if ( target2.mind.changeling != null ) {
					changeling.chem_charges += Num13.MinInt( ((int)( target2.mind.changeling.chem_charges )), Convert.ToInt32( changeling.chem_storage ) );
					changeling.absorbedcount += target2.mind.changeling.absorbedcount;
					target2.mind.changeling.stored_profiles.len = 1;
					target2.mind.changeling.absorbedcount = 0;
				}
			}
			changeling.chem_charges = Num13.MinInt( ((int)( changeling.chem_charges + 10 )), Convert.ToInt32( changeling.chem_storage ) );
			changeling.isabsorbing = false;
			changeling.canrespec = true;
			target2.death( false );
			((dynamic)target2).Drain();
			return 1;
		}

		// Function from file: absorb.dm
		public override bool can_sting( Mob user = null, Ent_Static target = null ) {
			Changeling changeling = null;
			dynamic G = null;
			Mob_Living_Carbon target2 = null;

			
			if ( !base.can_sting( user, target ) ) {
				return false;
			}
			changeling = user.mind.changeling;

			if ( changeling.isabsorbing ) {
				user.WriteMsg( "<span class='warning'>We are already absorbing!</span>" );
				return false;
			}
			G = user.get_active_hand();

			if ( !( G is Obj_Item_Weapon_Grab ) ) {
				user.WriteMsg( "<span class='warning'>We must be grabbing a creature in our active hand to absorb them!</span>" );
				return false;
			}

			if ( Convert.ToDouble( G.state ) <= 3 ) {
				user.WriteMsg( "<span class='warning'>We must have a tighter grip to absorb this creature!</span>" );
				return false;
			}
			target2 = G.affecting;
			return changeling.can_absorb_dna( user, target2 );
		}

	}

}