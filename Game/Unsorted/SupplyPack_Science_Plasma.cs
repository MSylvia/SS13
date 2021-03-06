// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Science_Plasma : SupplyPack_Science {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Plasma Assembly Crate";
			this.cost = 10;
			this.access = 8;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Tank_Internals_Plasma), 
				typeof(Obj_Item_Weapon_Tank_Internals_Plasma), 
				typeof(Obj_Item_Weapon_Tank_Internals_Plasma), 
				typeof(Obj_Item_Device_Assembly_Igniter), 
				typeof(Obj_Item_Device_Assembly_Igniter), 
				typeof(Obj_Item_Device_Assembly_Igniter), 
				typeof(Obj_Item_Device_Assembly_ProxSensor), 
				typeof(Obj_Item_Device_Assembly_ProxSensor), 
				typeof(Obj_Item_Device_Assembly_ProxSensor), 
				typeof(Obj_Item_Device_Assembly_Timer), 
				typeof(Obj_Item_Device_Assembly_Timer), 
				typeof(Obj_Item_Device_Assembly_Timer)
			 });
			this.crate_name = "plasma assembly crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Secure_Plasma);
		}

	}

}