// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_StealthyTools_Stimpack : UplinkItem_StealthyTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Stimpack";
			this.desc = "Stimpacks, the tool of many great heroes, make you nearly immune to stuns and knockdowns for about 5 minutes after injection.";
			this.item = typeof(Obj_Item_Weapon_ReagentContainers_Syringe_Stimulants);
			this.cost = 5;
			this.surplus = 90;
		}

	}

}