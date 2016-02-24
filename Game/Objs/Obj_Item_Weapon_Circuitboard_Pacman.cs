// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Pacman : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = typeof(Obj_Machinery_Power_PortGen_Pacman);
			this.board_type = "machine";
			this.origin_tech = "programming=3;powerstorage=3;plasmatech=3;engineering=3";
			this.req_components = new ByTable()
				.Set( typeof(Obj_Item_Weapon_StockParts_MatterBin), 1 )
				.Set( typeof(Obj_Item_Weapon_StockParts_MicroLaser), 1 )
				.Set( typeof(Obj_Item_Stack_CableCoil), 2 )
				.Set( typeof(Obj_Item_Weapon_StockParts_Capacitor), 1 )
			;
		}

		public Obj_Item_Weapon_Circuitboard_Pacman ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}