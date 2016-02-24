// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Bananaseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "banana";
			this.plantname = "Banana Tree";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Banana);
			this.lifespan = 50;
			this.endurance = 30;
			this.maturation = 6;
			this.production = 6;
			this.yield = 3;
			this.potency = 10;
			this.growthstages = 6;
			this.mutatelist = new ByTable(new object [] { typeof(Obj_Item_Seeds_Mimanaseed) });
			this.icon_state = "seed-banana";
		}

		public Obj_Item_Seeds_Bananaseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}