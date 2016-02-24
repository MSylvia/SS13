// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Disk_TechDisk : Obj_Item_Weapon_Disk {

		public dynamic stored = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "card-id";
			this.w_class = 1;
			this.materials = new ByTable().Set( "$metal", 30 ).Set( "$glass", 10 );
			this.icon = "icons/obj/cloning.dmi";
			this.icon_state = "datadisk2";
		}

		// Function from file: research.dm
		public Obj_Item_Weapon_Disk_TechDisk ( dynamic loc = null ) : base( (object)(loc) ) {
			this.pixel_x = Rand13.Int( -5, 5 );
			this.pixel_y = Rand13.Int( -5, 5 );
			return;
		}

	}

}