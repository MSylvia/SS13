// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Rank_Chaplain : Obj_Item_Clothing_Under_Rank {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bl_suit";
			this.item_color = "chapblack";
			this.can_adjust = false;
			this.icon_state = "chaplain";
		}

		public Obj_Item_Clothing_Under_Rank_Chaplain ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}