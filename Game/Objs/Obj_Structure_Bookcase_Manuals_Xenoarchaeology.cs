// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bookcase_Manuals_Xenoarchaeology : Obj_Structure_Bookcase_Manuals {

		// Function from file: misc.dm
		public Obj_Structure_Bookcase_Manuals_Xenoarchaeology ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Weapon_Book_Manual_Excavation( this );
			new Obj_Item_Weapon_Book_Manual_MassSpectrometry( this );
			new Obj_Item_Weapon_Book_Manual_MaterialsChemistryAnalysis( this );
			new Obj_Item_Weapon_Book_Manual_AnomalyTesting( this );
			new Obj_Item_Weapon_Book_Manual_AnomalySpectroscopy( this );
			new Obj_Item_Weapon_Book_Manual_Stasis( this );
			this.update_icon();
			return;
		}

	}

}