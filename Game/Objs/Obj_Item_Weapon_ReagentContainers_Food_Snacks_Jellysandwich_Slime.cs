// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Jellysandwich_Slime : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Jellysandwich {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "slimejelly", 5 ).Set( "vitamin", 2 );
			this.list_reagents = new ByTable().Set( "nutriment", 2 ).Set( "slimejelly", 5 ).Set( "vitamin", 2 );
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Jellysandwich_Slime ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}