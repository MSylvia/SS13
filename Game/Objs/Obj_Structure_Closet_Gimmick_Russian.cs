// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Gimmick_Russian : Obj_Structure_Closet_Gimmick {

		// Function from file: gimmick.dm
		public Obj_Structure_Closet_Gimmick_Russian ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;
			double i2 = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 1, 5 )) {
				i = _a;
				
				new Obj_Item_Clothing_Head_Ushanka( this );
			}

			foreach (dynamic _b in Lang13.IterateRange( 1, 5 )) {
				i2 = _b;
				
				new Obj_Item_Clothing_Under_Soviet( this );
			}
			return;
		}

	}

}