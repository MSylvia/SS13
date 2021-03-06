// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_BeachBall_Holoball_Dodgeball : Obj_Item_Toy_BeachBall_Holoball {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "dodgeball";
			this.icon_state = "dodgeball";
		}

		public Obj_Item_Toy_BeachBall_Holoball_Dodgeball ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: items.dm
		public override bool throw_impact( dynamic target = null, Mob_Living_Carbon thrower = null ) {
			dynamic M = null;

			base.throw_impact( (object)(target), thrower );

			if ( target is Mob_Living_Carbon_Human ) {
				M = target;
				GlobalFuncs.playsound( this, "sound/items/dodgeball.ogg", 50, 1 );
				M.apply_damage( 10, "stamina" );

				if ( Rand13.PercentChance( 5 ) ) {
					((Mob)M).Weaken( 3 );
					this.visible_message( new Txt( "<span class='danger'>" ).item( M ).str( " is knocked right off " ).his_her_its_their().str( " feet!</span>" ).ToString(), 3 );
				}
			}
			return false;
		}

	}

}