// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Slimecake : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slice_path = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cakeslice_Slimecake);
			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 3 );
			this.icon_state = "slimecake";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Slimecake ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}