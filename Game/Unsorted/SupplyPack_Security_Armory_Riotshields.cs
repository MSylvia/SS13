// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Security_Armory_Riotshields : SupplyPack_Security_Armory {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Riot Shields Crate";
			this.cost = 20;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_Shield_Riot), typeof(Obj_Item_Weapon_Shield_Riot), typeof(Obj_Item_Weapon_Shield_Riot) });
			this.crate_name = "riot shields crate";
		}

	}

}