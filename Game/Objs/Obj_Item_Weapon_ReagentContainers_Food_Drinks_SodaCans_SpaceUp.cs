// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_SpaceUp : Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "space_up", 30 );
			this.icon_state = "space-up";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_SpaceUp ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}