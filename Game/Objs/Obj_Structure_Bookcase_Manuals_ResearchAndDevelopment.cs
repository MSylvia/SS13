// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bookcase_Manuals_ResearchAndDevelopment : Obj_Structure_Bookcase_Manuals {

		// Function from file: lib_items.dm
		public Obj_Structure_Bookcase_Manuals_ResearchAndDevelopment ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Weapon_Book_Manual_ResearchAndDevelopment( this );
			this.update_icon();
			return;
		}

	}

}