// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Santa : Obj_Item_Clothing_Suit_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "santa";
			this.flags = 1;
			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item) });
			this.icon_state = "santa";
		}

		public Obj_Item_Clothing_Suit_Space_Santa ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}