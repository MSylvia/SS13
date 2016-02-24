// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cakeslice : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.list_reagents = new ByTable().Set( "nutriment", 4 ).Set( "vitamin", 1 );
			this.customfoodfilling = false;
			this.icon = "icons/obj/food/piecake.dmi";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cakeslice ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}