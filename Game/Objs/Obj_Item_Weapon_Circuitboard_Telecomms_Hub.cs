// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Telecomms_Hub : Obj_Item_Weapon_Circuitboard_Telecomms {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/telecomms/hub";
			this.board_type = "machine";
			this.origin_tech = "programming=4;engineering=4";
			this.frame_desc = "Requires 2 Manipulators, 2 Cable Coil and 2 Hyperwave Filter.";
			this.req_components = new ByTable().Set( "/obj/item/weapon/stock_parts/manipulator", 2 ).Set( "/obj/item/stack/cable_coil", 2 ).Set( "/obj/item/weapon/stock_parts/subspace/filter", 2 );
		}

		public Obj_Item_Weapon_Circuitboard_Telecomms_Hub ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}