// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Costume_Plaguedoctor : Obj_Effect_Landmark_Costume {

		// Function from file: landmarks.dm
		public Obj_Effect_Landmark_Costume_Plaguedoctor ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Suit_BioSuit_Plaguedoctorsuit( this.loc );
			new Obj_Item_Clothing_Head_Plaguedoctorhat( this.loc );
			new Obj_Item_Clothing_Mask_Gas_Plaguedoctor( this.loc );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}