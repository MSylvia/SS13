// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Costume_Sexyclown : Obj_Effect_Landmark_Costume {

		// Function from file: landmarks.dm
		public Obj_Effect_Landmark_Costume_Sexyclown ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Mask_Gas_Sexyclown( this.loc );
			new Obj_Item_Clothing_Under_Rank_Clown_Sexy( this.loc );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}