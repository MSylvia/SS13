// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Science_Shieldwalls : SupplyPack_Science {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Shield Generators";
			this.cost = 20;
			this.access = 17;
			this.contains = new ByTable(new object [] { typeof(Obj_Machinery_Shieldwallgen), typeof(Obj_Machinery_Shieldwallgen), typeof(Obj_Machinery_Shieldwallgen), typeof(Obj_Machinery_Shieldwallgen) });
			this.crate_name = "shield generators crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Secure);
		}

	}

}