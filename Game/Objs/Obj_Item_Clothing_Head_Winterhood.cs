// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Winterhood : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cold_protection = 1;
			this.min_cold_protection_temperature = 60;
			this.flags = 2;
			this.icon_state = "winterhood";
		}

		public Obj_Item_Clothing_Head_Winterhood ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}