// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse_FacehugCorpse : Obj_Effect_Landmark_Corpse {

		public Obj_Effect_Landmark_Corpse_FacehugCorpse ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: corpse.dm
		public override void createCorpse( bool death = false, string ckey = null ) {
			Obj_Item_Clothing_Mask_Facehugger O = null;

			O = new Obj_Item_Clothing_Mask_Facehugger( this.loc );
			O.name = this.name;
			O.Die();
			GlobalFuncs.qdel( this );
			return;
		}

	}

}