// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Greengrapeseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "greengrape";
			this.plantname = "Green-Grape Vine";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Grapes_Green);
			this.lifespan = 50;
			this.endurance = 25;
			this.maturation = 3;
			this.production = 5;
			this.yield = 4;
			this.potency = 10;
			this.growthstages = 2;
			this.icon_state = "seed-greengrapes";
		}

		public Obj_Item_Seeds_Greengrapeseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}