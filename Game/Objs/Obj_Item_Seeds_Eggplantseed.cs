// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Eggplantseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "eggplant";
			this.plantname = "Eggplants";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Eggplant);
			this.lifespan = 25;
			this.endurance = 15;
			this.maturation = 6;
			this.production = 6;
			this.yield = 2;
			this.potency = 20;
			this.growthstages = 6;
			this.mutatelist = new ByTable(new object [] { typeof(Obj_Item_Seeds_Eggyseed) });
			this.icon_state = "seed-eggplant";
		}

		public Obj_Item_Seeds_Eggplantseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}