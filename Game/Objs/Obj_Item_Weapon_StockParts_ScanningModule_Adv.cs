// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_ScanningModule_Adv : Obj_Item_Weapon_StockParts_ScanningModule {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "magnets=3";
			this.rating = 2;
			this.materials = new ByTable().Set( "$metal", 50 ).Set( "$glass", 20 );
			this.icon_state = "adv_scan_module";
		}

		public Obj_Item_Weapon_StockParts_ScanningModule_Adv ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}