// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Readybutton : Obj_Machinery {

		public bool ready = false;
		public dynamic currentarea = null;
		public bool eventstarted = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 2;
			this.active_power_usage = 6;
			this.power_channel = 3;
			this.icon = "icons/obj/monitors.dmi";
			this.icon_state = "auth_off";
		}

		// Function from file: items.dm
		public Obj_Machinery_Readybutton ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: items.dm
		public void begin_event(  ) {
			Obj_Structure_Window W = null;
			dynamic M = null;

			this.eventstarted = true;

			foreach (dynamic _a in Lang13.Enumerate( this.currentarea, typeof(Obj_Structure_Window) )) {
				W = _a;
				

				if ( Lang13.Bool( W.flags & 128 ) ) {
					GlobalFuncs.qdel( W );
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( this.currentarea )) {
				M = _b;
				
				M.WriteMsg( "FIGHT!" );
			}
			return;
		}

		// Function from file: items.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.ready ) {
				this.icon_state = "auth_on";
			} else {
				this.icon_state = "auth_off";
			}
			return false;
		}

		// Function from file: items.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			int numbuttons = 0;
			int numready = 0;
			Obj_Machinery_Readybutton button = null;

			
			if ( Lang13.Bool( a.stat ) || ( this.stat & 3 ) != 0 ) {
				a.WriteMsg( "<span class='warning'>This device is not powered!</span>" );
				return null;
			}
			this.currentarea = GlobalFuncs.get_area( this.loc );

			if ( !Lang13.Bool( this.currentarea ) ) {
				GlobalFuncs.qdel( this );
			}

			if ( this.eventstarted ) {
				Task13.User.WriteMsg( "<span class='warning'>The event has already begun!</span>" );
				return null;
			}
			this.ready = !this.ready;
			this.update_icon();
			numbuttons = 0;
			numready = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.currentarea, typeof(Obj_Machinery_Readybutton) )) {
				button = _a;
				
				numbuttons++;

				if ( button.ready ) {
					numready++;
				}
			}

			if ( numbuttons == numready ) {
				this.begin_event();
			}
			return null;
		}

		// Function from file: items.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			user.WriteMsg( "The device is a solid button, there's nothing you can do with it!" );
			return null;
		}

		// Function from file: items.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			a.WriteMsg( "<span class='warning'>You are too primitive to use this device!</span>" );
			return null;
		}

		// Function from file: items.dm
		public override dynamic attack_ai( dynamic user = null ) {
			user.WriteMsg( "The station AI is not to interact with these devices" );
			return null;
		}

	}

}