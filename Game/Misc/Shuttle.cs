// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Shuttle : Game_Data {

		public dynamic name = "shuttle";
		public ByTable docking_ports = new ByTable();
		public dynamic linked_area = null;
		public Obj_Structure_DockingPort_Shuttle linked_port = null;
		public dynamic current_port = null;
		public dynamic transit_port = null;
		public dynamic destination_port = null;
		public ByTable docking_ports_aboard = new ByTable();
		public dynamic use_transit = 1;
		public dynamic dir = 1;
		public dynamic can_rotate = 1;
		public dynamic pre_flight_delay = 50;
		public dynamic transit_delay = 100;
		public bool moving = false;
		public ByTable cant_leave_zlevel = new ByTable().Set( typeof(Obj_Item_Weapon_Disk_Nuclear), "The nuclear authentication disk can't be transported on a shuttle." );
		public ByTable req_access = new ByTable();
		public int last_moved = 0;
		public dynamic cooldown = 100;
		public dynamic innacuracy = 0;
		public bool stable = false;
		public int password = 28011;
		public int can_link_to_computer = 2;
		public bool collision_type = false;
		public ByTable control_consoles = new ByTable();
		public dynamic lockdown = 0;
		public bool destroy_everything = false;

		// Function from file: shuttle.dm
		public Shuttle ( dynamic starting_area = null ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.Bool( starting_area ) ) {
				
				if ( starting_area is Type ) {
					this.linked_area = Lang13.FindObj( starting_area );
				} else if ( starting_area is Zone ) {
					this.linked_area = starting_area;
				} else {
					this.linked_area = starting_area;
					Game13.log.WriteMsg( "## WARNING: " + ( "Unable to find area " + starting_area + " in world - " + this.type + " (" + this.name + ") won't be able to function properly." ) );
				}
			}

			if ( this.linked_area is Zone && this.linked_area.contents.len != 0 ) {
				GlobalVars.shuttles.Or( this );
			}
			this.password = Rand13.Int( 10000, 99999 );
			return;
		}

		// Function from file: shuttle.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			GlobalVars.shuttles.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: shuttle.dm
		public void show_outline( Mob user = null, Tile centered_at = null ) {
			dynamic user_turf = null;
			dynamic original_center = null;
			double? offsetX = null;
			double? offsetY = null;
			Coords offset = null;
			double rotate = 0;
			ByTable original_coords = null;
			dynamic T = null;
			Coords C = null;
			ByTable new_coords = null;
			double cosine = 0;
			double sine = 0;
			Coords C2 = null;
			Coords NC = null;
			double newX = 0;
			double newY = 0;
			ByTable images = null;
			Coords C3 = null;
			Tile T2 = null;
			Image I = null;
			Image center_img = null;
			Image I2 = null;

			
			if ( !( user != null ) ) {
				return;
			}

			if ( !( centered_at != null ) ) {
				user_turf = GlobalFuncs.get_turf( user );

				if ( !Lang13.Bool( user_turf ) ) {
					GlobalFuncs.to_chat( user, "You must be standing on a turf!" );
					return;
				}
				centered_at = Map13.GetStep( user_turf, Task13.User.dir );
			}
			original_center = GlobalFuncs.get_turf( this.linked_port );

			if ( !( centered_at != null ) ) {
				GlobalFuncs.to_chat( user, "ERROR: Unable to find center turf!" );
				return;
			}
			offsetX = centered_at.x - Convert.ToDouble( original_center.x );
			offsetY = centered_at.y - Convert.ToDouble( original_center.y );
			offset = new Coords( offsetX, offsetY );
			rotate = ( GlobalFuncs.dir2angle( Num13.Rotate( user.dir, 180 ) ) ??0) - ( GlobalFuncs.dir2angle( this.linked_port.dir ) ??0);
			original_coords = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( ((Zone)this.linked_area).get_turfs() )) {
				T = _a;
				
				C = new Coords( Lang13.DoubleNullable( T.x ), Lang13.DoubleNullable( T.y ) );
				original_coords.Add( C );
			}
			new_coords = new ByTable();
			cosine = Math.Cos( rotate );
			sine = Math.Sin( rotate );

			foreach (dynamic _b in Lang13.Enumerate( original_coords, typeof(Coords) )) {
				C2 = _b;
				
				NC = C2.add( offset );
				new_coords.Add( NC );

				if ( rotate != 0 ) {
					newX = cosine * ( ( NC.x_pos ??0) - centered_at.x ) + sine * ( ( NC.y_pos ??0) - centered_at.y ) + centered_at.x;
					newY = -( sine * ( ( NC.x_pos ??0) - centered_at.x ) ) + cosine * ( ( NC.y_pos ??0) - centered_at.y ) + centered_at.y;
					NC.x_pos = newX;
					NC.y_pos = newY;
				}
			}
			images = new ByTable();

			foreach (dynamic _c in Lang13.Enumerate( new_coords, typeof(Coords) )) {
				C3 = _c;
				
				T2 = Map13.GetTile( ((int)( C3.x_pos ??0 )), ((int)( C3.y_pos ??0 )), centered_at.z );

				if ( !( T2 != null ) ) {
					continue;
				}
				I = new Image( "icons/turf/areas.dmi", null, "bluenew" );
				((dynamic)I).loc = T2;
				images.Add( I );
				user.WriteMsg( I );
			}
			center_img = new Image( "icons/turf/areas.dmi", null, "blue" );
			((dynamic)center_img).loc = centered_at;
			images.Add( center_img );
			user.WriteMsg( center_img );
			Interface13.Alert( Task13.User, "Press \"Ok\" to remove the images", "Magic", "Ok" );

			if ( Task13.User.client != null ) {
				
				foreach (dynamic _d in Lang13.Enumerate( images, typeof(Image) )) {
					I2 = _d;
					
					Task13.User.client.images.Remove( I2 );
				}
			}
			return;
		}

		// Function from file: shuttle.dm
		public bool move_area_to( dynamic our_center = null, dynamic new_center = null, double? rotate = null ) {
			rotate = rotate ?? 0;

			Coords our_center_coords = null;
			Coords new_center_coords = null;
			Coords offset = null;
			double? throwy = null;
			dynamic space = null;
			ByTable turfs_to_move = null;
			ByTable our_own_turfs = null;
			dynamic T = null;
			Coords C = null;
			double cosine = 0;
			double sine = 0;
			ByTable new_turfs = null;
			Coords C2 = null;
			Coords new_coords = null;
			double newX = 0;
			double newY = 0;
			dynamic A = null;
			ByTable turfs_to_update = null;
			Coords C3 = null;
			Coords old_C = null;
			Tile old_turf = null;
			Tile new_turf = null;
			bool add_underlay = false;
			dynamic I = null;
			Tile displace_to = null;
			dynamic AM = null;
			dynamic old_area = null;
			Image undlay = null;
			Ent_Dynamic AM2 = null;
			dynamic key = null;
			dynamic L = null;
			Tile S_OLD = null;
			Tile S_NEW = null;
			Ent_Dynamic AM3 = null;
			ByTable L2 = null;
			dynamic replacing_turf_type = null;
			dynamic D = null;
			Tile_Simulated T1 = null;
			Obj_Machinery_Door D2 = null;

			
			if ( !Lang13.Bool( our_center ) ) {
				return false;
			}

			if ( !Lang13.Bool( new_center ) ) {
				return false;
			}

			if ( ( rotate ??0) % 90 != 0 ) {
				rotate += ( rotate ??0) % 90;
			}
			our_center_coords = new Coords( Lang13.DoubleNullable( our_center.x ), Lang13.DoubleNullable( our_center.y ) );
			new_center_coords = new Coords( Lang13.DoubleNullable( new_center.x ), Lang13.DoubleNullable( new_center.y ) );
			offset = new_center_coords.subtract( our_center_coords );
			throwy = Game13.map_size_y;
			space = GlobalFuncs.get_area( Map13.GetTile( 1, 1, 2 ) );

			if ( !Lang13.Bool( space ) ) {
				Game13.log.WriteMsg( "## WARNING: " + "There is no area at 1,1,2!" );
			}
			turfs_to_move = new ByTable();
			our_own_turfs = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( ((Zone)this.linked_area).get_turfs() )) {
				T = _a;
				
				C = new Coords( Lang13.DoubleNullable( T.x ), Lang13.DoubleNullable( T.y ) );
				turfs_to_move.Add( C );
				turfs_to_move[C] = T;
				our_own_turfs.Add( "" + T.x + ";" + T.y + ";" + T.z );
			}
			cosine = Math.Cos( rotate ??0 );
			sine = Math.Sin( rotate ??0 );
			new_turfs = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( turfs_to_move, typeof(Coords) )) {
				C2 = _b;
				
				new_coords = C2.add( offset );
				new_turfs.Add( new_coords );
				new_turfs[new_coords] = C2;

				if ( rotate != 0 ) {
					newX = cosine * ( ( new_coords.x_pos ??0) - Convert.ToDouble( new_center.x ) ) + sine * ( ( new_coords.y_pos ??0) - Convert.ToDouble( new_center.y ) ) + Convert.ToDouble( new_center.x );
					newY = -( sine * ( ( new_coords.x_pos ??0) - Convert.ToDouble( new_center.x ) ) ) + cosine * ( ( new_coords.y_pos ??0) - Convert.ToDouble( new_center.y ) ) + Convert.ToDouble( new_center.y );
					new_coords.x_pos = newX;
					new_coords.y_pos = newY;
				}

				if ( ( new_coords.y_pos ??0) < ( throwy ??0) ) {
					throwy = new_coords.y_pos;
				}
				A = GlobalFuncs.get_area( Map13.GetTile( ((int)( new_coords.x_pos ??0 )), ((int)( new_coords.y_pos ??0 )), Convert.ToInt32( new_center.z ) ) );

				if ( !Lang13.Bool( A ) ) {
					GlobalFuncs.message_admins( "<span class='notice'>WARNING: Unable to find an area at " + new_coords.x_pos + ";" + new_coords.y_pos + ";" + new_center.z + ". " + this.name + " (" + this.type + ") will not be moved." );
					return false;
				}

				if ( !this.destroy_everything && !new ByTable(new object [] { typeof(Zone), typeof(Zone_Station_Custom) }).Contains( A.type ) ) {
					GlobalFuncs.message_admins( "<span class='notice'>WARNING: " + this.name + " (" + this.type + ") attempted to destroy " + A + " (" + A.type + ").</span> If you want " + this.name + " to be able to move freely and destroy areas, change its \"destroy_everything\" variable to 1." );
					return false;
				}

				if ( our_own_turfs.Contains( "" + new_coords.x_pos + ";" + new_coords.y_pos + ";" + new_center.z ) ) {
					Game13.log.WriteMsg( "## WARNING: " + ( "Shuttle (" + this.name + "; " + this.type + ") has attempted to move to a location which overlaps with its current position. Offending turf: " + new_coords.x_pos + ";" + new_coords.y_pos + ";" + new_center.z ) );
					GlobalFuncs.message_admins( "WARNING: A shuttle (" + this.name + "; " + this.type + ") has attempted to move to a location which overlaps with its current position. The shuttle will not be moved." );
					return false;
				}
			}
			turfs_to_update = new ByTable();

			foreach (dynamic _h in Lang13.Enumerate( new_turfs, typeof(Coords) )) {
				C3 = _h;
				
				old_C = new_turfs[C3];
				old_turf = turfs_to_move[old_C];
				new_turf = Map13.GetTile( ((int)( C3.x_pos ??0 )), ((int)( C3.y_pos ??0 )), Convert.ToInt32( new_center.z ) );
				add_underlay = false;

				if ( !( old_turf != null ) ) {
					GlobalFuncs.message_admins( "ERROR when moving " + this.name + " (" + this.type + ") - failed to get original turf at " + old_C.x_pos + ";" + old_C.y_pos + ";" + our_center.z );
					continue;
				} else if ( !old_turf.preserve_underlay && old_turf is Tile_Simulated_Shuttle_Wall ) {
					
					if ( GlobalVars.transparent_icons.Contains( old_turf.icon_state ) ) {
						add_underlay = true;

						if ( old_turf.underlays.len != 0 ) {
							I = Lang13.FindIn( typeof(Image), old_turf.underlays );

							if ( I.icon == "icons/turf/shuttle.dmi" ) {
								add_underlay = false;
							}
						}
					}
				}

				if ( !( new_turf != null ) ) {
					GlobalFuncs.message_admins( "ERROR when moving " + this.name + " (" + this.type + ") - failed to get new turf at " + C3.x_pos + ";" + C3.y_pos + ";" + new_center.z );
					continue;
				}
				displace_to = Map13.GetTile( ((int)( C3.x_pos ??0 )), ((int)( throwy ??0 )), Convert.ToInt32( new_center.z ) );

				foreach (dynamic _c in Lang13.Enumerate( new_turf.contents )) {
					AM = _c;
					

					if ( Lang13.Bool( AM.anchored ) || !this.collision_type ) {
						this.collide( AM );
					} else {
						((Ent_Dynamic)AM).forceMove( displace_to );
					}
				}
				old_area = GlobalFuncs.get_area( new_turf );

				if ( !Lang13.Bool( old_area ) ) {
					old_area = space;
				}
				undlay = null;

				if ( add_underlay ) {
					undlay = new Image( new_turf.icon, null, new_turf.icon_state, null, new_turf.dir );
					undlay.overlays = new_turf.overlays;
				}
				this.linked_area.contents.Add( new_turf );
				new_turf.change_area( old_area, this.linked_area );
				new_turf.ChangeTurf( old_turf.type, null, null, true );
				new_turfs[C3] = new_turf;
				space.contents.Add( old_turf );
				old_turf.change_area( this.linked_area, space );

				foreach (dynamic _d in Lang13.Enumerate( old_turf.contents, typeof(Ent_Dynamic) )) {
					AM2 = _d;
					

					if ( !AM2.can_shuttle_move( this ) ) {
						AM2.change_area( this.linked_area, space );
					}
				}

				foreach (dynamic _e in Lang13.Enumerate( old_turf.vars )) {
					key = _e;
					

					if ( GlobalVars.ignored_keys.Contains( key ) ) {
						continue;
					}

					if ( old_turf.vars[key] is ByTable ) {
						L = old_turf.vars[key];
						new_turf.vars[key] = L.Copy();
					} else if ( old_turf.vars != null ) {
						new_turf.vars[key] = old_turf.vars[key];
					}
				}

				if ( old_turf.transform != null ) {
					new_turf.transform = old_turf.transform;
				}

				if ( add_underlay && undlay != null ) {
					new_turf.underlays = new ByTable(new object [] { undlay });
				} else {
					new_turf.underlays = old_turf.underlays;
				}
				new_turf.dir = old_turf.dir;
				new_turf.icon_state = old_turf.icon_state;
				new_turf.icon = old_turf.icon;

				if ( Lang13.Bool( rotate ) ) {
					new_turf.shuttle_rotate( rotate );
				}
				S_OLD = old_turf;

				if ( S_OLD is Tile_Simulated && Lang13.Bool( ((dynamic)S_OLD).zone ) ) {
					S_NEW = new_turf;

					if ( !( S_NEW.air != null ) ) {
						S_NEW.make_air();
					}
					S_NEW.air.copy_from( ((dynamic)S_OLD).zone.air );
					((_Zone)((dynamic)S_OLD).zone).remove( S_OLD );
				}

				foreach (dynamic _f in Lang13.Enumerate( old_turf, typeof(Ent_Dynamic) )) {
					AM3 = _f;
					

					if ( !AM3.can_shuttle_move( this ) ) {
						continue;
					}

					if ( AM3.bound_width > Game13.icon_size || AM3.bound_height > Game13.icon_size ) {
						AM3.loc = null;
						Task13.Schedule( 0, (Task13.Closure)(() => {
							AM3.forceMove( new_turf );
							return;
						}));
					} else {
						AM3.forceMove( new_turf );
					}

					if ( Lang13.Bool( rotate ) ) {
						AM3.shuttle_rotate( rotate );
					}
				}

				foreach (dynamic _g in Lang13.Enumerate( GlobalVars.moved_landmarks, typeof(ByTable) )) {
					L2 = _g;
					

					if ( L2.Contains( old_turf ) ) {
						L2.Remove( old_turf );
						L2.Add( new_turf );
					}
				}
				turfs_to_update.Add( new_turf );
				replacing_turf_type = GlobalFuncs.get_base_turf( old_turf.z );
				D = this.linked_port.docked_with;

				if ( Lang13.Bool( D ) && D is Obj_Structure_DockingPort_Destination ) {
					replacing_turf_type = D.base_turf_type;
				}
				old_turf.ChangeTurf( replacing_turf_type, null, null, true );

				if ( Lang13.Bool( D ) && D is Obj_Structure_DockingPort_Destination ) {
					
					if ( Lang13.Bool( D.base_turf_icon ) ) {
						old_turf.icon = D.base_turf_icon;
					}

					if ( Lang13.Bool( D.base_turf_icon_state ) ) {
						old_turf.icon_state = D.base_turf_icon_state;
					}
				}

				if ( old_turf is Tile_Space ) {
					old_turf.lighting_clear_overlays();
				}
			}

			if ( turfs_to_update.len != 0 ) {
				
				foreach (dynamic _j in Lang13.Enumerate( turfs_to_update, typeof(Tile_Simulated) )) {
					T1 = _j;
					

					foreach (dynamic _i in Lang13.Enumerate( T1, typeof(Obj_Machinery_Door) )) {
						D2 = _i;
						
						D2.update_nearby_tiles();
					}
				}
			}
			return true;
		}

		// Function from file: shuttle.dm
		public void move( Mob user = null ) {
			ByTable possible_locations = null;
			Obj_Structure_DockingPort_Destination S = null;
			dynamic target = null;

			possible_locations = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( this.docking_ports, typeof(Obj_Structure_DockingPort_Destination) )) {
				S = _a;
				

				if ( S == this.current_port ) {
					continue;
				}

				if ( Lang13.Bool( S.docked_with ) ) {
					continue;
				}
				possible_locations.Add( S );
			}

			if ( !( possible_locations.len != 0 ) ) {
				return;
			}
			target = Rand13.PickFromTable( possible_locations );
			this.travel_to( target, null, user );
			return;
		}

		// Function from file: shuttle.dm
		public void supercharge(  ) {
			this.cooldown = 0;
			this.pre_flight_delay = 0;
			this.transit_delay = 0;
			return;
		}

		// Function from file: shuttle.dm
		public void collide( dynamic AM = null ) {
			((Ent_Static)AM).shuttle_act( this );
			return;
		}

		// Function from file: shuttle.dm
		public virtual dynamic after_flight(  ) {
			Ent_Dynamic AM = null;
			Ent_Dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.linked_area, typeof(Ent_Dynamic) )) {
				AM = _a;
				

				if ( Lang13.Bool( AM.anchored ) ) {
					continue;
				}

				if ( AM is Mob_Living ) {
					M = AM;

					if ( !Lang13.Bool( M.locked_to ) ) {
						GlobalFuncs.shake_camera( M, 10, 1 );

						if ( !this.stable ) {
							
							if ( M is Mob_Living_Carbon ) {
								((Mob)M).Weaken( 3 );
							}
						}
					} else {
						GlobalFuncs.shake_camera( M, 3, 1 );
					}
				}
			}
			return null;
		}

		// Function from file: shuttle.dm
		public void open_all_doors(  ) {
			Obj_Machinery_Door_Unpowered_Shuttle D = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.linked_area, typeof(Obj_Machinery_Door_Unpowered_Shuttle) )) {
				D = _a;
				
				Task13.Schedule( 0, (Task13.Closure)(() => {
					D.open();
					return;
				}));
			}
			return;
		}

		// Function from file: shuttle.dm
		public void close_all_doors(  ) {
			Obj_Machinery_Door_Unpowered_Shuttle D = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.linked_area, typeof(Obj_Machinery_Door_Unpowered_Shuttle) )) {
				D = _a;
				
				Task13.Schedule( 0, (Task13.Closure)(() => {
					D.close();
					return;
				}));
			}
			return;
		}

		// Function from file: shuttle.dm
		public bool move_to_dock( dynamic D = null, bool? ignore_innacuracy = null ) {
			ignore_innacuracy = ignore_innacuracy ?? false;

			ByTable docked_shuttles = null;
			ByTable moved_shuttles = null;
			Obj_Structure_DockingPort_Destination dock = null;
			dynamic S = null;
			double? rotate = null;
			dynamic target_turf = null;
			ByTable turf_list = null;
			dynamic T = null;
			Shuttle S2 = null;
			Obj_Structure_DockingPort our_moved_dock = null;

			
			if ( !Lang13.Bool( D ) ) {
				return false;
			}

			if ( !( this.linked_port != null ) ) {
				return false;
			}
			docked_shuttles = new ByTable();
			moved_shuttles = new ByTable();
			moved_shuttles.Add( this );

			foreach (dynamic _a in Lang13.Enumerate( this.linked_area, typeof(Obj_Structure_DockingPort_Destination) )) {
				dock = _a;
				

				if ( Lang13.Bool( dock.docked_with ) && !( dock.docked_with == this.linked_port ) ) {
					S = dock.docked_with;

					if ( !Lang13.Bool( S ) || !Lang13.Bool( S.linked_shuttle ) ) {
						continue;
					}
					docked_shuttles.Or( S.linked_shuttle );
					docked_shuttles[S.linked_shuttle] = dock;
				}
			}
			rotate = 0;

			if ( Lang13.Bool( this.can_rotate ) ) {
				
				if ( this.linked_port.dir != Num13.Rotate( D.dir, 180 ) ) {
					rotate = ( GlobalFuncs.dir2angle( Num13.Rotate( D.dir, 180 ) ) ??0) - ( GlobalFuncs.dir2angle( this.linked_port.dir ) ??0);

					if ( ( rotate ??0) < 0 ) {
						rotate += 360;
					} else if ( ( rotate ??0) >= 360 ) {
						rotate -= 360;
					}
				}
			}
			target_turf = ((Obj_Structure_DockingPort)D).get_docking_turf();

			if ( !( ignore_innacuracy == true ) && Lang13.Bool( this.innacuracy ) ) {
				turf_list = new ByTable();

				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( ((Obj_Structure_DockingPort)D).get_docking_turf(), this.innacuracy ) )) {
					T = _b;
					
					turf_list.Or( T );
				}
				target_turf = Rand13.PickFromTable( turf_list );
			}

			if ( this.move_area_to( GlobalFuncs.get_turf( this.linked_port ), target_turf, rotate ) ) {
				this.linked_port.dock( D );

				if ( docked_shuttles.len != 0 ) {
					
					foreach (dynamic _c in Lang13.Enumerate( docked_shuttles, typeof(Shuttle) )) {
						S2 = _c;
						

						if ( moved_shuttles.Contains( S2 ) ) {
							continue;
						}
						our_moved_dock = docked_shuttles[S2];

						if ( !( our_moved_dock != null ) ) {
							continue;
						}
						moved_shuttles.Or( S2 );
						S2.move_to_dock( our_moved_dock, true );
					}
				}
				GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + this.name + " (" + this.type + ") moved to " + D.areaname ) ) );
				this.current_port = D;
				this.after_flight();
				return true;
			}
			return false;
		}

		// Function from file: shuttle.dm
		public void pre_flight(  ) {
			
			if ( !Lang13.Bool( this.destination_port ) ) {
				return;
			}

			if ( Lang13.Bool( this.transit_port ) && Lang13.Bool( this.get_transit_delay() ) ) {
				
				if ( this.use_transit == 2 || this.use_transit == 1 && this.linked_area.z != this.destination_port.z ) {
					this.move_to_dock( this.transit_port );
					Task13.Sleep( Convert.ToInt32( this.get_transit_delay() ) );
				}
			}

			if ( Lang13.Bool( this.destination_port ) ) {
				this.move_to_dock( this.destination_port );
				this.destination_port = null;
			}
			this.moving = false;
			return;
		}

		// Function from file: shuttle.dm
		public virtual bool travel_to( dynamic D = null, Obj_Machinery_Computer_ShuttleControl broadcast = null, Mob user = null ) {
			string time = null;
			dynamic A = null;

			
			if ( !Lang13.Bool( D ) ) {
				return false;
			}

			if ( !( this.linked_port != null ) ) {
				return false;
			}

			if ( Lang13.Bool( this.destination_port ) ) {
				
				if ( broadcast != null ) {
					broadcast.announce( "The shuttle is currently in process of moving." );
				} else if ( user != null ) {
					GlobalFuncs.to_chat( user, "The shuttle is currently moving" );
				}
				return false;
			}

			if ( Lang13.Bool( this.lockdown ) ) {
				
				if ( broadcast != null ) {
					broadcast.announce( "This shuttle is locked down." );
				} else if ( user != null ) {
					GlobalFuncs.to_chat( user, "The shuttle can't move (locked down)" );
				}
				return false;
			}

			if ( !this.can_move() ) {
				
				if ( broadcast != null ) {
					broadcast.announce( "The engines are still cooling down from the previous trip." );
				} else if ( user != null ) {
					GlobalFuncs.to_chat( user, "The shuttle can't move (on cooldown)" );
				}
				return false;
			}

			if ( Lang13.Bool( D.docked_with ) ) {
				
				if ( broadcast != null ) {
					broadcast.announce( "" + GlobalFuncs.capitalize( D.areaname ) + " is currently used by another shuttle. Please wait until the docking port is free, or select another destination." );
				} else if ( user != null ) {
					GlobalFuncs.to_chat( user, "The shuttle can't move (" + D.areaname + " is used by another shuttle)" );
				}
				return false;
			}
			time = "as soon as possible";

			dynamic _a = this.pre_flight_delay; // Was a switch-case, sorry for the mess.
			if ( 1<=_a&&_a<=30 ) {
				time = "in a few seconds";
			} else if ( 31<=_a&&_a<=50 ) {
				time = "shortly";
			} else if ( 51<=_a&&_a<=80 ) {
				time = "after a short delay";
			} else if ( 81<=_a&&_a<=Double.PositiveInfinity ) {
				time = "in " + Num13.MaxInt( ((int)( Num13.Round( Convert.ToDouble( this.pre_flight_delay / 10 ), 1 ) )), 0 ) + " seconds";
			} else if ( _a==0 ) {
				time = "immediately";
			}

			if ( broadcast != null ) {
				broadcast.announce( "The shuttle has received your message and will be sent " + time + "." );
			}

			if ( this.linked_port.z != Convert.ToInt32( D.z ) ) {
				A = this.forbid_movement();

				if ( Lang13.Bool( A ) ) {
					
					if ( Lang13.Bool( this.cant_leave_zlevel[A.type] ) ) {
						
						if ( broadcast != null ) {
							broadcast.announce( "ERROR: " + this.cant_leave_zlevel[A.type] );
						} else if ( user != null ) {
							GlobalFuncs.to_chat( user, this.cant_leave_zlevel[A.type] );
						}
						return false;
					} else {
						
						if ( broadcast != null ) {
							broadcast.announce( "ERROR: " + A.name + " is preventing the shuttle from departing." );
						} else if ( user != null ) {
							GlobalFuncs.to_chat( user, "" + A.name + " is preventing the shuttle from departing." );
						}
						return false;
					}
				}
			}
			this.destination_port = D;
			this.last_moved = Game13.time;
			this.moving = true;
			GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + ( Task13.User != null ? GlobalFuncs.key_name( Task13.User ) : "Something" ) + " sent " + this.name + " (" + this.type + ") to " + D.areaname ) ) );
			Task13.Schedule( Convert.ToInt32( this.get_pre_flight_delay() ), (Task13.Closure)(() => {
				
				if ( Lang13.Bool( this.transit_port ) && Lang13.Bool( this.get_transit_delay() ) ) {
					
					if ( broadcast != null ) {
						broadcast.announce( "The shuttle has departed and is now moving towards " + D.areaname + "." );
					} else if ( user != null ) {
						GlobalFuncs.to_chat( user, "The shuttle has departed towards " + D.areaname );
					}
				} else if ( broadcast != null ) {
					broadcast.announce( "The shuttle has arrived at " + D.areaname + "." );
				} else if ( user != null ) {
					GlobalFuncs.to_chat( user, "The shuttle has arrived at " + D.areaname );
				}
				this.pre_flight();
				return;
			}));
			return true;
		}

		// Function from file: shuttle.dm
		public dynamic forbid_movement(  ) {
			dynamic A = null;

			A = ((Ent_Static)this.linked_area).contains_atom_from_list( this.cant_leave_zlevel );

			if ( Lang13.Bool( A ) ) {
				return A;
			}
			return 0;
		}

		// Function from file: shuttle.dm
		public bool can_move(  ) {
			
			if ( Lang13.Bool( this.lockdown ) ) {
				return false;
			}

			if ( this.last_moved + Convert.ToDouble( this.cooldown ) < Game13.time ) {
				return true;
			}
			return false;
		}

		// Function from file: shuttle.dm
		public dynamic set_transit_dock( dynamic D = null ) {
			Obj_Structure_DockingPort_Destination dock = null;

			
			if ( D is Type ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.all_docking_ports, typeof(Obj_Structure_DockingPort_Destination) )) {
					dock = _a;
					

					if ( Lang13.Bool( D.IsInstanceOfType( dock ) ) ) {
						this.transit_port = dock;
						return dock;
					}
				}
			} else if ( D is Obj_Structure_DockingPort_Destination ) {
				this.transit_port = D;
			}
			return D;
		}

		// Function from file: shuttle.dm
		public dynamic add_dock( Type D = null ) {
			Obj_Structure_DockingPort_Destination dock = null;
			dynamic dock2 = null;

			
			if ( D is Type ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.all_docking_ports, typeof(Obj_Structure_DockingPort_Destination) )) {
					dock = _a;
					

					if ( Lang13.Bool( ((dynamic)D).IsInstanceOfType( dock ) ) ) {
						dock.link_to_shuttle( this );
						return dock;
					}
				}
			} else if ( D is Obj_Structure_DockingPort_Destination ) {
				dock2 = D;
				((Obj_Structure_DockingPort)dock2).link_to_shuttle( this );
				return dock2;
			}
			return D;
		}

		// Function from file: shuttle.dm
		public virtual bool is_special(  ) {
			return false;
		}

		// Function from file: shuttle.dm
		public dynamic get_cooldown(  ) {
			return this.cooldown;
		}

		// Function from file: shuttle.dm
		public dynamic get_pre_flight_delay(  ) {
			return this.pre_flight_delay;
		}

		// Function from file: shuttle.dm
		public dynamic get_transit_delay(  ) {
			return this.transit_delay;
		}

		// Function from file: shuttle.dm
		public virtual int initialize(  ) {
			int _default = 0;

			Obj_Structure_DockingPort_Shuttle shuttle_docking_port = null;
			Obj_Structure_DockingPort_Shuttle S = null;
			Tile check_turf = null;
			Obj_Structure_DockingPort P = null;
			Obj_Structure_DockingPort D = null;

			_default = 1;
			this.docking_ports = new ByTable();
			this.docking_ports_aboard = new ByTable();
			this.transit_port = null;

			if ( !Lang13.Bool( this.linked_area ) || !( this.linked_area is Zone ) ) {
				return 2;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.linked_area, typeof(Obj_Structure_DockingPort_Shuttle) )) {
				S = _a;
				
				shuttle_docking_port = S;
				break;
			}

			if ( shuttle_docking_port != null ) {
				
				if ( this.linked_port != null ) {
					this.linked_port.unlink_from_shuttle( this );
				}
				shuttle_docking_port.link_to_shuttle( this );
				check_turf = shuttle_docking_port.get_docking_turf();

				if ( check_turf != null ) {
					
					foreach (dynamic _b in Lang13.Enumerate( check_turf.contents, typeof(Obj_Structure_DockingPort) )) {
						P = _b;
						
						shuttle_docking_port.dock( P );
						this.current_port = shuttle_docking_port.docked_with;
						break;
					}
				}

				if ( !Lang13.Bool( this.current_port ) ) {
					_default = 4;
				}
				this.dir = Num13.Rotate( this.linked_port.dir, 180 );
			} else {
				_default = 3;
			}

			foreach (dynamic _c in Lang13.Enumerate( this.linked_area, typeof(Obj_Structure_DockingPort) )) {
				D = _c;
				
				this.docking_ports_aboard.Or( D );
			}
			return _default;
		}

	}

}