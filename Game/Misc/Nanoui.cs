// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Nanoui : Game_Data {

		public dynamic user = null;
		public Obj src_object = null;
		public dynamic title = null;
		public string ui_key = null;
		public string window_id = null;
		public int? width = 0;
		public int? height = 0;
		public bool on_close_logic = true;
		public dynamic v_ref = null;
		public string window_options = "focus=0;can_close=1;can_minimize=1;can_maximize=0;can_resize=1;titlebar=1;";
		public ByTable stylesheets = new ByTable();
		public ByTable scripts = new ByTable();
		public ByTable templates = new ByTable( 0 );
		public string layout_key = "default";
		public bool auto_update_layout = false;
		public bool auto_update_content = true;
		public string state_key = "default";
		public double? show_map = 0;
		public dynamic map_z_level = 1;
		public ByTable initial_data = new ByTable( 0 );
		public bool? is_auto_updating = false;
		public int status = 2;
		public int allowed_user_stat = 0;
		public bool distance_check = true;

		// Function from file: nanoui.dm
		public Nanoui ( dynamic nuser = null, Obj nsrc_object = null, string nui_key = null, string ntemplate_filename = null, dynamic ntitle = null, int? nwidth = null, int? nheight = null, dynamic nref = null, bool? ignore_distance = null ) {
			ntitle = ntitle ?? 0;
			nwidth = nwidth ?? 0;
			nheight = nheight ?? 0;
			ignore_distance = ignore_distance ?? false;

			this.user = nuser;
			this.src_object = nsrc_object;
			this.ui_key = nui_key;
			this.window_id = new Txt().item( this.ui_key ).Ref( this.src_object ).ToString();
			this.distance_check = !( ignore_distance == true );
			this.add_template( "main", ntemplate_filename );

			if ( Lang13.Bool( ntitle ) ) {
				this.title = ntitle;
			}

			if ( Lang13.Bool( nwidth ) ) {
				this.width = nwidth;
			}

			if ( Lang13.Bool( nheight ) ) {
				this.height = nheight;
			}

			if ( Lang13.Bool( nref ) ) {
				this.v_ref = nref;
			}
			this.add_common_assets();
			return;
		}

		// Function from file: nanoui.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			bool map_update = false;
			dynamic newz = null;

			this.update_status( false );

			if ( this.status != 2 || this.user != Task13.User ) {
				return null;
			}
			map_update = false;

			if ( Lang13.Bool( href_list["showMap"] ) ) {
				this.set_show_map( String13.ParseNumber( href_list["showMap"] ) );
				map_update = true;
			}

			if ( Lang13.Bool( href_list["zlevel"] ) ) {
				newz = Interface13.Input( "Choose Z-Level to view.", "Z-Levels", 1, null, new ByTable(new object [] { 1, 3, 4, 5, 6 }), InputType.Null | InputType.Any );

				if ( !Lang13.Bool( newz ) || newz == null ) {
					return 0;
				}

				if ( Convert.ToDouble( newz ) < 1 || Convert.ToDouble( newz ) > 6 || newz == 2 ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='danger'>Unable to establish a connection</span>" );
					return 0;
				}

				if ( newz != this.map_z_level ) {
					this.set_map_z_level( newz );
					map_update = true;
				}
			}

			if ( this.src_object != null && Lang13.Bool( this.src_object.Topic( href, href_list ) ) || map_update ) {
				GlobalVars.nanomanager.update_uis( this.src_object );
			}
			return null;
		}

		// Function from file: nanoui.dm
		public void update( bool? force_open = null ) {
			force_open = force_open ?? false;

			this.src_object.ui_interact( this.user, this.ui_key, this, force_open );
			return;
		}

		// Function from file: nanoui.dm
		public void process( bool? update = null ) {
			update = update ?? false;

			
			if ( !( this.src_object != null ) || !Lang13.Bool( this.user ) ) {
				this.close();
				return;
			}

			if ( this.status != 0 && ( update == true || this.is_auto_updating == true ) ) {
				this.update();
			} else {
				this.update_status( true );
			}
			return;
		}

		// Function from file: nanoui.dm
		public void push_data( ByTable data = null, bool? force_push = null ) {
			force_push = force_push ?? false;

			ByTable send_data = null;

			this.update_status( false );

			if ( this.status == 0 && !( force_push == true ) ) {
				return;
			}
			send_data = this.get_send_data( data );
			Interface13.Output( this.user, String13.MakeUrlParams( new ByTable(new object [] { GlobalFuncs.list2json( send_data ) }) ), "" + this.window_id + ".browser:receiveUpdateData" );
			return;
		}

		// Function from file: nanoui.dm
		public void on_close_winset(  ) {
			string _params = null;

			
			if ( !Lang13.Bool( this.user ) ) {
				return;
			}
			_params = new Txt().Ref( this ).ToString();
			Interface13.WindowSet( this.user, this.window_id, "on-close=\"nanoclose " + _params + "\"" );
			return;
		}

		// Function from file: nanoui.dm
		public void close(  ) {
			this.is_auto_updating = false;
			GlobalVars.nanomanager.ui_closed( this );
			Interface13.Browse( this.user, null, "window=" + this.window_id );
			return;
		}

		// Function from file: nanoui.dm
		public void open(  ) {
			string window_size = null;

			window_size = "";

			if ( Lang13.Bool( this.width ) && Lang13.Bool( this.height ) ) {
				window_size = "size=" + this.width + "x" + this.height + ";";
			}
			this.update_status( false );
			Interface13.Browse( this.user, this.get_html(), "window=" + this.window_id + ";" + window_size + this.window_options );
			Interface13.WindowSet( this.user, "mapwindow.map", "focus=true" );
			this.on_close_winset();
			GlobalVars.nanomanager.ui_opened( this );
			return;
		}

		// Function from file: nanoui.dm
		public string get_html(  ) {
			string head_content = null;
			dynamic filename = null;
			dynamic filename2 = null;
			dynamic template_data_json = null;
			ByTable send_data = null;
			dynamic initial_data_json = null;
			dynamic url_parameters_json = null;

			this.add_stylesheet( "layout_" + this.layout_key + ".css" );
			this.add_template( "layout", "layout_" + this.layout_key + ".tmpl" );
			head_content = "";

			foreach (dynamic _a in Lang13.Enumerate( this.scripts )) {
				filename = _a;
				
				head_content += "<script type='text/javascript' src='" + filename + "'></script> ";
			}

			foreach (dynamic _b in Lang13.Enumerate( this.stylesheets )) {
				filename2 = _b;
				
				head_content += "<link rel='stylesheet' type='text/css' href='" + filename2 + "'> ";
			}
			template_data_json = "{}";

			if ( this.templates.len > 0 ) {
				template_data_json = GlobalFuncs.list2json( this.templates );
			}
			send_data = this.get_send_data( this.initial_data );
			initial_data_json = GlobalFuncs.list2json( send_data );
			url_parameters_json = GlobalFuncs.list2json( new ByTable().Set( "src", new Txt().Ref( this ).ToString() ) );
			return @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd"">
<html>
	<meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
	<head>
		<script type='text/javascript'>
			function receiveUpdateData(jsonString)
			{
				// We need both jQuery and NanoStateManager to be able to recieve data
				// At the moment any data received before those libraries are loaded will be lost
				if (typeof NanoStateManager != 'undefined' && typeof jQuery != 'undefined')
				{
					NanoStateManager.receiveUpdateData(jsonString);
				}
			}
		</script>
		" + head_content + "\n	</head>\n	<body scroll=auto data-template-data='" + template_data_json + "' data-url-parameters='" + url_parameters_json + "' data-initial-data='" + initial_data_json + @"'>
		<div id='uiLayout'>
		</div>
		<noscript>
			<div id='uiNoScript'>
				<h2>JAVASCRIPT REQUIRED</h2>
				<p>Your Internet Explorer's Javascript is disabled (or broken).<br/>
				Enable Javascript and then open this UI again.</p>
			</div>
		</noscript>
	</body>
</html>
	";
		}

		// Function from file: nanoui.dm
		public void use_on_close_logic( dynamic state = null ) {
			this.on_close_logic = Lang13.Bool( state );
			return;
		}

		// Function from file: nanoui.dm
		public void set_map_z_level( dynamic nz = null ) {
			this.map_z_level = nz;
			return;
		}

		// Function from file: nanoui.dm
		public void set_show_map( double? nstate = null ) {
			this.show_map = nstate;
			return;
		}

		// Function from file: nanoui.dm
		public void set_state_key( dynamic nstate_key = null ) {
			this.state_key = nstate_key;
			return;
		}

		// Function from file: nanoui.dm
		public void set_auto_update_content( dynamic nstate = null ) {
			this.auto_update_content = Lang13.Bool( nstate );
			return;
		}

		// Function from file: nanoui.dm
		public void set_auto_update_layout( dynamic nstate = null ) {
			this.auto_update_layout = Lang13.Bool( nstate );
			return;
		}

		// Function from file: nanoui.dm
		public void set_layout_key( string nlayout_key = null ) {
			this.layout_key = String13.ToLower( nlayout_key );
			return;
		}

		// Function from file: nanoui.dm
		public void add_template( string key = null, string filename = null ) {
			this.templates[key] = filename;
			return;
		}

		// Function from file: nanoui.dm
		public void add_script( string file = null ) {
			this.scripts.Add( file );
			return;
		}

		// Function from file: nanoui.dm
		public void add_stylesheet( string file = null ) {
			this.stylesheets.Add( file );
			return;
		}

		// Function from file: nanoui.dm
		public void set_window_options( dynamic nwindow_options = null ) {
			this.window_options = nwindow_options;
			return;
		}

		// Function from file: nanoui.dm
		public ByTable get_send_data( ByTable data = null ) {
			ByTable config_data = null;
			ByTable send_data = null;

			config_data = this.get_config_data();
			send_data = new ByTable().Set( "config", config_data );

			if ( !( data == null ) ) {
				send_data["data"] = data;
			}
			return send_data;
		}

		// Function from file: nanoui.dm
		public ByTable get_config_data(  ) {
			ByTable config_data = null;

			config_data = new ByTable()
				.Set( "title", this.title )
				.Set( "srcObject", new ByTable().Set( "name", this.src_object ) )
				.Set( "stateKey", this.state_key )
				.Set( "status", this.status )
				.Set( "autoUpdateLayout", this.auto_update_layout )
				.Set( "autoUpdateContent", this.auto_update_content )
				.Set( "showMap", this.show_map )
				.Set( "mapZLevel", this.map_z_level )
				.Set( "user", new ByTable().Set( "name", this.user.name ) )
				.Set( "map_dir", GlobalVars.map.map_dir )
			;
			return config_data;
		}

		// Function from file: nanoui.dm
		public void set_initial_data( ByTable data = null ) {
			this.initial_data = data;
			return;
		}

		// Function from file: nanoui.dm
		public void set_auto_update( bool? nstate = null ) {
			nstate = nstate ?? true;

			this.is_auto_updating = nstate;
			return;
		}

		// Function from file: nanoui.dm
		public void update_status( bool? push_update = null ) {
			push_update = push_update ?? false;

			int dist = 0;
			Obj A = null;
			dynamic O = null;
			int? ghost_flags = null;

			
			if ( this.check_interactive() ) {
				this.set_status( 2, push_update );
			} else {
				dist = 0;

				if ( this.src_object is Ent_Static ) {
					A = this.src_object;

					if ( this.user is Mob_Dead_Observer ) {
						O = this.user;
						ghost_flags = 0;

						if ( A.ghost_write ) {
							ghost_flags |= 1;
						}

						if ( GlobalFuncs.canGhostWrite( O, A, "", ghost_flags ) || GlobalFuncs.isAdminGhost( O ) ) {
							this.set_status( 2, push_update );
							return;
						} else if ( GlobalFuncs.canGhostRead( O, A, ghost_flags ) ) {
							this.set_status( 1, push_update );
							return;
						}
					}
					dist = Map13.GetDistance( this.src_object, this.user );
				}

				if ( dist > 4 ) {
					this.close();
					return;
				}

				if ( this.allowed_user_stat > -1 && Convert.ToDouble( this.user.stat ) > this.allowed_user_stat ) {
					this.set_status( 0, push_update );
				} else if ( ((Mob)this.user).restrained() || this.user.lying == true ) {
					this.set_status( 1, push_update );
				} else if ( this.src_object is Obj_Item_Device_Uplink_Hidden ) {
					this.set_status( 2, push_update );
				} else if ( !Map13.FetchInView( this.user, 4 ).Contains( this.src_object ) ) {
					this.set_status( 0, push_update );
				} else if ( dist <= 1 ) {
					this.set_status( 2, push_update );
				} else if ( dist <= 2 ) {
					this.set_status( 1, push_update );
				} else if ( dist <= 4 ) {
					this.set_status( 0, push_update );
				}
			}
			return;
		}

		// Function from file: nanoui.dm
		public bool check_interactive(  ) {
			
			if ( Lang13.Bool( this.user.mutations ) && this.user.mutations.len != 0 ) {
				
				if ( Lang13.Bool( this.user.mutations.Contains( 1 ) ) ) {
					return true;
				}
			}

			if ( this.user is Mob_Living_Silicon_Robot ) {
				
				if ( Map13.FetchInView( this.user, 7 ).Contains( this.src_object ) ) {
					return true;
				}
			}
			return this.user is Mob_Living_Silicon_Ai || !this.distance_check || GlobalFuncs.isAdminGhost( this.user );
		}

		// Function from file: nanoui.dm
		public void set_status( int state = 0, bool? push_update = null ) {
			
			if ( state != this.status ) {
				
				if ( this.status == 0 ) {
					this.status = state;

					if ( push_update == true ) {
						this.update();
					}
				} else {
					this.status = state;

					if ( push_update == true || this.status == 0 ) {
						this.push_data( null, true );
					}
				}
			}
			return;
		}

		// Function from file: nanoui.dm
		public void add_common_assets(  ) {
			this.add_script( "libraries.min.js" );
			this.add_script( "nano_utility.js" );
			this.add_script( "nano_template.js" );
			this.add_script( "nano_state_manager.js" );
			this.add_script( "nano_state.js" );
			this.add_script( "nano_state_default.js" );
			this.add_script( "nano_base_callbacks.js" );
			this.add_script( "nano_base_helpers.js" );
			this.add_stylesheet( "shared.css" );
			this.add_stylesheet( "icons.css" );
			return;
		}

	}

}