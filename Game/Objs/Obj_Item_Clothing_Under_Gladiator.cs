// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Gladiator : Obj_Item_Clothing_Under {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "gladiator";
			this.item_color = "gladiator";
			this.body_parts_covered = 390;
			this.fitted = 0;
			this.can_adjust = false;
			this.icon_state = "gladiator";
		}

		public Obj_Item_Clothing_Under_Gladiator ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}