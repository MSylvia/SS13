// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Spider : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "nutriment", 3 ).Set( "toxin", 3 ).Set( "vitamin", 1 );
			this.filling_color = "#7CFC00";
			this.cooked_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Steak_Spider);
			this.slice_path = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Rawcutlet_Spider);
			this.icon_state = "spidermeat";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Spider ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}