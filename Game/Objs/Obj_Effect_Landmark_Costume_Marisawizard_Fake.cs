// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Costume_Marisawizard_Fake : Obj_Effect_Landmark_Costume_Marisawizard {

		// Function from file: landmarks.dm
		public Obj_Effect_Landmark_Costume_Marisawizard_Fake ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Shoes_Sandal_Marisa( this.loc );
			new Obj_Item_Clothing_Head_Wizard_Marisa_Fake( this.loc );
			new Obj_Item_Clothing_Suit_Wizrobe_Marisa_Fake( this.loc );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}