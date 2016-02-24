// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Mine_Pickup_Healing : Obj_Effect_Mine_Pickup {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.color = "blue";
		}

		public Obj_Effect_Mine_Pickup_Healing ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mines.dm
		public override void mineEffect( Ent_Dynamic victim = null ) {
			
			if ( !Lang13.Bool( ((dynamic)victim).client ) || !( victim is Mob_Living_Carbon ) ) {
				return;
			}
			((dynamic)victim).WriteMsg( "<span class='notice'>You feel great!</span>" );
			((Mob_Living)victim).revive();
			return;
		}

	}

}