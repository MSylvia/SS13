// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_VendingRefill_Autodrobe : Obj_Item_Weapon_VendingRefill {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.machine_name = "AutoDrobe";
			this.charges = new ByTable(new object [] { 27, 2, 3 });
			this.init_charges = new ByTable(new object [] { 27, 2, 3 });
			this.icon_state = "refill_costume";
		}

		public Obj_Item_Weapon_VendingRefill_Autodrobe ( dynamic amt = null ) : base( (object)(amt) ) {
			
		}

	}

}