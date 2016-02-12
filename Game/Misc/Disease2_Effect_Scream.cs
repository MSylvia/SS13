// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Scream : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Loudness Syndrome";
			this.stage = 2;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			mob.emote( "scream", null, null, true );
			return false;
		}

	}

}