// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Ghost_ReenterCorpse : Obj_Screen_Ghost {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "reenter_corpse";
		}

		public Obj_Screen_Ghost_ReenterCorpse ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ghost.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob G = null;

			G = Task13.User;
			((Mob_Dead_Observer)G).reenter_corpse();
			return false;
		}

	}

}