// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Spacevine : RoundEvent {

		// Function from file: spacevine.dm
		public override bool start(  ) {
			ByTable turfs = null;
			Obj_Effect_Spacevine SV = null;
			Zone_Hallway A = null;
			Tile_Simulated F = null;
			dynamic T = null;

			turfs = new ByTable();
			SV = new Obj_Effect_Spacevine();

			foreach (dynamic _b in Lang13.Enumerate( typeof(Game13), typeof(Zone_Hallway) )) {
				A = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( A, typeof(Tile_Simulated) )) {
					F = _a;
					

					if ( F.Enter( SV ) ) {
						turfs.Add( F );
					}
				}
			}
			GlobalFuncs.qdel( SV );

			if ( turfs.len != 0 ) {
				T = Rand13.PickFromTable( turfs );
				new Obj_Effect_SpacevineController( T );
			}
			return false;
		}

	}

}