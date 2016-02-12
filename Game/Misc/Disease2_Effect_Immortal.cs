// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Immortal : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Longevity Syndrome";
		}

		// Function from file: effect.dm
		public override void deactivate( Mob_Living mob = null, dynamic multiplier = null ) {
			Mob_Living H = null;
			int? backlash_amt = null;

			
			if ( mob is Mob_Living_Carbon_Human ) {
				H = mob;
				GlobalFuncs.to_chat( H, "<span class='notice'>You suddenly feel hurt and old...</span>" );
				((dynamic)H).age += 8;
			}
			backlash_amt = Lang13.IntNullable( multiplier * 5 );
			mob.apply_damages( backlash_amt, backlash_amt, backlash_amt, backlash_amt );
			return;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			Mob_Living H = null;
			Organ_External E = null;
			int? heal_amt = null;

			
			if ( mob is Mob_Living_Carbon_Human ) {
				H = mob;

				foreach (dynamic _a in Lang13.Enumerate( ((dynamic)H).organs, typeof(Organ_External) )) {
					E = _a;
					

					if ( ( E.status & 32 ) != 0 && Rand13.PercentChance( 30 ) ) {
						E.status ^= 32;
					}
				}
			}
			heal_amt = ( multiplier ?1:0) * -5;
			mob.apply_damages( heal_amt, heal_amt, heal_amt, heal_amt );
			return false;
		}

	}

}