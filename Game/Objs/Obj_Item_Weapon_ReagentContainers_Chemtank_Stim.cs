// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Chemtank_Stim : Obj_Item_Weapon_ReagentContainers_Chemtank {

		// Function from file: watertank.dm
		public Obj_Item_Weapon_ReagentContainers_Chemtank_Stim ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.reagents.add_reagent( "stimulants_longterm", 300 );
			this.update_filling();
			return;
		}

	}

}