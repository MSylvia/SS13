// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Ammo_Smg_Bag : UplinkItem_Ammo_Smg {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = ".45 Ammo Duffelbag";
			this.desc = "A duffelbag filled with enough .45 ammo to supply an entire team, at a discounted price.";
			this.item = typeof(Obj_Item_Weapon_Storage_Backpack_Dufflebag_Syndie_Ammo_Smg);
			this.cost = 20;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}