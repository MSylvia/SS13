// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Blink : Obj_Item_Toy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "signaler";
			this.icon = "icons/obj/radio.dmi";
			this.icon_state = "beacon";
		}

		public Obj_Item_Toy_Blink ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}