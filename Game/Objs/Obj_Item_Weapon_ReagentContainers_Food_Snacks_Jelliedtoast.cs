// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Jelliedtoast : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.bitesize = 3;
			this.icon = "icons/obj/food/burgerbread.dmi";
			this.icon_state = "jellytoast";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Jelliedtoast ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}