// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Map_Spawner_SetSpawner : Obj_Map_Spawner {

		public int subChance = 100;

		// Function from file: set_spawners.dm
		public Obj_Map_Spawner_SetSpawner ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj spawned = null;

			this.toSpawn = Rand13.PickFromTable( this.toSpawn );

			while (this.amount != 0) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.toSpawn )) {

					if ( this.subChance != 0 ) {
						Lang13.Call( _a, this.loc );

						if ( this.jiggle != 0 ) {
							spawned.pixel_x = Rand13.Int( -this.jiggle, this.jiggle );
							spawned.pixel_y = Rand13.Int( -this.jiggle, this.jiggle );
						}
					}
				}
				this.amount--;
			}
			GlobalFuncs.qdel( this );
			return;
		}

	}

}