// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechExtinguisher : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Engineering Equipment (Extinguisher)";
			this.id = "mech_extinguisher";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_Extinguisher);
			this.materials = new ByTable().Set( "$metal", 10000 );
			this.construction_time = 100;
			this.category = new ByTable(new object [] { "Exosuit Equipment" });
		}

	}

}