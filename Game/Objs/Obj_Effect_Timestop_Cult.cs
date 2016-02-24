// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Timestop_Cult : Obj_Effect_Timestop {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pixel_x = -32;
			this.pixel_y = -32;
			this.alpha = 0;
			this.color = "#ff0000";
			this.duration = 50;
			this.icon = "icons/effects/96x96.dmi";
			this.icon_state = "rune_large";
		}

		public Obj_Effect_Timestop_Cult ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: runes.dm
		public override void timestop(  ) {
			Mob_Living M = null;

			Icon13.Animate( new ByTable().Set( 1, this ).Set( "alpha", 255 ).Set( "time", 5 ).Set( "loop", -1 ) );
			this.SpinAnimation( 5 );

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living) )) {
				M = _a;
				

				if ( GlobalFuncs.iscultist( M ) || Lang13.Bool( M.null_rod_check() ) ) {
					this.immune.Or( M );
				}
			}
			base.timestop();
			return;
		}

	}

}