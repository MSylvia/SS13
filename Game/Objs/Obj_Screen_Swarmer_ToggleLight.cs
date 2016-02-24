// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Swarmer_ToggleLight : Obj_Screen_Swarmer {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "ui_light";
		}

		public Obj_Screen_Swarmer_ToggleLight ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: swarmer.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob S = null;

			
			if ( Task13.User is Mob_Living_SimpleAnimal_Hostile_Swarmer ) {
				S = Task13.User;
				((dynamic)S).ToggleLight();
			}
			return false;
		}

	}

}