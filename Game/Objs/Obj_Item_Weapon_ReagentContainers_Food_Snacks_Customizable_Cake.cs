// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable_Cake : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ingMax = 6;
			this.slice_path = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cakeslice_Custom);
			this.slices_num = 5;
			this.icon = "icons/obj/food/piecake.dmi";
			this.icon_state = "plaincake";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable_Cake ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}