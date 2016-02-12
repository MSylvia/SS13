// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Power_Changeling_AbsorbDna : Power_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Absorb DNA";
			this.desc = "Permits us to syphon the DNA from a human. They become one with us, and we become stronger.";
			this.genomecost = 0;
			this.verbpath = typeof(Mob).GetMethod( "changeling_absorb_dna" );
		}

	}

}