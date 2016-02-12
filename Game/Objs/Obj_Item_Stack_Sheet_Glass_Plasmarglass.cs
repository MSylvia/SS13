// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet_Glass_Plasmarglass : Obj_Item_Stack_Sheet_Glass {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "reinforced plasma glass sheet";
			this.sname = "plasma_ref";
			this.starting_materials = new ByTable().Set( "$iron", 1875 ).Set( "$glass", 3750 ).Set( "$plasma", 2000 );
			this.melt_temperature = 2283.14990234375;
			this.origin_tech = "materials=4;plasmatech=2";
			this.created_window = typeof(Obj_Structure_Window_Reinforced_Plasma);
			this.full_window = typeof(Obj_Structure_Window_Full_Reinforced_Plasma);
			this.windoor = typeof(Obj_Structure_WindoorAssembly_Plasma);
			this.perunit = 2875;
			this.reinforced = true;
			this.glass_quality = 121;
			this.shealth = 30;
			this.shard_type = typeof(Obj_Item_Weapon_Shard_Plasma);
			this.icon_state = "sheet-plasmarglass";
		}

		public Obj_Item_Stack_Sheet_Glass_Plasmarglass ( dynamic newloc = null, int? amount = null ) : base( (object)(newloc), amount ) {
			
		}

	}

}