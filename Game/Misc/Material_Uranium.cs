// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Material_Uranium : Material {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Uranium";
			this.id = "$uranium";
			this.value = 20;
			this.oretype = typeof(Obj_Item_Weapon_Ore_Uranium);
			this.sheettype = typeof(Obj_Item_Stack_Sheet_Mineral_Uranium);
			this.cointype = typeof(Obj_Item_Weapon_Coin_Uranium);
		}

	}

}