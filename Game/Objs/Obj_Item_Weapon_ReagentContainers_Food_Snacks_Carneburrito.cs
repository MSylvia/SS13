// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Carneburrito : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 2 ).Set( "vitamin", 1 );
			this.list_reagents = new ByTable().Set( "nutriment", 5 ).Set( "vitamin", 1 );
			this.filling_color = "#A0522D";
			this.icon_state = "carneburrito";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Carneburrito ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}