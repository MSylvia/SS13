// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Sterile : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sterile equipment crate";
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Clothing_Under_Rank_Medical_Green), 
				typeof(Obj_Item_Clothing_Under_Rank_Medical_Green), 
				typeof(Obj_Item_Weapon_Storage_Box_Masks), 
				typeof(Obj_Item_Weapon_Storage_Box_Gloves)
			 });
			this.cost = 15;
			this.containertype = "/obj/structure/closet/crate";
			this.containername = "Sterile equipment crate";
			this.group = "Medical";
		}

	}

}