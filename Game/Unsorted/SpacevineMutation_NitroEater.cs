// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpacevineMutation_NitroEater : SpacevineMutation {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "nitrogen consuming";
			this.hue = "#8888ff";
			this.severity = 3;
			this.quality = 2;
		}

		// Function from file: spacevine.dm
		public override void process_mutation( Obj_Effect_Spacevine holder = null ) {
			Ent_Static T = null;
			GasMixture GM = null;

			T = holder.loc;

			if ( T is Tile_Simulated_Floor ) {
				GM = ((dynamic)T).air;

				if ( !Lang13.Bool( GM.gases["n2"] ) ) {
					return;
				}
				GM.gases["n2"][1] -= ( this.severity ??0) * holder.energy;
				GM.garbage_collect();
			}
			return;
		}

	}

}