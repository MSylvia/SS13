// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Spell : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 6 ).Set( "vitamin", 10 );
			this.icon_state = "spellburger";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Spell ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}