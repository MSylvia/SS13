// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Belt_Utility : Obj_Item_Weapon_Storage_Belt {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.can_hold = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Crowbar), 
				typeof(Obj_Item_Weapon_Screwdriver), 
				typeof(Obj_Item_Weapon_Weldingtool), 
				typeof(Obj_Item_Weapon_Wirecutters), 
				typeof(Obj_Item_Weapon_Wrench), 
				typeof(Obj_Item_Device_Multitool), 
				typeof(Obj_Item_Device_Flashlight), 
				typeof(Obj_Item_Stack_CableCoil), 
				typeof(Obj_Item_Device_TScanner), 
				typeof(Obj_Item_Device_Analyzer), 
				typeof(Obj_Item_Weapon_Extinguisher_Mini)
			 });
		}

		public Obj_Item_Weapon_Storage_Belt_Utility ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}