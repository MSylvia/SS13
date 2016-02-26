// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Appleseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "apple";
			this.plantname = "Apple Tree";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Apple);
			this.lifespan = 55;
			this.endurance = 35;
			this.maturation = 6;
			this.production = 6;
			this.yield = 5;
			this.potency = 10;
			this.growthstages = 6;
			this.mutatelist = new ByTable(new object [] { typeof(Obj_Item_Seeds_Goldappleseed) });
			this.icon_state = "seed-apple";
		}

		public Obj_Item_Seeds_Appleseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}