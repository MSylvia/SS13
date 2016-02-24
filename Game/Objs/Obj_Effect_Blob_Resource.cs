// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Blob_Resource : Obj_Effect_Blob {

		public int resource_delay = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 60;
			this.maxhealth = 60;
			this.point_return = 15;
			this.icon_state = "blob_resource";
		}

		public Obj_Effect_Blob_Resource ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: resource.dm
		public override bool Be_Pulsed(  ) {
			bool _default = false;

			_default = base.Be_Pulsed();

			if ( this.resource_delay > Game13.time ) {
				return _default;
			}
			Icon13.Flick( "blob_resource_glow", this );
			this.resource_delay = Game13.time + 45;

			if ( this.overmind != null ) {
				this.overmind.add_points( 1 );
			}
			return _default;
		}

	}

}