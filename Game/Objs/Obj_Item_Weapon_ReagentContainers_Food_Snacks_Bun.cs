// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bun : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "nutriment", 1 );
			this.custom_food_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable_Burger);
			this.filling_color = "#CD853F";
			this.icon = "icons/obj/food/burgerbread.dmi";
			this.icon_state = "bun";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bun ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}