// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_KeycardAuth : Obj_Machinery {

		public Event ev = null;
		public string v_event = "";
		public Obj_Machinery_KeycardAuth event_source = null;
		public Mob triggerer = null;
		public bool waiting = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 2;
			this.active_power_usage = 6;
			this.power_channel = 3;
			this.req_access = new ByTable(new object [] { 60 });
			this.icon = "icons/obj/monitors.dmi";
			this.icon_state = "auth_off";
		}

		// Function from file: keycard authentication.dm
		public Obj_Machinery_KeycardAuth ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.ev = GlobalVars.keycard_events.addEvent( "triggerEvent", this, "triggerEvent" );
			return;
		}

		// Function from file: keycard authentication.dm
		public void trigger_event( Mob confirmer = null ) {
			GlobalFuncs.log_game( "" + GlobalFuncs.key_name( this.triggerer ) + " triggered and " + GlobalFuncs.key_name( confirmer ) + " confirmed event " + this.v_event );
			GlobalFuncs.message_admins( "" + GlobalFuncs.key_name( this.triggerer ) + " triggered and " + GlobalFuncs.key_name( confirmer ) + " confirmed event " + this.v_event );

			switch ((string)( this.v_event )) {
				case "Red Alert":
					GlobalFuncs.set_security_level( 2 );
					GlobalFuncs.feedback_inc( "alert_keycard_auth_red", 1 );
					break;
				case "Emergency Maintenance Access":
					GlobalFuncs.make_maint_all_access();
					GlobalFuncs.feedback_inc( "alert_keycard_auth_maint", 1 );
					break;
			}
			return;
		}

		// Function from file: keycard authentication.dm
		public void eventTriggered(  ) {
			this.icon_state = "auth_off";
			this.event_source = null;
			return;
		}

		// Function from file: keycard authentication.dm
		public void triggerEvent( dynamic source = null ) {
			this.icon_state = "auth_on";
			this.event_source = source;
			GlobalFuncs.addtimer( this, "eventTriggered", 20 );
			return;
		}

		// Function from file: keycard authentication.dm
		public void eventSent(  ) {
			this.triggerer = null;
			this.v_event = "";
			this.waiting = false;
			return;
		}

		// Function from file: keycard authentication.dm
		public void sendEvent( string event_type = null ) {
			this.triggerer = Task13.User;
			this.v_event = event_type;
			this.waiting = true;
			GlobalVars.keycard_events.fireEvent( "triggerEvent", this );
			GlobalFuncs.addtimer( this, "eventSent", 20 );
			return;
		}

		// Function from file: keycard authentication.dm
		public override int? ui_act( string action = null, ByTable _params = null, Tgui ui = null, UiState state = null ) {
			int? _default = null;

			
			if ( Lang13.Bool( base.ui_act( action, _params, ui, state ) ) || this.waiting || !this.allowed( Task13.User ) ) {
				return _default;
			}

			switch ((string)( action )) {
				case "red_alert":
					
					if ( !( this.event_source != null ) ) {
						this.sendEvent( "Red Alert" );
						_default = GlobalVars.TRUE;
					}
					break;
				case "emergency_maint":
					
					if ( !( this.event_source != null ) ) {
						this.sendEvent( "Emergency Maintenance Access" );
						_default = GlobalVars.TRUE;
					}
					break;
				case "auth_swipe":
					
					if ( this.event_source != null ) {
						this.event_source.trigger_event( Task13.User );
						this.event_source = null;
						_default = GlobalVars.TRUE;
					}
					break;
			}
			return _default;
		}

		// Function from file: keycard authentication.dm
		public override int ui_status( dynamic user = null, UiState state = null ) {
			
			if ( user is Mob_Living_SimpleAnimal ) {
				user.WriteMsg( "<span class='warning'>You are too primitive to use this device!</span>" );
			} else {
				return base.ui_status( (object)(user), state );
			}
			return -1;
		}

		// Function from file: keycard authentication.dm
		public override ByTable ui_data( dynamic user = null ) {
			ByTable data = null;

			data = new ByTable();
			data["waiting"] = this.waiting;
			data["auth_required"] = ( this.event_source != null ? ((dynamic)( this.event_source.v_event )) : ((dynamic)( 0 )) );
			data["red_alert"] = ( GlobalFuncs.seclevel2num( GlobalFuncs.get_security_level() ) >= 2 ? true : false );
			data["emergency_maint"] = GlobalVars.emergency_access;
			return data;
		}

		// Function from file: keycard authentication.dm
		public override int ui_interact( dynamic user = null, string ui_key = null, Tgui ui = null, bool? force_open = null, Tgui master_ui = null, UiState state = null ) {
			ui_key = ui_key ?? "main";
			force_open = force_open ?? false;
			state = state ?? GlobalVars.physical_state;

			ui = GlobalVars.SStgui.try_update_ui( user, this, ui_key, ui, force_open );

			if ( !( ui != null ) ) {
				ui = new Tgui( user, this, ui_key, "keycard_auth", this.name, 375, 125, master_ui, state );
				ui.open();
			}
			return 0;
		}

		// Function from file: keycard authentication.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			return null;
		}

		// Function from file: keycard authentication.dm
		public override dynamic Destroy(  ) {
			dynamic _default = null;

			GlobalVars.keycard_events.clearEvent( "triggerEvent", this.ev );
			GlobalFuncs.qdel( this.ev );
			_default = base.Destroy();
			return _default;
		}

	}

}