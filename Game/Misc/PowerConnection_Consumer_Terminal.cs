// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class PowerConnection_Consumer_Terminal : PowerConnection_Consumer {

		public Obj_Machinery_Power_Terminal terminal = null;

		public PowerConnection_Consumer_Terminal ( Obj_Machinery_Media_Transmitter_Broadcast loc = null, int parent = 0 ) : base( loc, parent ) {
			
		}

		// Function from file: components.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.terminal != null ) {
				this.terminal.master = null;
				this.terminal = null;
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: components.dm
		public override bool connect(  ) {
			dynamic d = null;
			Tile T = null;
			Obj_Machinery_Power_Terminal term = null;

			base.connect();

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.cardinal )) {
				d = _b;
				
				T = Map13.GetStep( this.parent, Convert.ToInt32( d ) );

				foreach (dynamic _a in Lang13.Enumerate( T, typeof(Obj_Machinery_Power_Terminal) )) {
					term = _a;
					

					if ( term != null && term.dir == Num13.Rotate( d, 180 ) ) {
						this.terminal = term;
						break;
					}
				}

				if ( this.terminal != null ) {
					break;
				}
			}

			if ( this.terminal != null ) {
				this.terminal.master = this.parent;
			}
			return false;
		}

		// Function from file: components.dm
		public override bool use_power( dynamic amount = null, bool? chan = null ) {
			this.add_load( amount );
			return false;
		}

	}

}