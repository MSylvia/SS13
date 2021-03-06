// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Autolathe : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = typeof(Obj_Machinery_Autolathe);
			this.board_type = "machine";
			this.origin_tech = "engineering=2;programming=2";
			this.req_components = new ByTable().Set( typeof(Obj_Item_Weapon_StockParts_MatterBin), 3 ).Set( typeof(Obj_Item_Weapon_StockParts_Manipulator), 1 ).Set( typeof(Obj_Item_Weapon_StockParts_ConsoleScreen), 1 );
		}

		public Obj_Item_Weapon_Circuitboard_Autolathe ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}