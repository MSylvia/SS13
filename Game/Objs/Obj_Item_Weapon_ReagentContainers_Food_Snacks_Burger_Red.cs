// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Red : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.color = "#DA0000FF";
			this.bonus_reagents = new ByTable().Set( "redcrayonpowder", 10 ).Set( "vitamin", 5 );
			this.icon_state = "cburger";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Red ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}