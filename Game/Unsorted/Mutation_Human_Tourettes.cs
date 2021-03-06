// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mutation_Human_Tourettes : Mutation_Human {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Tourettes Syndrome";
			this.quality = 2;
			this.text_gain_indication = "<span class='danger'>You twitch.</span>";
		}

		// Function from file: mutations.dm
		public override void on_life( Mob_Living owner = null ) {
			int x_offset_old = 0;
			int y_offset_old = 0;
			int x_offset = 0;
			int y_offset = 0;

			
			if ( Rand13.PercentChance( 10 ) && owner.paralysis <= 1 ) {
				owner.Stun( 10 );

				dynamic _a = Rand13.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
				if ( 2<=_a&&_a<=3 ) {
					owner.say( "" + ( Rand13.PercentChance( 50 ) ? ";" : "" ) + Rand13.Pick(new object [] { "SHIT", "PISS", "FUCK", "CUNT", "COCKSUCKER", "MOTHERFUCKER", "TITS" }) );
				} else if ( _a==1 ) {
					owner.emote( "twitch" );
				}
				x_offset_old = owner.pixel_x;
				y_offset_old = owner.pixel_y;
				x_offset = owner.pixel_x + Rand13.Int( -2, 2 );
				y_offset = owner.pixel_y + Rand13.Int( -1, 1 );
				Icon13.Animate( new ByTable().Set( 1, owner ).Set( "pixel_x", x_offset ).Set( "pixel_y", y_offset ).Set( "time", 1 ) );
				Icon13.Animate( new ByTable().Set( 1, owner ).Set( "pixel_x", x_offset_old ).Set( "pixel_y", y_offset_old ).Set( "time", 1 ) );
			}
			return;
		}

	}

}