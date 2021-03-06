// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Emergency_Specialops : SupplyPack_Emergency {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Special Ops Supplies";
			this.hidden = true;
			this.cost = 20;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Storage_Box_Emps), 
				typeof(Obj_Item_Weapon_Grenade_Smokebomb), 
				typeof(Obj_Item_Weapon_Grenade_Smokebomb), 
				typeof(Obj_Item_Weapon_Grenade_Smokebomb), 
				typeof(Obj_Item_Weapon_Pen_Sleepy), 
				typeof(Obj_Item_Weapon_Grenade_ChemGrenade_Incendiary)
			 });
			this.crate_name = "special ops crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate);
		}

	}

}