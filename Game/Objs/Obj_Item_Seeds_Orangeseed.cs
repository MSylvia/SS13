// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Orangeseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "orange";
			this.plantname = "Orange Tree";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Citrus_Orange);
			this.lifespan = 60;
			this.endurance = 50;
			this.maturation = 6;
			this.production = 6;
			this.yield = 5;
			this.potency = 20;
			this.growthstages = 6;
			this.mutatelist = new ByTable(new object [] { typeof(Obj_Item_Seeds_Limeseed) });
			this.icon_state = "seed-orange";
		}

		public Obj_Item_Seeds_Orangeseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}