// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_OreBox_Hax : Obj_Structure_OreBox {

		// Function from file: debug_shit.dm
		public Obj_Structure_OreBox_Hax ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic ore_id = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.Enumerate( ((dynamic)this.materials).storage )) {
				ore_id = _a;
				
				((dynamic)this.materials).addAmount( ore_id, 20 );
			}
			return;
		}

	}

}