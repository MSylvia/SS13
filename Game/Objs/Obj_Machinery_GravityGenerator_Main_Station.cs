// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_GravityGenerator_Main_Station : Obj_Machinery_GravityGenerator_Main {

		public Obj_Machinery_GravityGenerator_Main_Station ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: gravitygenerator.dm
		public override void initialize(  ) {
			this.setup_parts();
			this.middle.overlays.Add( "activated" );
			this.update_list();
			return;
		}

	}

}