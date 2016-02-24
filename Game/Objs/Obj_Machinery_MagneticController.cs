// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_MagneticController : Obj_Machinery {

		public double frequency = 1449;
		public bool code = false;
		public ByTable magnets = new ByTable();
		public string title = "Magnetic Control Console";
		public bool autolink = false;
		public int pathpos = 1;
		public string path = "w;e;e;w;s;n;n;s";
		public int speed = 1;
		public ByTable rpath = new ByTable();
		public bool moving = false;
		public bool looping = false;
		public RadioFrequency radio_connection = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 45;
			this.icon = "icons/obj/airlock_machines.dmi";
			this.icon_state = "airlock_control_standby";
		}

		// Function from file: magnet.dm
		public Obj_Machinery_MagneticController ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Machinery_MagneticModule M = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.autolink ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_MagneticModule) )) {
					M = _a;
					

					if ( M.freq == this.frequency && M.code == this.code ) {
						this.magnets.Add( M );
					}
				}
			}
			Task13.Schedule( 45, (Task13.Closure)(() => {
				
				if ( GlobalVars.SSradio != null ) {
					this.radio_connection = GlobalVars.SSradio.add_object( this, this.frequency, GlobalVars.RADIO_MAGNETS );
				}
				return;
			}));

			if ( Lang13.Bool( this.path ) ) {
				this.filter_path();
			}
			return;
		}

		// Function from file: magnet.dm
		public void filter_path(  ) {
			int? maximum_character = null;
			int? i = null;
			string nextchar = null;

			this.rpath = new ByTable();
			maximum_character = Num13.MinInt( 50, Lang13.Length( this.path ) );
			i = null;
			i = 1;

			while (( i ??0) <= ( maximum_character ??0)) {
				nextchar = String13.SubStr( this.path, i ??0, ( i ??0) + 1 );

				if ( !new ByTable(new object [] { ";", "&", "*", " " }).Contains( nextchar ) ) {
					this.rpath.Add( String13.SubStr( this.path, i ??0, ( i ??0) + 1 ) );
				}
				i++;
			}
			return;
		}

		// Function from file: magnet.dm
		public void MagnetMove(  ) {
			Signal signal = null;
			string nextmove = null;

			
			if ( this.looping ) {
				return;
			}

			while (this.moving && this.rpath.len >= 1) {
				
				if ( ( this.stat & 3 ) != 0 ) {
					break;
				}
				this.looping = true;
				signal = new Signal();
				signal.transmission_method = 1;
				signal.source = this;
				signal.frequency = this.frequency;
				signal.data["code"] = this.code;

				if ( this.pathpos > this.rpath.len ) {
					this.pathpos = 1;
				}
				nextmove = String13.ToUpper( this.rpath[this.pathpos] );

				if ( !new ByTable(new object [] { "N", "S", "E", "W", "C", "R" }).Contains( nextmove ) ) {
					GlobalFuncs.qdel( signal );
					break;
				}
				signal.data["command"] = nextmove;
				this.pathpos++;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.radio_connection.post_signal( this, signal, GlobalVars.RADIO_MAGNETS );
					return;
				}));

				if ( this.speed == 10 ) {
					Task13.Sleep( 1 );
				} else {
					Task13.Sleep( 12 - this.speed );
				}
			}
			this.looping = false;
			return;
		}

		// Function from file: magnet.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Signal signal = null;
			string newpath = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );

			if ( Lang13.Bool( href_list["radio-op"] ) ) {
				signal = new Signal();
				signal.transmission_method = 1;
				signal.source = this;
				signal.frequency = this.frequency;
				signal.data["code"] = this.code;

				dynamic _a = href_list["radio-op"]; // Was a switch-case, sorry for the mess.
				if ( _a=="togglepower" ) {
					signal.data["command"] = "toggle-power";
				} else if ( _a=="minuselec" ) {
					signal.data["command"] = "sub-elec";
				} else if ( _a=="pluselec" ) {
					signal.data["command"] = "add-elec";
				} else if ( _a=="minusmag" ) {
					signal.data["command"] = "sub-mag";
				} else if ( _a=="plusmag" ) {
					signal.data["command"] = "add-mag";
				}
				this.radio_connection.post_signal( this, signal, GlobalVars.RADIO_MAGNETS );
				Task13.Schedule( 1, (Task13.Closure)(() => {
					this.updateUsrDialog();
					return;
				}));
			}

			if ( Lang13.Bool( href_list["operation"] ) ) {
				
				dynamic _b = href_list["operation"]; // Was a switch-case, sorry for the mess.
				if ( _b=="plusspeed" ) {
					this.speed++;

					if ( this.speed > 10 ) {
						this.speed = 10;
					}
				} else if ( _b=="minusspeed" ) {
					this.speed--;

					if ( this.speed <= 0 ) {
						this.speed = 1;
					}
				} else if ( _b=="setpath" ) {
					newpath = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( Task13.User, "Please define a new path!", null, this.path, null, InputType.Str | InputType.Null ) ), 1, 1024 );

					if ( Lang13.Bool( newpath ) && newpath != "" ) {
						this.moving = false;
						this.path = newpath;
						this.pathpos = 1;
						this.filter_path();
					}
				} else if ( _b=="togglemoving" ) {
					this.moving = !this.moving;

					if ( this.moving ) {
						Task13.Schedule( 0, (Task13.Closure)(() => {
							this.MagnetMove();
							return;
						}));
					}
				}
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: magnet.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			string dat = null;
			int i = 0;
			Obj_Machinery_MagneticModule M = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			((Mob)a).set_machine( this );
			dat = "<B>Magnetic Control Console</B><BR><BR>";

			if ( !this.autolink ) {
				dat += new Txt( "\n		Frequency: <a href='?src=" ).Ref( this ).str( ";operation=setfreq'>" ).item( this.frequency ).str( "</a><br>\n		Code: <a href='?src=" ).Ref( this ).str( ";operation=setfreq'>" ).item( this.code ).str( "</a><br>\n		<a href='?src=" ).Ref( this ).str( ";operation=probe'>Probe Generators</a><br>\n		" ).ToString();
			}

			if ( this.magnets.len >= 1 ) {
				dat += "Magnets confirmed: <br>";
				i = 0;

				foreach (dynamic _a in Lang13.Enumerate( this.magnets, typeof(Obj_Machinery_MagneticModule) )) {
					M = _a;
					
					i++;
					dat += new Txt( "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;< [" ).item( i ).str( "] (<a href='?src=" ).Ref( this ).str( ";radio-op=togglepower'>" ).item( ( M.on ? "On" : "Off" ) ).str( "</a>) | Electricity level: <a href='?src=" ).Ref( this ).str( ";radio-op=minuselec'>-</a> " ).item( M.electricity_level ).str( " <a href='?src=" ).Ref( this ).str( ";radio-op=pluselec'>+</a>; Magnetic field: <a href='?src=" ).Ref( this ).str( ";radio-op=minusmag'>-</a> " ).item( M.magnetic_field ).str( " <a href='?src=" ).Ref( this ).str( ";radio-op=plusmag'>+</a><br>" ).ToString();
				}
			}
			dat += new Txt( "<br>Speed: <a href='?src=" ).Ref( this ).str( ";operation=minusspeed'>-</a> " ).item( this.speed ).str( " <a href='?src=" ).Ref( this ).str( ";operation=plusspeed'>+</a><br>" ).ToString();
			dat += new Txt( "Path: {<a href='?src=" ).Ref( this ).str( ";operation=setpath'>" ).item( this.path ).str( "</a>}<br>" ).ToString();
			dat += new Txt( "Moving: <a href='?src=" ).Ref( this ).str( ";operation=togglemoving'>" ).item( ( this.moving ? "Enabled" : "Disabled" ) ).str( "</a>" ).ToString();
			Interface13.Browse( a, dat, "window=magnet;size=400x500" );
			GlobalFuncs.onclose( a, "magnet" );
			return null;
		}

		// Function from file: magnet.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return this.attack_hand( user );
		}

		// Function from file: magnet.dm
		public override int? process( dynamic seconds = null ) {
			Obj_Machinery_MagneticModule M = null;

			
			if ( this.magnets.len == 0 && this.autolink ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_MagneticModule) )) {
					M = _a;
					

					if ( M.freq == this.frequency && M.code == this.code ) {
						this.magnets.Add( M );
					}
				}
			}
			return null;
		}

		// Function from file: magnet.dm
		public override dynamic Destroy(  ) {
			dynamic _default = null;

			
			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.remove_object( this, this.frequency );
			}
			_default = base.Destroy();
			this.magnets = null;
			this.rpath = null;
			return _default;
		}

	}

}