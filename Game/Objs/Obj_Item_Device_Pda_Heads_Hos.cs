// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Pda_Heads_Hos : Obj_Item_Device_Pda_Heads {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.default_cartridge = typeof(Obj_Item_Weapon_Cartridge_Hos);
			this.icon_state = "pda-hos";
		}

		public Obj_Item_Device_Pda_Heads_Hos ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}