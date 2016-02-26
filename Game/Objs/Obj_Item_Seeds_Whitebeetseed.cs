// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Whitebeetseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "whitebeet";
			this.plantname = "White-Beet Plants";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Whitebeet);
			this.lifespan = 60;
			this.endurance = 50;
			this.maturation = 6;
			this.production = 6;
			this.yield = 6;
			this.oneharvest = true;
			this.potency = 10;
			this.growthstages = 6;
			this.mutatelist = new ByTable(new object [] { typeof(Obj_Item_Seeds_Redbeetseed) });
			this.icon_state = "seed-whitebeet";
		}

		public Obj_Item_Seeds_Whitebeetseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}