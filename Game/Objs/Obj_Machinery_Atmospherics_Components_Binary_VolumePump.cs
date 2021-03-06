// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Components_Binary_VolumePump : Obj_Machinery_Atmospherics_Components_Binary {

		public double? on = 0;
		public double transfer_rate = 200;
		public double frequency = 0;
		public dynamic id = null;
		public RadioFrequency radio_connection = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.can_unwrench = true;
			this.icon_state = "volpump_map";
		}

		public Obj_Machinery_Atmospherics_Components_Binary_VolumePump ( dynamic loc = null, int? process = null ) : base( (object)(loc), process ) {
			
		}

		// Function from file: volume_pump.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( !( A is Obj_Item_Weapon_Wrench ) ) {
				return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}

			if ( !( ( this.stat & 2 ) != 0 ) && Lang13.Bool( this.on ) ) {
				user.WriteMsg( "<span class='warning'>You cannot unwrench this " + this + ", turn it off first!</span>" );
				return 1;
			}
			return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
		}

		// Function from file: volume_pump.dm
		public override void power_change(  ) {
			base.power_change();
			this.update_icon();
			return;
		}

		// Function from file: volume_pump.dm
		public override bool receive_signal( Signal signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			double? old_on = null;
			dynamic air1 = null;

			
			if ( !Lang13.Bool( signal.data["tag"] ) || signal.data["tag"] != this.id || signal.data["sigtype"] != "command" ) {
				return false;
			}
			old_on = this.on;

			if ( signal.data.Contains( "power" ) ) {
				this.on = String13.ParseNumber( signal.data["power"] );
			}

			if ( signal.data.Contains( "power_toggle" ) ) {
				this.on = !Lang13.Bool( this.on ) ?1:0;
			}

			if ( signal.data.Contains( "set_transfer_rate" ) ) {
				air1 = this.airs[1];
				this.transfer_rate = Num13.MaxInt( 0, Num13.MinInt( ((int)( String13.ParseNumber( signal.data["set_transfer_rate"] ) ??0 )), Convert.ToInt32( air1.volume ) ) );
			}

			if ( this.on != old_on ) {
				this.investigate_log( "was turned " + ( Lang13.Bool( this.on ) ? "on" : "off" ) + " by a remote signal", "atmos" );
			}

			if ( signal.data.Contains( "status" ) ) {
				this.broadcast_status();
				return false;
			}
			this.broadcast_status();
			this.update_icon();
			return false;
		}

		// Function from file: volume_pump.dm
		public override int? ui_act( string action = null, ByTable _params = null, Tgui ui = null, UiState state = null ) {
			int? _default = null;

			dynamic rate = null;

			
			if ( Lang13.Bool( base.ui_act( action, _params, ui, state ) ) ) {
				return _default;
			}

			switch ((string)( action )) {
				case "power":
					this.on = !Lang13.Bool( this.on ) ?1:0;
					this.investigate_log( "was turned " + ( Lang13.Bool( this.on ) ? "on" : "off" ) + " by " + GlobalFuncs.key_name( Task13.User ), "atmos" );
					_default = GlobalVars.TRUE;
					break;
				case "rate":
					rate = _params["rate"];

					if ( rate == "max" ) {
						rate = 200;
						_default = GlobalVars.TRUE;
					} else if ( rate == "input" ) {
						rate = Interface13.Input( "New transfer rate (0-" + 200 + " L/s):", this.name, this.transfer_rate, null, null, InputType.Num | InputType.Null );

						if ( !( rate == null ) && !Lang13.Bool( base.ui_act( action, _params, ui, state ) ) ) {
							_default = GlobalVars.TRUE;
						}
					} else if ( String13.ParseNumber( rate ) != null ) {
						rate = String13.ParseNumber( rate );
						_default = GlobalVars.TRUE;
					}

					if ( Lang13.Bool( _default ) ) {
						this.transfer_rate = Num13.MaxInt( 0, Num13.MinInt( Convert.ToInt32( rate ), 200 ) );
						this.investigate_log( "was set to " + this.transfer_rate + " L/s by " + GlobalFuncs.key_name( Task13.User ), "atmos" );
					}
					break;
			}
			this.update_icon();
			return _default;
		}

		// Function from file: volume_pump.dm
		public override void atmosinit( ByTable node_connects = null ) {
			base.atmosinit( node_connects );
			this.set_frequency( this.frequency );
			return;
		}

		// Function from file: volume_pump.dm
		public override ByTable ui_data( dynamic user = null ) {
			ByTable data = null;

			data = new ByTable();
			data["on"] = this.on;
			data["rate"] = Num13.Floor( this.transfer_rate );
			data["max_rate"] = Num13.Floor( 200 );
			return data;
		}

		// Function from file: volume_pump.dm
		public override int ui_interact( dynamic user = null, string ui_key = null, Tgui ui = null, bool? force_open = null, Tgui master_ui = null, UiState state = null ) {
			ui_key = ui_key ?? "main";
			force_open = force_open ?? false;
			state = state ?? GlobalVars.default_state;

			ui = GlobalVars.SStgui.try_update_ui( user, this, ui_key, ui, force_open );

			if ( !( ui != null ) ) {
				ui = new Tgui( user, this, ui_key, "atmos_pump", this.name, 310, 115, master_ui, state );
				ui.open();
			}
			return 0;
		}

		// Function from file: volume_pump.dm
		public bool broadcast_status(  ) {
			Signal signal = null;

			
			if ( !( this.radio_connection != null ) ) {
				return false;
			}
			signal = new Signal();
			signal.transmission_method = 1;
			signal.source = this;
			signal.data = new ByTable().Set( "tag", this.id ).Set( "device", "APV" ).Set( "power", this.on ).Set( "transfer_rate", this.transfer_rate ).Set( "sigtype", "status" );
			this.radio_connection.post_signal( this, signal );
			return true;
		}

		// Function from file: volume_pump.dm
		public void set_frequency( double new_frequency = 0 ) {
			GlobalVars.SSradio.remove_object( this, this.frequency );
			this.frequency = new_frequency;

			if ( this.frequency != 0 ) {
				this.radio_connection = GlobalVars.SSradio.add_object( this, this.frequency );
			}
			return;
		}

		// Function from file: volume_pump.dm
		public override int? process_atmos(  ) {
			GasMixture air1 = null;
			dynamic air2 = null;
			dynamic input_starting_pressure = null;
			dynamic output_starting_pressure = null;
			double? transfer_ratio = null;
			GasMixture removed = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( !Lang13.Bool( this.on ) ) {
				return 0;
			}
			air1 = this.airs[1];
			air2 = this.airs[2];
			input_starting_pressure = air1.return_pressure();
			output_starting_pressure = air2.return_pressure();

			if ( Convert.ToDouble( input_starting_pressure ) < 0.01 || Convert.ToDouble( output_starting_pressure ) > 9000 ) {
				return 1;
			}
			transfer_ratio = Num13.MinInt( 1, ((int)( this.transfer_rate / ( air1.volume ??0) )) );
			removed = air1.remove_ratio( transfer_ratio );
			air2.merge( removed );
			this.update_parents();
			return 1;
		}

		// Function from file: volume_pump.dm
		public override void update_icon_nopipes( bool? animation = null ) {
			
			if ( ( this.stat & 2 ) != 0 ) {
				this.icon_state = "volpump_off";
				return;
			}
			this.icon_state = "volpump_" + ( Lang13.Bool( this.on ) ? "on" : "off" );
			return;
		}

		// Function from file: volume_pump.dm
		public override dynamic Destroy(  ) {
			
			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.remove_object( this, this.frequency );
			}
			return base.Destroy();
		}

	}

}