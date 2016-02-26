// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold4w : Obj_Machinery_Atmospherics_Pipe_HeatExchanging {

		public override int device_type
		{
			get { return 4; }
		}

		protected override void __FieldInit() {
			base.__FieldInit();

			this.initialize_directions_he = 15;
			this.icon_state = "manifold4w";
		}

		public Obj_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold4w ( dynamic loc = null, int? process = null ) : base( (object)(loc), process ) {
			
		}

		// Function from file: manifold.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			string invis = null;
			double I = 0;

			invis = ( this.invisibility != 0 ? "-f" : "" );
			this.icon_state = "manifold4w_center" + invis;
			this.overlays.Cut();

			foreach (dynamic _a in Lang13.IterateRange( 1, this.device_type )) {
				I = _a;
				

				if ( Lang13.Bool( this.nodes[I] ) ) {
					this.overlays.Add( this.getpipeimage( "icons/obj/atmospherics/pipes/heat.dmi", "manifold_intact" + invis, Map13.GetDistance( this, this.nodes[I] ) ) );
				}
			}
			return false;
		}

		// Function from file: manifold.dm
		public override void SetInitDirections(  ) {
			this.initialize_directions_he = Lang13.Initial( this, "initialize_directions_he" );
			return;
		}

	}

}