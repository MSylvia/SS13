// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Cream : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.bonus_reagents = new ByTable().Set( "nutriment", 2 ).Set( "vitamin", 2 );
			this.list_reagents = new ByTable().Set( "nutriment", 6 ).Set( "banana", 5 ).Set( "vitamin", 2 );
			this.icon_state = "pie";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Cream ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: snacks_pie.dm
		public override bool throw_impact( dynamic target = null, Mob_Living_Carbon thrower = null ) {
			dynamic T = null;

			
			if ( !base.throw_impact( (object)(target), thrower ) ) {
				T = GlobalFuncs.get_turf( target );
				new Obj_Effect_Decal_Cleanable_PieSmudge( T );
				this.reagents.reaction( target, GlobalVars.TOUCH );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

	}

}