// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Virus : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Virus crate";
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_Virusdish_Random), typeof(Obj_Item_Weapon_Virusdish_Random), typeof(Obj_Item_Weapon_Virusdish_Random), typeof(Obj_Item_Weapon_Virusdish_Random) });
			this.cost = 25;
			this.containertype = "/obj/structure/closet/crate/secure";
			this.containername = "Virus crate";
			this.access = 40;
			this.group = "Medical";
		}

	}

}