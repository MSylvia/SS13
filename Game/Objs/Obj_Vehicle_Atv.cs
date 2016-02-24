// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Vehicle_Atv : Obj_Vehicle {

		public dynamic atvcover = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.keytype = typeof(Obj_Item_Key);
			this.generic_pixel_y = 4;
			this.vehicle_move_delay = 1;
			this.icon_state = "atv";
		}

		// Function from file: atv.dm
		public Obj_Vehicle_Atv ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !( GlobalVars.atvcover != null ) ) {
				GlobalVars.atvcover = new Image( "icons/obj/vehicles.dmi", "atvcover" );
				GlobalVars.atvcover.layer = 401;
			}
			return;
		}

		// Function from file: atv.dm
		public override void handle_vehicle_layer(  ) {
			
			if ( this.dir == GlobalVars.SOUTH ) {
				this.layer = 401;
			} else {
				this.layer = GlobalVars.OBJ_LAYER;
			}
			return;
		}

		// Function from file: atv.dm
		public override void post_buckle_mob( dynamic M = null ) {
			
			if ( Lang13.Bool( this.buckled_mob ) ) {
				this.overlays.Add( GlobalVars.atvcover );
			} else {
				this.overlays.Remove( GlobalVars.atvcover );
			}
			return;
		}

	}

}