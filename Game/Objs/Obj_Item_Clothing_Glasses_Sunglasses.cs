// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Glasses_Sunglasses : Obj_Item_Clothing_Glasses {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "sunglasses";
			this.darkness_view = 1;
			this.flash_protect = 1;
			this.tint = 1;
			this.icon_state = "sun";
		}

		public Obj_Item_Clothing_Glasses_Sunglasses ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}