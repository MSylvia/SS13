// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Breath_Golem : Obj_Item_Clothing_Mask_Breath {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "golem";
			this.siemens_coefficient = 0;
			this.unacidable = true;
			this.flags = 130;
			this.icon_state = "golem";
		}

		public Obj_Item_Clothing_Mask_Breath_Golem ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}