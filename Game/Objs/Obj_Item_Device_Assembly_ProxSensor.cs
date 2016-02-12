// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Assembly_ProxSensor : Obj_Item_Device_Assembly {

		public bool scanning = false;
		public double? timing = 0;
		public double time = 10;
		public double default_time = 10;
		public double range = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.short_name = "prox sensor";
			this.starting_materials = new ByTable().Set( "$iron", 800 ).Set( "$glass", 200 );
			this.flags = 257;
			this.secured = false;
			this.accessible_values = new ByTable()
				.Set( "Scanning", "scanning;number" )
				.Set( "Scan range", "range;number;1;5" )
				.Set( "Remaining time", "time;number" )
				.Set( "Default time", "default_time;number" )
				.Set( "Timing", "timing;number" )
			;
			this.icon_state = "prox";
		}

		public Obj_Item_Device_Assembly_ProxSensor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: proximity.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? tp = null;
			double? r = null;

			base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this.loc, Task13.User ) || !Task13.User.canmove && !Lang13.Bool( Task13.User.locked_to ) ) {
				Interface13.Browse( Task13.User, null, "window=prox" );
				GlobalFuncs.onclose( Task13.User, "prox" );
				return null;
			}

			if ( Lang13.Bool( href_list["scanning"] ) ) {
				this.toggle_scan();
			}

			if ( Lang13.Bool( href_list["time"] ) ) {
				this.timing = String13.ParseNumber( href_list["time"] );
				this.update_icon();
			}

			if ( Lang13.Bool( href_list["tp"] ) ) {
				tp = String13.ParseNumber( href_list["tp"] );
				this.time += tp ??0;
				this.time = Num13.MinInt( Num13.MaxInt( Num13.Floor( this.time ), 0 ), 600 );
			}

			if ( Lang13.Bool( href_list["range"] ) ) {
				r = String13.ParseNumber( href_list["range"] );
				this.range += r ??0;
				this.range = ( this.range <= 1 ? 1 : ( this.range >= 5 ? 5 : this.range ) );
			}

			if ( Lang13.Bool( href_list["set_default_time"] ) ) {
				this.default_time = this.time;
			}

			if ( Lang13.Bool( href_list["close"] ) ) {
				Interface13.Browse( Task13.User, null, "window=prox" );
				return null;
			}

			if ( Task13.User != null ) {
				this.attack_self( Task13.User );
			}
			return null;
		}

		// Function from file: proximity.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			double second = 0;
			double minute = 0;
			string dat = null;

			
			if ( !this.secured ) {
				user.show_message( "<span class='warning'>The " + this.name + " is unsecured!</span>" );
				return 0;
			}
			second = this.time % 60;
			minute = ( this.time - second ) / 60;
			dat = new Txt( "<TT><B>Proximity Sensor</B>\n" ).item( ( Lang13.Bool( this.timing ) ? new Txt( "<A href='?src=" ).Ref( this ).str( ";time=0'>Arming</A>" ).ToString() : new Txt( "<A href='?src=" ).Ref( this ).str( ";time=1'>Not Arming</A>" ).ToString() ) ).str( " " ).item( minute ).str( ":" ).item( second ).str( "\n<A href='?src=" ).Ref( this ).str( ";tp=-30'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=-1'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=1'>+</A> <A href='?src=" ).Ref( this ).str( ";tp=30'>+</A>\n</TT>" ).ToString();
			dat += new Txt( "<BR>Range: <A href='?src=" ).Ref( this ).str( ";range=-1'>-</A> " ).item( this.range ).str( " <A href='?src=" ).Ref( this ).str( ";range=1'>+</A>" ).ToString();
			dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";scanning=1'>" ).item( ( this.scanning ? "Armed" : "Unarmed" ) ).str( "</A> (Movement sensor active when armed!)\n		<BR><BR><A href='?src=" ).Ref( this ).str( ";set_default_time=1'>After countdown, reset time to " ).item( ( this.default_time - this.default_time % 60 ) / 60 ).str( ":" ).item( this.default_time % 60 ).str( "</A>\n		<BR><BR><A href='?src=" ).Ref( this ).str( ";refresh=1'>Refresh</A>\n		<BR><BR><A href='?src=" ).Ref( this ).str( ";close=1'>Close</A>" ).ToString();
			Interface13.Browse( user, dat, "window=prox" );
			GlobalFuncs.onclose( user, "prox" );
			return null;
		}

		// Function from file: proximity.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			base.Move( (object)(NewLoc), Dir, step_x, step_y );
			this.sense();
			return false;
		}

		// Function from file: proximity.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			Ent_Static grenade = null;

			this.overlays.len = 0;
			this.attached_overlays = new ByTable();

			if ( Lang13.Bool( this.timing ) ) {
				this.overlays.Add( "prox_timing" );
				this.attached_overlays.Add( "prox_timing" );
			}

			if ( this.scanning ) {
				this.overlays.Add( "prox_scanning" );
				this.attached_overlays.Add( "prox_scanning" );
			}

			if ( this.holder != null ) {
				this.holder.update_icon();
			}

			if ( this.holder != null && this.holder.loc is Obj_Item_Weapon_Grenade_ChemGrenade ) {
				grenade = this.holder.loc;
				((dynamic)grenade).primed( this.scanning );
			}
			return null;
		}

		// Function from file: proximity.dm
		public override dynamic dropped( dynamic user = null ) {
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.sense();
				return;
				return;
			}));
			return null;
		}

		// Function from file: proximity.dm
		public override dynamic process(  ) {
			dynamic mainloc = null;
			Mob_Living A = null;

			
			if ( this.scanning ) {
				mainloc = GlobalFuncs.get_turf( this );

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( mainloc, this.range ), typeof(Mob_Living) )) {
					A = _a;
					

					if ( A.move_speed < 12 ) {
						this.sense();
					}
				}
			}

			if ( Lang13.Bool( this.timing ) && this.time >= 0 ) {
				this.time--;
			}

			if ( Lang13.Bool( this.timing ) && this.time <= 0 ) {
				this.timing = 0;
				this.toggle_scan();
				this.time = this.default_time;
			}
			return null;
		}

		// Function from file: proximity.dm
		public bool toggle_scan(  ) {
			
			if ( !this.secured ) {
				return false;
			}
			this.scanning = !this.scanning;
			this.update_icon();
			return false;
		}

		// Function from file: proximity.dm
		public bool sense(  ) {
			dynamic mainloc = null;

			mainloc = GlobalFuncs.get_turf( this );

			if ( !( this.holder != null ) && !this.secured || !this.scanning || this.cooldown > 0 ) {
				return false;
			}
			this.pulse( false );

			if ( !( this.holder != null ) ) {
				((Ent_Static)mainloc).visible_message( new Txt().icon( this ).str( " *beep* *beep*" ).ToString(), "*beep* *beep*" );
			}
			this.cooldown = 2;
			Task13.Schedule( 10, (Task13.Closure)(() => {
				this.process_cooldown();
				return;
			}));
			return false;
		}

		// Function from file: proximity.dm
		public override bool HasProximity( dynamic AM = null ) {
			
			if ( this.timestopped || this.loc != null && this.loc.timestopped ) {
				return false;
			}

			if ( GlobalFuncs.is_type_in_list( AM, GlobalVars.prox_sensor_ignored_types ) ) {
				return false;
			}

			if ( AM.move_speed < 12 ) {
				this.sense();
			}
			return false;
		}

		// Function from file: proximity.dm
		public override bool toggle_secure(  ) {
			this.secured = !this.secured;

			if ( this.secured ) {
				GlobalVars.processing_objects.Add( this );
			} else {
				this.scanning = false;
				this.timing = 0;
				GlobalVars.processing_objects.Remove( this );
			}
			this.update_icon();
			return this.secured;
		}

		// Function from file: proximity.dm
		public override bool activate(  ) {
			
			if ( !base.activate() ) {
				return false;
			}
			this.timing = !Lang13.Bool( this.timing ) ?1:0;
			this.update_icon();
			return false;
		}

	}

}