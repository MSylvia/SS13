// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_CableCoil_Cut : Obj_Item_Stack_CableCoil {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "coil_red2";
		}

		// Function from file: cable.dm
		public Obj_Item_Stack_CableCoil_Cut ( dynamic loc = null, int? amount = null, dynamic param_color = null ) : base( (object)(loc), amount, (object)(param_color) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.amount = Rand13.Int( 1, 2 );
			this.pixel_x = Rand13.Int( -2, 2 );
			this.pixel_y = Rand13.Int( -2, 2 );
			this.update_icon();
			return;
		}

	}

}