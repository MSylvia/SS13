// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Blob_BlobHelp : Obj_Screen_Blob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "ui_help";
		}

		public Obj_Screen_Blob_BlobHelp ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: blob_overmind.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob B = null;

			
			if ( Task13.User is Mob_Camera_Blob ) {
				B = Task13.User;
				((Mob_Camera_Blob)B).blob_help();
			}
			return false;
		}

	}

}