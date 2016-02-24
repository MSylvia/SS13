// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Pulse : Obj_Item_Weapon_Gun_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 4;
			this.force = 10;
			this.slot_flags = 1024;
			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_Laser_Pulse), typeof(Obj_Item_AmmoCasing_Energy_Electrode), typeof(Obj_Item_AmmoCasing_Energy_Laser) });
			this.cell_type = "/obj/item/weapon/stock_parts/cell/pulse";
			this.icon_state = "pulse";
		}

		public Obj_Item_Weapon_Gun_Energy_Pulse ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: pulse.dm
		public override double emp_act( int severity = 0 ) {
			return 0;
		}

	}

}