// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Human_Equip : Obj_Screen_Human {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "act_equip";
		}

		public Obj_Screen_Human_Equip ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: human.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob H = null;

			
			if ( Task13.User.loc is Obj_Mecha ) {
				return true;
			}
			H = Task13.User;
			H.__CallVerb("quick-equip" );
			return false;
		}

	}

}