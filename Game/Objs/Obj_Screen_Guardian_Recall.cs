// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Guardian_Recall : Obj_Screen_Guardian {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "recall";
		}

		public Obj_Screen_Guardian_Recall ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: guardian.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob G = null;

			
			if ( Task13.User is Mob_Living_SimpleAnimal_Hostile_Guardian ) {
				G = Task13.User;
				((Mob_Living_SimpleAnimal_Hostile_Guardian)G).Recall();
			}
			return false;
		}

	}

}