// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Xeno : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 2 ).Set( "vitamin", 6 );
			this.icon_state = "xburger";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Xeno ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}