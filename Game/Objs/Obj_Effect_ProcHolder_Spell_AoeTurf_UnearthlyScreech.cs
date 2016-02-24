// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_AoeTurf_UnearthlyScreech : Obj_Effect_ProcHolder_Spell_AoeTurf {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.panel = "Shadowling Abilities";
			this.charge_max = 300;
			this.human_req = 1;
			this.clothes_req = 0;
			this.action_icon_state = "screech";
			this.sound = "sound/effects/screech.ogg";
		}

		public Obj_Effect_ProcHolder_Spell_AoeTurf_UnearthlyScreech ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shadowling_abilities.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			dynamic T = null;
			dynamic target = null;
			dynamic M = null;
			dynamic S = null;
			EffectSystem_SparkSpread sp = null;
			Obj_Structure_Window W = null;

			
			if ( !this.shadowling_check( thearea ) ) {
				this.revert_cast();
				return false;
			}
			((Ent_Static)thearea).audible_message( "<span class='warning'><b>" + thearea + " lets out a horrible scream!</b></span>" );

			foreach (dynamic _c in Lang13.Enumerate( targets )) {
				T = _c;
				

				foreach (dynamic _a in Lang13.Enumerate( T.contents )) {
					target = _a;
					

					if ( GlobalFuncs.is_shadow_or_thrall( target ) ) {
						
						if ( target == thearea ) {
							continue;
						} else {
							continue;
						}
					}

					if ( target is Mob_Living_Carbon ) {
						M = target;
						M.WriteMsg( "<span class='danger'><b>A spike of pain drives into your head and scrambles your thoughts!</b></span>" );
						M.confused += 10;
						((Mob)M).setEarDamage( M.ear_damage + 3 );
					} else if ( target is Mob_Living_Silicon ) {
						S = target;
						S.WriteMsg( "<span class='warning'><b>ERROR $!(@ ERROR )#^! SENSORY OVERLOAD [$(!@#</b></span>" );
						S.WriteMsg( "sound/misc/interference.ogg" );
						GlobalFuncs.playsound( S, "sound/machines/warning-buzzer.ogg", 50, 1 );
						sp = new EffectSystem_SparkSpread();
						sp.set_up( 5, 1, S );
						sp.start();
						((Mob)S).Weaken( 6 );
					}
				}

				foreach (dynamic _b in Lang13.Enumerate( T.contents, typeof(Obj_Structure_Window) )) {
					W = _b;
					
					W.hit( Rand13.Int( 80, 100 ) );
				}
			}
			return false;
		}

	}

}