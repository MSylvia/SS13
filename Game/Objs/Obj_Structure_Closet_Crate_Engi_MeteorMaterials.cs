// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Crate_Engi_MeteorMaterials : Obj_Structure_Closet_Crate_Engi {

		// Function from file: meteor_supply.dm
		public Obj_Structure_Closet_Crate_Engi_MeteorMaterials ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Metal), this, 50 );
			GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Metal), this, 50 );
			GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Wood), this, 50 );
			GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Wood), this, 50 );
			GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Glass_Rglass), this, 50 );
			GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Glass_Plasmarglass), this, 50 );
			return;
		}

	}

}