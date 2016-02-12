// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Beam_Lastertag_Blue : Obj_Item_Projectile_Beam_Lastertag {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 0;
			this.icon_state = "bluelaser";
		}

		public Obj_Item_Projectile_Beam_Lastertag_Blue ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: beams.dm
		public override bool on_hit( dynamic atarget = null, int? blocked = null ) {
			blocked = blocked ?? 0;

			dynamic M = null;

			
			if ( atarget is Mob_Living_Carbon_Human ) {
				M = atarget;

				if ( M.wear_suit is Obj_Item_Clothing_Suit_Redtag ) {
					((Mob)M).Weaken( 5 );
				}
			}
			return true;
		}

	}

}