// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Mining : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mining Equipment";
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Pickaxe_Drill), 
				typeof(Obj_Item_Weapon_Pickaxe), 
				typeof(Obj_Item_Weapon_Pickaxe), 
				typeof(Obj_Item_Device_Flashlight_Lantern), 
				typeof(Obj_Item_Device_Flashlight_Lantern), 
				typeof(Obj_Item_Device_Flashlight_Lantern), 
				typeof(Obj_Item_Device_MiningScanner), 
				typeof(Obj_Item_Weapon_Storage_Bag_Ore), 
				typeof(Obj_Item_Weapon_Storage_Bag_Ore), 
				typeof(Obj_Item_Weapon_Storage_Bag_Ore)
			 });
			this.cost = 20;
			this.containertype = typeof(Obj_Structure_Closet_Crate);
			this.containername = "Mining Equipment Crate";
			this.access = 48;
		}

	}

}