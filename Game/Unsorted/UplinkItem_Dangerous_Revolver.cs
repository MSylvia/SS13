// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Dangerous_Revolver : UplinkItem_Dangerous {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Syndicate Revolver";
			this.desc = "A brutally simple syndicate revolver that fires .357 Magnum rounds and has 7 chambers.";
			this.item = typeof(Obj_Item_Weapon_Gun_Projectile_Revolver);
			this.cost = 13;
			this.surplus = 50;
		}

	}

}