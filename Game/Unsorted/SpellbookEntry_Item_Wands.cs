// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpellbookEntry_Item_Wands : SpellbookEntry_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Wand Assortment";
			this.desc = "A collection of wands that allow for a wide variety of utility. Wands have a limited number of charges, so be conservative in use. Comes in a handy belt.";
			this.item_path = typeof(Obj_Item_Weapon_Storage_Belt_Wands_Full);
			this.log_name = "WA";
			this.category = "Defensive";
		}

	}

}