// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Masks : Obj_Structure_Closet {

		// Function from file: fitness.dm
		public Obj_Structure_Closet_Masks ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Mask_Luchador( this );
			new Obj_Item_Clothing_Mask_Luchador_Rudos( this );
			new Obj_Item_Clothing_Mask_Luchador_Tecnicos( this );
			return;
		}

	}

}