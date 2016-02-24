// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Glowshroom : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "glowshroom";
			this.plantname = "Glowshrooms";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Glowshroom);
			this.lifespan = 120;
			this.endurance = 30;
			this.maturation = 15;
			this.production = 1;
			this.yield = 3;
			this.potency = 30;
			this.oneharvest = true;
			this.growthstages = 4;
			this.plant_type = 2;
			this.rarity = 20;
			this.mutatelist = new ByTable(new object [] { typeof(Obj_Item_Seeds_Glowcap) });
			this.icon_state = "mycelium-glowshroom";
		}

		public Obj_Item_Seeds_Glowshroom ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}