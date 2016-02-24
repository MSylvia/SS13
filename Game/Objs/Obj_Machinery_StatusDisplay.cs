// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_StatusDisplay : Obj_Machinery {

		public int mode = 1;
		public string picture_state = null;
		public string message1 = "";
		public string message2 = "";
		public int index1 = 0;
		public int index2 = 0;
		public double frequency = 1435;
		public bool supply_display = false;
		public bool friendc = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 10;
			this.icon = "icons/obj/status_display.dmi";
			this.icon_state = "frame";
		}

		// Function from file: status_display.dm
		public Obj_Machinery_StatusDisplay ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.add_object( this, this.frequency );
			}
			return;
		}

		// Function from file: status_display.dm
		public override bool receive_signal( Signal signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			
			dynamic _a = signal.data["command"]; // Was a switch-case, sorry for the mess.
			if ( _a=="blank" ) {
				this.mode = 0;
			} else if ( _a=="shuttle" ) {
				this.mode = 1;
			} else if ( _a=="message" ) {
				this.mode = 2;
				this.set_message( signal.data["msg1"], signal.data["msg2"] );
			} else if ( _a=="alert" ) {
				this.mode = 3;
				this.set_picture( signal.data["picture_state"] );
			} else if ( _a=="supply" ) {
				
				if ( this.supply_display ) {
					this.mode = 4;
				}
			}
			return false;
		}

		// Function from file: status_display.dm
		public override double examine( dynamic user = null ) {
			double _default = 0;

			_default = base.examine( (object)(user) );

			switch ((int)( this.mode )) {
				case 1:
				case 2:
				case 4:
					user.WriteMsg( "The display says:<br>	<xmp>" + this.message1 + "</xmp><br>	<xmp>" + this.message2 + "</xmp>" );
					break;
			}
			return _default;
		}

		// Function from file: status_display.dm
		public void remove_display(  ) {
			
			if ( this.overlays.len != 0 ) {
				this.overlays.Cut();
			}

			if ( Lang13.Bool( this.maptext ) ) {
				this.maptext = "";
			}
			return;
		}

		// Function from file: status_display.dm
		public string get_supply_shuttle_timer(  ) {
			double timeleft = 0;

			timeleft = GlobalVars.SSshuttle.supply.timeLeft();

			if ( timeleft > 0 ) {
				return "" + GlobalFuncs.add_zero( String13.NumberToString( timeleft / 60 % 60 ), 2 ) + ":" + GlobalFuncs.add_zero( String13.NumberToString( timeleft % 60 ), 2 );
			}
			return "00:00";
		}

		// Function from file: status_display.dm
		public string get_shuttle_timer(  ) {
			double timeleft = 0;

			timeleft = GlobalVars.SSshuttle.emergency.timeLeft();

			if ( timeleft > 0 ) {
				return "" + GlobalFuncs.add_zero( String13.NumberToString( timeleft / 60 % 60 ), 2 ) + ":" + GlobalFuncs.add_zero( String13.NumberToString( timeleft % 60 ), 2 );
			}
			return "00:00";
		}

		// Function from file: status_display.dm
		public void update_display( string line1 = null, string line2 = null ) {
			string new_text = null;

			new_text = "<div style=\"font-size:" + "5pt" + ";color:" + "#09f" + ";font:'" + "Arial Black" + "';text-align:center;\" valign=\"top\">" + line1 + "<br>" + line2 + "</div>";

			if ( this.maptext != new_text ) {
				this.maptext = new_text;
			}
			return;
		}

		// Function from file: status_display.dm
		public void set_picture( string state = null ) {
			this.picture_state = state;
			this.remove_display();
			this.overlays.Add( new Image( "icons/obj/status_display.dmi", null, this.picture_state ) );
			return;
		}

		// Function from file: status_display.dm
		public void set_message( dynamic m1 = null, dynamic m2 = null ) {
			
			if ( Lang13.Bool( m1 ) ) {
				this.index1 = Lang13.Length( m1 ) > 5 ?1:0;
				this.message1 = m1;
			} else {
				this.message1 = "";
				this.index1 = 0;
			}

			if ( Lang13.Bool( m2 ) ) {
				this.index2 = Lang13.Length( m2 ) > 5 ?1:0;
				this.message2 = m2;
			} else {
				this.message2 = "";
				this.index2 = 0;
			}
			return;
		}

		// Function from file: status_display.dm
		public void update(  ) {
			string line1 = null;
			string line2 = null;
			string line12 = null;
			string line22 = null;
			int message1_len = 0;
			int message2_len = 0;
			string line13 = null;
			string line23 = null;

			
			if ( this.friendc && this.mode != 4 ) {
				this.set_picture( "ai_friend" );
				return;
			}

			switch ((int)( this.mode )) {
				case 0:
					this.remove_display();
					break;
				case 1:
					
					if ( GlobalVars.SSshuttle.emergency.timer != 0 ) {
						line1 = null;
						line2 = this.get_shuttle_timer();

						switch ((int)( GlobalVars.SSshuttle.emergency.mode )) {
							case 1:
								line1 = "-RCL-";
								break;
							case 2:
								line1 = "-ETA-";
								break;
							case 3:
								line1 = "-ETD-";
								break;
							case 5:
								line1 = "-ESC-";
								break;
							case 4:
								line1 = "-ERR-";
								line2 = "??:??";
								break;
						}

						if ( Lang13.Length( line2 ) > 5 ) {
							line2 = "Error!";
						}
						this.update_display( line1, line2 );
					} else {
						this.remove_display();
					}
					break;
				case 2:
					line12 = null;
					line22 = null;

					if ( !( this.index1 != 0 ) ) {
						line12 = this.message1;
					} else {
						line12 = String13.SubStr( this.message1 + "|" + this.message1, this.index1, this.index1 + 5 );
						message1_len = Lang13.Length( this.message1 );
						this.index1 += 2;

						if ( this.index1 > message1_len ) {
							this.index1 -= message1_len;
						}
					}

					if ( !( this.index2 != 0 ) ) {
						line22 = this.message2;
					} else {
						line22 = String13.SubStr( this.message2 + "|" + this.message2, this.index2, this.index2 + 5 );
						message2_len = Lang13.Length( this.message2 );
						this.index2 += 2;

						if ( this.index2 > message2_len ) {
							this.index2 -= message2_len;
						}
					}
					this.update_display( line12, line22 );
					break;
				case 4:
					line13 = null;
					line23 = null;

					if ( GlobalVars.SSshuttle.supply.mode == 0 ) {
						
						if ( GlobalVars.SSshuttle.supply.z == 1 ) {
							line13 = "CARGO";
							line23 = "Docked";
						}
					} else {
						line13 = "CARGO";
						line23 = this.get_supply_shuttle_timer();

						if ( Lang13.Length( line23 ) > 5 ) {
							line23 = "Error";
						}
					}
					this.update_display( line13, line23 );
					break;
			}
			return;
		}

		// Function from file: status_display.dm
		public override double emp_act( int severity = 0 ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				base.emp_act( severity );
				return 0;
			}
			this.set_picture( "ai_bsod" );
			base.emp_act( severity );
			return 0;
		}

		// Function from file: status_display.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( ( this.stat & 2 ) != 0 ) {
				this.remove_display();
				return null;
			}
			this.update();
			return null;
		}

		// Function from file: status_display.dm
		public override dynamic Destroy(  ) {
			
			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.remove_object( this, this.frequency );
			}
			return base.Destroy();
		}

		// Function from file: status_display.dm
		public override void initialize(  ) {
			
			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.add_object( this, this.frequency );
			}
			return;
		}

	}

}