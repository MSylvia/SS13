// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Misc_Janitor_Janicart : SupplyPack_Misc_Janitor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Janitorial Cart and Galoshes Crate";
			this.cost = 20;
			this.contains = new ByTable(new object [] { typeof(Obj_Structure_Janitorialcart), typeof(Obj_Item_Clothing_Shoes_Galoshes) });
			this.crate_name = "janitorial cart crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Large);
		}

	}

}