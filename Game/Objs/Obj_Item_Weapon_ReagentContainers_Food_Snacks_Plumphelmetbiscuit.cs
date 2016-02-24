// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Plumphelmetbiscuit : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 1 );
			this.list_reagents = new ByTable().Set( "nutriment", 5 );
			this.filling_color = "#F0E68C";
			this.icon_state = "phelmbiscuit";
		}

		// Function from file: snacks_pastry.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Plumphelmetbiscuit ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Rand13.PercentChance( 10 ) ) {
				this.name = "exceptional plump helmet biscuit";
				this.desc = "Microwave is taken by a fey mood! It has cooked an exceptional plump helmet biscuit!";
				this.reagents.add_reagent( "omnizine", 5 );
				this.bonus_reagents = new ByTable().Set( "omnizine", 5 ).Set( "nutriment", 1 ).Set( "vitamin", 1 );
			}
			return;
		}

	}

}