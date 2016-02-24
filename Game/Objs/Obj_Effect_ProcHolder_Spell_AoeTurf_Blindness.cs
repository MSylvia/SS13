// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_AoeTurf_Blindness : Obj_Effect_ProcHolder_Spell_AoeTurf {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.message = "<span class='notice'>You glare your eyes.</span>";
			this.charge_max = 600;
			this.clothes_req = 0;
			this.range = 10;
		}

		public Obj_Effect_ProcHolder_Spell_AoeTurf_Blindness ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: statue.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			Mob_Living L = null;
			dynamic T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living) )) {
				L = _a;
				
				T = GlobalFuncs.get_turf( L.loc );

				if ( Lang13.Bool( targets.Contains( Lang13.Bool( T ) && Lang13.Bool( T ) ) ) ) {
					L.blind_eyes( 4 );
				}
			}
			return false;
		}

	}

}