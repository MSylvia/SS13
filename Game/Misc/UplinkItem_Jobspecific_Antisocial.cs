// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Jobspecific_Antisocial : UplinkItem_Jobspecific {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Explosive Hug Chemical";
			this.desc = "30 units of Bicarodyne, a chemical that causes a devastating explosion when exposed to endorphins released in the body by a hug. Metabolizes quite slowly.";
			this.item = typeof(Obj_Item_Weapon_Storage_Box_SyndieKit_ExplosiveHug);
			this.cost = 4;
			this.job = new ByTable(new object [] { "Chemist", "Chief Medical Officer" });
		}

	}

}