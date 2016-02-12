// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_AdvSensor : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Advanced Scanning Module";
			this.desc = "A stock part used in the construction of various devices.";
			this.id = "adv_sensor";
			this.req_tech = new ByTable().Set( "magnets", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 50 ).Set( "$glass", 20 );
			this.category = "Stock Parts";
			this.build_path = typeof(Obj_Item_Weapon_StockParts_ScanningModule_Adv);
		}

	}

}