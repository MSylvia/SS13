// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Swarmer_Barricade : Obj_Screen_Swarmer {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "ui_barricade";
		}

		public Obj_Screen_Swarmer_Barricade ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: swarmer.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob S = null;

			
			if ( Task13.User is Mob_Living_SimpleAnimal_Hostile_Swarmer ) {
				S = Task13.User;
				((Mob_Living_SimpleAnimal_Hostile_Swarmer)S).CreateBarricade();
			}
			return false;
		}

	}

}