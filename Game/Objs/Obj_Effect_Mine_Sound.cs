// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Mine_Sound : Obj_Effect_Mine {

		public string sound = "sound/items/bikehorn.ogg";

		public Obj_Effect_Mine_Sound ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mines.dm
		public override void mineEffect( Ent_Dynamic victim = null ) {
			GlobalFuncs.playsound( this.loc, this.sound, 100, 1 );
			return;
		}

	}

}