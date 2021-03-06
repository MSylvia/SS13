// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Blob_BoilingOil : Reagent_Blob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Boiling Oil";
			this.id = "boiling_oil";
			this.description = "will do medium burn damage and set targets on fire.";
			this.color = "#B68D00";
			this.blobbernaut_message = "splashes";
			this.message = "The blob splashes you with burning oil";
			this.message_living = ", and you feel your skin char and melt";
		}

		// Function from file: blob_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			reac_volume = base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			((Mob_Living)M).adjust_fire_stacks( Num13.Floor( ( reac_volume ??0) / 12 ) );
			((Mob_Living)M).IgniteMob();

			if ( Lang13.Bool( M ) ) {
				((Mob_Living)M).apply_damage( ( reac_volume ??0) * 0.6, "fire" );
			}

			if ( M is Mob_Living_Carbon ) {
				((Mob)M).emote( "scream" );
			}
			return 0;
		}

	}

}