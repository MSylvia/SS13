// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Blob_CryogenicLiquid : Reagent_Blob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cryogenic Liquid";
			this.id = "cryogenic_liquid";
			this.description = "will do low burn and stamina damage, and cause targets to freeze.";
			this.color = "#8BA6E9";
			this.blobbernaut_message = "splashes";
			this.message = "The blob splashes you with an icy liquid";
			this.message_living = ", and you feel cold and tired";
		}

		// Function from file: blob_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			reac_volume = base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );

			if ( Lang13.Bool( M.reagents ) ) {
				((Reagents)M.reagents).add_reagent( "frostoil", ( reac_volume ??0) * 0.4 );
				((Reagents)M.reagents).add_reagent( "ice", ( reac_volume ??0) * 0.4 );
			}
			((Mob_Living)M).apply_damage( ( reac_volume ??0) * 0.6, "fire" );

			if ( Lang13.Bool( M ) ) {
				((Mob_Living)M).adjustStaminaLoss( ( reac_volume ??0) * 0.4 );
			}
			return 0;
		}

	}

}