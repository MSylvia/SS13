// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Smartfridge_Drinks : Obj_Machinery_Smartfridge {

		public Obj_Machinery_Smartfridge_Drinks ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: smartfridge.dm
		public override bool accept_check( dynamic O = null ) {
			
			if ( !( O is Obj_Item_Weapon_ReagentContainers ) || !Lang13.Bool( O.reagents ) || !( O.reagents.reagent_list.len != 0 ) ) {
				return false;
			}

			if ( O is Obj_Item_Weapon_ReagentContainers_Glass || O is Obj_Item_Weapon_ReagentContainers_Food_Drinks || O is Obj_Item_Weapon_ReagentContainers_Food_Condiment ) {
				return true;
			}
			return false;
		}

	}

}