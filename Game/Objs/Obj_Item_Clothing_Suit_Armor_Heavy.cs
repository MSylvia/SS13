// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Armor_Heavy : Obj_Item_Clothing_Suit_Armor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "swat_suit";
			this.w_class = 4;
			this.gas_transfer_coefficient = 081;
			this.flags = 8192;
			this.body_parts_covered = 2046;
			this.slowdown = 3;
			this.flags_inv = 13;
			this.icon_state = "heavy";
		}

		public Obj_Item_Clothing_Suit_Armor_Heavy ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}