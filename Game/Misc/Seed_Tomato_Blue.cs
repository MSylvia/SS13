// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Seed_Tomato_Blue : Seed_Tomato {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "bluetomato";
			this.seed_name = "blue tomato";
			this.display_name = "blue tomato plant";
			this.products = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Bluetomato) });
			this.mutants = new ByTable(new object [] { "bluespacetomato" });
			this.packet_icon = "seed-bluetomato";
			this.plant_icon = "bluetomato";
			this.chems = new ByTable().Set( "nutriment", new ByTable(new object [] { 1, 20 }) ).Set( "lube", new ByTable(new object [] { 1, 5 }) );
			this.splat_type = typeof(Obj_Effect_Decal_Cleanable_Blood_Oil);
		}

	}

}