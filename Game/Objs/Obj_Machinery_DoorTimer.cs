// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_DoorTimer : Obj_Machinery {

		public string id = null;
		public int? activation_time = 0;
		public int timer_duration = 0;
		public int? timing = 0;
		public ByTable targets = new ByTable();
		public Obj_Item_Device_Radio Radio = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 2 });
			this.anchored = 1;
			this.icon = "icons/obj/status_display.dmi";
			this.icon_state = "frame";
		}

		// Function from file: brigdoors.dm
		public Obj_Machinery_DoorTimer ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.Radio = new Obj_Item_Device_Radio( this );
			this.Radio.listening = false;
			return;
		}

		// Function from file: brigdoors.dm
		public override int? ui_act( string action = null, ByTable _params = null, Tgui ui = null, UiState state = null ) {
			int? _default = null;

			double? value = null;
			Obj_Machinery_Flasher F = null;
			dynamic preset = null;
			double preset_time = 0;

			
			if ( Lang13.Bool( base.ui_act( action, _params, ui, state ) ) ) {
				return _default;
			}
			_default = GlobalVars.TRUE;

			switch ((string)( action )) {
				case "time":
					value = String13.ParseNumber( _params["adjust"] );

					if ( Lang13.Bool( value ) ) {
						_default = this.set_timer( this.time_left() + ( value ??0) ) ?1:0;
					}
					break;
				case "start":
					this.timer_start();
					break;
				case "stop":
					this.timer_end( GlobalVars.TRUE );
					break;
				case "flash":
					
					foreach (dynamic _a in Lang13.Enumerate( this.targets, typeof(Obj_Machinery_Flasher) )) {
						F = _a;
						
						F.flash();
					}
					break;
				case "preset":
					preset = _params["preset"];
					preset_time = this.time_left();

					dynamic _b = preset; // Was a switch-case, sorry for the mess.
					if ( _b=="short" ) {
						preset_time = 1200;
					} else if ( _b=="medium" ) {
						preset_time = 3000;
					} else if ( _b=="long" ) {
						preset_time = 6000;
					}
					_default = this.set_timer( preset_time ) ?1:0;

					if ( Lang13.Bool( this.timing ) ) {
						this.activation_time = Game13.time;
					}
					break;
				default:
					_default = GlobalVars.FALSE;
					break;
			}
			return _default;
		}

		// Function from file: brigdoors.dm
		public override ByTable ui_data( dynamic user = null ) {
			ByTable data = null;
			double time_left = 0;
			Obj_Machinery_Flasher F = null;

			data = new ByTable();
			time_left = this.time_left( GlobalVars.TRUE );
			data["seconds"] = Num13.Floor( time_left % 60 );
			data["minutes"] = Num13.Floor( ( time_left - Convert.ToDouble( data["seconds"] ) ) / 60 );
			data["timing"] = this.timing;
			data["flash_charging"] = GlobalVars.FALSE;

			foreach (dynamic _a in Lang13.Enumerate( this.targets, typeof(Obj_Machinery_Flasher) )) {
				F = _a;
				

				if ( F.last_flash != 0 && F.last_flash + 150 > Game13.time ) {
					data["flash_charging"] = GlobalVars.TRUE;
					break;
				}
			}
			return data;
		}

		// Function from file: brigdoors.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			string disp1 = null;
			double time_left = 0;
			string disp2 = null;

			
			if ( ( this.stat & 2 ) != 0 ) {
				this.icon_state = "frame";
				return false;
			}

			if ( ( this.stat & 1 ) != 0 ) {
				this.set_picture( "ai_bsod" );
				return false;
			}

			if ( Lang13.Bool( this.timing ) ) {
				disp1 = this.id;
				time_left = this.time_left( GlobalVars.TRUE );
				disp2 = "" + GlobalFuncs.add_zero( String13.NumberToString( time_left / 60 % 60 ), 2 ) + "~" + GlobalFuncs.add_zero( String13.NumberToString( time_left % 60 ), 2 );

				if ( Lang13.Length( disp2 ) > 5 ) {
					disp2 = "Error";
				}
				this.update_display( disp1, disp2 );
			} else if ( Lang13.Bool( this.maptext ) ) {
				this.maptext = "";
			}
			return false;
		}

		// Function from file: brigdoors.dm
		public override int ui_interact( dynamic user = null, string ui_key = null, Tgui ui = null, bool? force_open = null, Tgui master_ui = null, UiState state = null ) {
			ui_key = ui_key ?? "main";
			force_open = force_open ?? false;
			state = state ?? GlobalVars.default_state;

			ui = GlobalVars.SStgui.try_update_ui( user, this, ui_key, ui, force_open );

			if ( !( ui != null ) ) {
				ui = new Tgui( user, this, ui_key, "brig_timer", this.name, 300, 200, master_ui, state );
				ui.open();
			}
			return 0;
		}

		// Function from file: brigdoors.dm
		public void update_display( string line1 = null, string line2 = null ) {
			string new_text = null;

			new_text = "<div style=\"font-size:" + "5pt" + ";color:" + "#09f" + ";font:'" + "Arial Black" + "';text-align:center;\" valign=\"top\">" + line1 + "<br>" + line2 + "</div>";

			if ( this.maptext != new_text ) {
				this.maptext = new_text;
			}
			return;
		}

		// Function from file: brigdoors.dm
		public void set_picture( string state = null ) {
			
			if ( Lang13.Bool( this.maptext ) ) {
				this.maptext = "";
			}
			this.overlays.Cut();
			this.overlays.Add( new Image( "icons/obj/status_display.dmi", null, state ) );
			return;
		}

		// Function from file: brigdoors.dm
		public bool set_timer( double value = 0 ) {
			bool _default = false;

			int new_time = 0;

			new_time = Num13.MaxInt( 0, Num13.MinInt( ((int)( value )), 9000 ) );
			_default = new_time == this.timer_duration;
			this.timer_duration = new_time;
			return _default;
		}

		// Function from file: brigdoors.dm
		public double time_left( int? seconds = null ) {
			seconds = seconds ?? GlobalVars.FALSE;

			double _default = 0;

			_default = Num13.MaxInt( 0, this.timer_duration - ( Lang13.Bool( this.activation_time ) ? Game13.time - ( this.activation_time ??0) : 0 ) );

			if ( Lang13.Bool( seconds ) ) {
				_default /= 10;
			}
			return _default;
		}

		// Function from file: brigdoors.dm
		public bool timer_end( int? forced = null ) {
			forced = forced ?? GlobalVars.FALSE;

			Obj_Machinery_Door_Window_Brigdoor door = null;
			Obj_Structure_Closet_SecureCloset_Brig C = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return false;
			}

			if ( !Lang13.Bool( forced ) ) {
				this.Radio.set_frequency( GlobalVars.SEC_FREQ );
				this.Radio.talk_into( this, "Timer has expired. Releasing prisoner.", GlobalVars.SEC_FREQ );
			}
			this.timing = GlobalVars.FALSE;
			this.activation_time = null;
			this.set_timer( 0 );
			this.update_icon();

			foreach (dynamic _a in Lang13.Enumerate( this.targets, typeof(Obj_Machinery_Door_Window_Brigdoor) )) {
				door = _a;
				

				if ( !door.density ) {
					continue;
				}
				Task13.Schedule( 0, (Task13.Closure)(() => {
					door.open();
					return;
				}));
			}

			foreach (dynamic _b in Lang13.Enumerate( this.targets, typeof(Obj_Structure_Closet_SecureCloset_Brig) )) {
				C = _b;
				

				if ( C.broken ) {
					continue;
				}

				if ( C.opened ) {
					continue;
				}
				C.locked = false;
				C.update_icon();
			}
			return true;
		}

		// Function from file: brigdoors.dm
		public bool timer_start(  ) {
			Obj_Machinery_Door_Window_Brigdoor door = null;
			Obj_Structure_Closet_SecureCloset_Brig C = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return false;
			}
			this.activation_time = Game13.time;
			this.timing = GlobalVars.TRUE;

			foreach (dynamic _a in Lang13.Enumerate( this.targets, typeof(Obj_Machinery_Door_Window_Brigdoor) )) {
				door = _a;
				

				if ( door.density ) {
					continue;
				}
				Task13.Schedule( 0, (Task13.Closure)(() => {
					door.close();
					return;
				}));
			}

			foreach (dynamic _b in Lang13.Enumerate( this.targets, typeof(Obj_Structure_Closet_SecureCloset_Brig) )) {
				C = _b;
				

				if ( C.broken ) {
					continue;
				}

				if ( C.opened && !C.close() ) {
					continue;
				}
				C.locked = true;
				C.update_icon();
			}
			return true;
		}

		// Function from file: brigdoors.dm
		public override void power_change(  ) {
			base.power_change();
			this.update_icon();
			return;
		}

		// Function from file: brigdoors.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( Lang13.Bool( this.timing ) ) {
				
				if ( Game13.time - ( this.activation_time ??0) >= this.timer_duration ) {
					this.timer_end();
				}
				this.update_icon();
			}
			return null;
		}

		// Function from file: brigdoors.dm
		public override void initialize(  ) {
			Obj_Machinery_Door_Window_Brigdoor M = null;
			Obj_Machinery_Flasher F = null;
			Obj_Structure_Closet_SecureCloset_Brig C = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.ultra_range( 20, this ), typeof(Obj_Machinery_Door_Window_Brigdoor) )) {
				M = _a;
				

				if ( M.id == this.id ) {
					this.targets.Add( M );
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.ultra_range( 20, this ), typeof(Obj_Machinery_Flasher) )) {
				F = _b;
				

				if ( F.id == this.id ) {
					this.targets.Add( F );
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( GlobalFuncs.ultra_range( 20, this ), typeof(Obj_Structure_Closet_SecureCloset_Brig) )) {
				C = _c;
				

				if ( C.id == this.id ) {
					this.targets.Add( C );
				}
			}

			if ( !( this.targets.len != 0 ) ) {
				this.stat |= 1;
			}
			this.update_icon();
			return;
		}

	}

}