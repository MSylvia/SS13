// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Griffin : Obj_Item_Clothing_Shoes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "griffinboots";
			this.can_hold_items = true;
			this.icon_state = "griffinboots";
		}

		public Obj_Item_Clothing_Shoes_Griffin ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}