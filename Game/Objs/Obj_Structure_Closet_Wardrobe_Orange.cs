// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_Orange : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_door = "orange";
		}

		// Function from file: wardrobe.dm
		public Obj_Structure_Closet_Wardrobe_Orange ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;
			double i2 = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();

			foreach (dynamic _a in Lang13.IterateRange( 1, 3 )) {
				i = _a;
				
				new Obj_Item_Clothing_Under_Rank_Prisoner( this );
			}

			foreach (dynamic _b in Lang13.IterateRange( 1, 3 )) {
				i2 = _b;
				
				new Obj_Item_Clothing_Shoes_Sneakers_Orange( this );
			}
			return;
		}

	}

}