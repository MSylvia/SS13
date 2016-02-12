// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_EmbeddedController_Radio_AirlockController : Obj_Machinery_EmbeddedController_Radio {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.tag_secure = true;
		}

		public Obj_Machinery_EmbeddedController_Radio_AirlockController ( dynamic loc = null, int ndir = 0, bool? building = null ) : base( (object)(loc), ndir, building ) {
			
		}

		// Function from file: airlock_controllers.dm
		public override bool linkWith( Mob user = null, Base_Data buffer = null, ByTable context = null ) {
			dynamic DP = null;
			dynamic UV = null;
			Base_Data D = null;
			Base_Data S = null;

			
			if ( DP is Obj_Machinery_Atmospherics_Binary_DpVentPump && DP.id_tag == this.tag_airpump ) {
				this.tag_airpump = DP.id_tag;
				return true;
			}

			if ( UV is Obj_Machinery_Atmospherics_Unary_VentPump && UV.id_tag == this.tag_airpump ) {
				this.tag_airpump = UV.id_tag;
				return true;
			}
			D = buffer;

			if ( D is Obj_Machinery_Door_Airlock ) {
				
				if ( context["slot"] == "int" ) {
					this.tag_interior_door = ((dynamic)D).id_tag;
					return true;
				}

				if ( context["slot"] == "ext" ) {
					this.tag_exterior_door = ((dynamic)D).id_tag;
					return true;
				}
			}
			S = buffer;

			if ( S is Obj_Machinery_AirlockSensor ) {
				
				if ( context["slot"] == "chamber" ) {
					this.tag_chamber_sensor = ((dynamic)S).id_tag;
					((dynamic)buffer).master_tag = this.id_tag;
					return true;
				}
			}
			return false;
		}

		// Function from file: airlock_controllers.dm
		public override bool isLinkedWith( Base_Data O = null ) {
			Base_Data D = null;
			Base_Data S = null;
			dynamic DP = null;
			dynamic UV = null;

			D = O;

			if ( D is Obj_Machinery_Door_Airlock ) {
				
				if ( this.tag_interior_door == ((dynamic)D).id_tag ) {
					return true;
				}

				if ( this.tag_exterior_door == ((dynamic)D).id_tag ) {
					return true;
				}
			}
			S = O;

			if ( S is Obj_Machinery_AirlockSensor ) {
				
				if ( this.tag_chamber_sensor == ((dynamic)S).id_tag ) {
					return true;
				}
			}

			if ( DP is Obj_Machinery_Atmospherics_Binary_DpVentPump && DP.id_tag == this.tag_airpump ) {
				return true;
			}

			if ( UV is Obj_Machinery_Atmospherics_Unary_VentPump && UV.id_tag == this.tag_airpump ) {
				return true;
			}
			return false;
		}

		// Function from file: airlock_controllers.dm
		public override bool unlinkFrom( Mob user = null, Base_Data buffer = null ) {
			Base_Data D = null;
			Base_Data S = null;
			dynamic UV = null;
			dynamic DPV = null;

			D = buffer;

			if ( D is Obj_Machinery_Door_Airlock ) {
				
				if ( this.tag_exterior_door == ((dynamic)D).id_tag ) {
					this.tag_exterior_door = null;
					return true;
				} else if ( this.tag_interior_door == ((dynamic)D).id_tag ) {
					this.tag_interior_door = null;
					return true;
				}
			}
			S = buffer;

			if ( S is Obj_Machinery_AirlockSensor ) {
				
				if ( this.tag_chamber_sensor == ((dynamic)S).id_tag ) {
					this.tag_chamber_sensor = null;
					return true;
				}
			}

			if ( UV is Obj_Machinery_Atmospherics_Unary_VentPump && UV.id_tag == this.tag_airpump ) {
				this.tag_airpump = null;
				return true;
			}

			if ( DPV is Obj_Machinery_Atmospherics_Binary_DpVentPump ) {
				
				if ( DPV.id_tag == this.tag_airpump ) {
					this.tag_airpump = null;
					return true;
				}
			}
			return false;
		}

		// Function from file: airlock_controllers.dm
		public override bool canLink( Base_Data O = null, ByTable context = null ) {
			
			if ( O is Obj_Machinery_Door ) {
				
				if ( new ByTable(new object [] { "int", "ext" }).Contains( context["slot"] ) ) {
					return true;
				}
			}

			if ( O is Obj_Machinery_Atmospherics ) {
				return true;
			}

			if ( O is Obj_Machinery_AirlockSensor ) {
				
				if ( context["slot"] == "chamber" ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: airlock_controllers.dm
		public override string linkMenu( Base_Data O = null ) {
			string dat = null;

			dat = "";

			if ( O is Obj_Machinery_AirlockSensor ) {
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";link=1;slot=chamber'>[Link @ chamber]</a><br>" ).ToString();
			} else if ( O is Obj_Machinery_Atmospherics_Unary_VentPump ) {
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";link=1'>[Link @ pump]</a>" ).ToString();
			} else if ( O is Obj_Machinery_Door_Airlock ) {
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";link=1;slot=ext'>[Link @ exterior]</a><br>" ).ToString();
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";link=1;slot=int'>[Link @ interior]</a>" ).ToString();
			}
			return dat;
		}

		// Function from file: airlock_controllers.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			bool clean = false;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			}
			clean = false;

			dynamic _a = href_list["command"]; // Was a switch-case, sorry for the mess.
			if ( _a=="cycle_ext" ) {
				clean = true;
			} else if ( _a=="cycle_int" ) {
				clean = true;
			} else if ( _a=="force_ext" ) {
				clean = true;
			} else if ( _a=="force_int" ) {
				clean = true;
			} else if ( _a=="abort" ) {
				clean = true;
			}

			if ( clean ) {
				this.program.receive_user_command( href_list["command"] );
			}
			return 1;
		}

		// Function from file: airlock_controllers.dm
		public override void ui_interact( dynamic user = null, string ui_key = null, Nanoui ui = null, bool? force_open = null ) {
			ui_key = ui_key ?? "main";

			ByTable data = null;

			
			if ( !( this.program != null ) ) {
				this.initialize();
			}
			data = new ByTable( 0 );
			data = new ByTable()
				.Set( "chamber_pressure", Num13.Floor( Convert.ToDouble( this.program.memory["chamber_sensor_pressure"] ) ) )
				.Set( "exterior_status", this.program.memory["exterior_status"] )
				.Set( "interior_status", this.program.memory["interior_status"] )
				.Set( "processing", this.program.memory["processing"] )
			;
			ui = GlobalVars.nanomanager.try_update_ui( user, this, ui_key, ui, data );

			if ( !( ui != null ) ) {
				ui = new Nanoui( user, this, ui_key, "simple_airlock_console.tmpl", this.name, 470, 290 );
				ui.set_initial_data( data );
				ui.open();
				ui.set_auto_update( true );
			}
			return;
		}

		// Function from file: airlock_controllers.dm
		public override string multitool_menu( dynamic user = null, dynamic P = null ) {
			return new Txt( "\n		<ul>\n		<li><b>Frequency:</b> <a href=\"?src=" ).Ref( this ).str( ";set_freq=-1\">" ).item( GlobalFuncs.format_frequency( this.frequency ) ).str( " GHz</a> (<a href=\"?src=" ).Ref( this ).str( ";set_freq=" ).item( 1449 ).str( "\">Reset</a>)</li>\n		<li>" ).item( this.format_tag( "ID Tag", "id_tag" ) ).str( "</li>\n		<li>" ).item( this.format_tag( "Pump ID", "tag_airpump" ) ).str( @"</li>
		</ul>
		<b>Doors:</b>
		<ul>
		<li>" ).item( this.format_tag( "Exterior", "tag_exterior_door" ) ).str( "</li>\n		<li>" ).item( this.format_tag( "Interior", "tag_interior_door" ) ).str( @"</li>
		</ul>
		<b>Sensors:</b>
		<ul>
		<li>" ).item( this.format_tag( "Chamber", "tag_chamber_sensor" ) ).str( "</li>\n		</ul>" ).ToString();
		}

	}

}