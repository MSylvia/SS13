// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spidereggs : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "nutriment", 2 ).Set( "toxin", 2 );
			this.filling_color = "#008000";
			this.icon_state = "spidereggs";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spidereggs ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}