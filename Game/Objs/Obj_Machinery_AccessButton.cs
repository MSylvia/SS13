// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_AccessButton : Obj_Machinery {

		public dynamic master_tag = null;
		public dynamic frequency = 1449;
		public string command = "cycle";
		public RadioFrequency radio_connection = null;
		public bool on = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.power_channel = 3;
			this.ghost_read = false;
			this.machine_flags = 128;
			this.icon = "icons/obj/airlock_machines.dmi";
			this.icon_state = "access_button_standby";
		}

		// Function from file: airlock_control.dm
		public Obj_Machinery_AccessButton ( dynamic loc = null, int ndir = 0, bool? building = null ) : base( (object)(loc) ) {
			building = building ?? false;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( building == true ) {
				this.dir = ndir;
				this.pixel_x = ( ( this.dir & 3 ) != 0 ? 0 : ( this.dir == 4 ? 24 : -24 ) );
				this.pixel_y = ( ( this.dir & 3 ) != 0 ? ( this.dir == 1 ? 24 : -24 ) : 0 );
			}
			return;
		}

		// Function from file: airlock_control.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic P = null;
			dynamic newfreq = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			}

			if ( !( Task13.User is Mob_Living_Silicon ) ) {
				
				if ( !( Task13.User.get_active_hand() is Obj_Item_Device_Multitool ) ) {
					Game13.log.WriteMsg( "## TESTING: " + "Not silicon, not using a multitool." );
					return null;
				}
			}
			P = GlobalFuncs.get_multitool( Task13.User );

			if ( Lang13.Bool( P ) ) {
				
				if ( href_list.Contains( "set_freq" ) ) {
					newfreq = this.frequency;

					if ( href_list["set_freq"] != "-1" ) {
						newfreq = String13.ParseNumber( href_list["set_freq"] );
					} else {
						newfreq = Interface13.Input( Task13.User, "Specify a new frequency (GHz). Decimals assigned automatically.", this, this.frequency, null, InputType.Num | InputType.Null );
					}

					if ( Lang13.Bool( newfreq ) ) {
						
						if ( String13.FindIgnoreCase( String13.NumberToString( Convert.ToDouble( newfreq ) ), ".", 1, 0 ) != 0 ) {
							newfreq *= 10;
						}

						if ( Convert.ToDouble( newfreq ) < 10000 ) {
							this.frequency = newfreq;
							this.initialize();
						}
					}
				}
				this.update_multitool_menu( Task13.User );
			}
			return null;
		}

		// Function from file: airlock_control.dm
		public override string multitool_menu( dynamic user = null, dynamic P = null ) {
			return new Txt( "\n		<ul>\n			<li><b>Frequency:</b> <a href=\"?src=" ).Ref( this ).str( ";set_freq=-1\">" ).item( GlobalFuncs.format_frequency( this.frequency ) ).str( " GHz</a> (<a href=\"?src=" ).Ref( this ).str( ";set_freq=" ).item( 0 ).str( "\">Reset</a>)</li>\n			" ).item( this.format_tag( "Master ID Tag", "master_tag" ) ).str( "\n			" ).item( this.format_tag( "Command", "command" ) ).str( "\n		</ul>" ).ToString();
		}

		// Function from file: airlock_control.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			this.set_frequency( this.frequency );
			return false;
		}

		// Function from file: airlock_control.dm
		public void set_frequency( dynamic new_frequency = null ) {
			GlobalVars.radio_controller.remove_object( this, this.frequency );
			this.frequency = new_frequency;
			this.radio_connection = GlobalVars.radio_controller.add_object( this, this.frequency, GlobalVars.RADIO_AIRLOCK );
			return;
		}

		// Function from file: airlock_control.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			_default = base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}

			if ( a is Obj_Item_Weapon_Screwdriver ) {
				GlobalFuncs.to_chat( b, new Txt( "You begin to pry " ).the( this ).item().str( " off the wall..." ).ToString() );

				if ( GlobalFuncs.do_after( b, this, 50 ) ) {
					GlobalFuncs.to_chat( b, new Txt( "You successfully pry " ).the( this ).item().str( " off the wall." ).ToString() );
					new Obj_Item_Mounted_Frame_AccessButton( GlobalFuncs.get_turf( this ) );
					GlobalFuncs.qdel( this );
				}
			}
			return _default;
		}

		// Function from file: airlock_control.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Game_Data signal = null;

			this.add_fingerprint( Task13.User );

			if ( !this.allowed( a ) ) {
				GlobalFuncs.to_chat( a, "<span class='warning'>Access Denied.</span>" );
			} else if ( this.radio_connection != null ) {
				signal = GlobalFuncs.getFromPool( typeof(Signal) );
				((dynamic)signal).transmission_method = 1;
				((dynamic)signal).data["tag"] = this.master_tag;
				((dynamic)signal).data["command"] = this.command;
				this.radio_connection.post_signal( this, signal, GlobalVars.RADIO_AIRLOCK, 5 );
			}
			Icon13.Flick( "access_button_cycle", this );
			return null;
		}

		// Function from file: airlock_control.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.on ) {
				this.icon_state = "access_button_standby";
			} else {
				this.icon_state = "access_button_off";
			}
			return null;
		}

		// Function from file: trash_machinery.dm
		public override dynamic cultify(  ) {
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}