// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_TransitTube : Obj_Structure {

		public ByTable tube_dirs = null;
		public int exit_delay = 2;
		public int enter_delay = 1;
		public dynamic tube_dir_list = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/pipes/transit_tube.dmi";
			this.icon_state = "E-W";
			this.layer = 3.1;
		}

		// Function from file: transit_tubes.dm
		public Obj_Structure_TransitTube ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.tube_dirs == null ) {
				this.init_dirs();
			}
			return;
		}

		// Function from file: transit_tubes.dm
		public string dir2text_short( dynamic direction = null ) {
			
			dynamic _a = direction; // Was a switch-case, sorry for the mess.
			if ( _a==1 ) {
				return "N";
			} else if ( _a==2 ) {
				return "S";
			} else if ( _a==4 ) {
				return "E";
			} else if ( _a==8 ) {
				return "W";
			} else if ( _a==5 ) {
				return "NE";
			} else if ( _a==6 ) {
				return "SE";
			} else if ( _a==9 ) {
				return "NW";
			} else if ( _a==10 ) {
				return "SW";
			}
			return null;
		}

		// Function from file: transit_tubes.dm
		public int text2dir_extended( dynamic direction = null ) {
			
			switch ((string)( String13.ToUpper( direction ) )) {
				case "NORTH":
				case "N":
					return 1;
					break;
				case "SOUTH":
				case "S":
					return 2;
					break;
				case "EAST":
				case "E":
					return 4;
					break;
				case "WEST":
				case "W":
					return 8;
					break;
				case "NORTHEAST":
				case "NE":
					return 5;
					break;
				case "NORTHWEST":
				case "NW":
					return 9;
					break;
				case "SOUTHEAST":
				case "SE":
					return 6;
					break;
				case "SOUTHWEST":
				case "SW":
					return 10;
					break;
			}
			return 0;
		}

		// Function from file: transit_tubes.dm
		public ByTable parse_dirs( string text = null ) {
			ByTable split_text = null;
			ByTable directions = null;
			dynamic text_part = null;
			int direction = 0;

			
			if ( GlobalVars.direction_table.Contains( text ) ) {
				return GlobalVars.direction_table[text];
			}
			split_text = GlobalFuncs.text2list( text, "-" );

			if ( split_text[1] == "D" ) {
				GlobalVars.direction_table[text] = new ByTable();
				return null;
			}
			directions = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( split_text )) {
				text_part = _a;
				
				direction = this.text2dir_extended( text_part );

				if ( direction > 0 ) {
					directions.Add( direction );
				}
			}
			GlobalVars.direction_table[text] = directions;
			return directions;
		}

		// Function from file: transit_tubes.dm
		public void create_automatic_decorative_corner( Tile location = null, dynamic direction = null ) {
			string state = null;
			Obj_Structure_TransitTube tube = null;
			Obj_Structure_TransitTube tube2 = null;

			state = "D-" + this.dir2text_short( direction );

			foreach (dynamic _a in Lang13.Enumerate( location, typeof(Obj_Structure_TransitTube) )) {
				tube = _a;
				

				if ( tube.icon_state == state ) {
					return;
				}
			}
			tube2 = new Obj_Structure_TransitTube( location );
			tube2.icon_state = state;
			tube2.init_dirs();
			return;
		}

		// Function from file: transit_tubes.dm
		public void generate_automatic_corners( ByTable directions = null ) {
			dynamic direction = null;

			
			foreach (dynamic _a in Lang13.Enumerate( directions )) {
				direction = _a;
				

				if ( direction == 5 || direction == 6 || direction == 9 || direction == 10 ) {
					
					if ( Lang13.Bool( direction & 1 ) ) {
						this.create_automatic_decorative_corner( Map13.GetStep( this.loc, ((int)( GlobalVars.NORTH )) ), direction ^ 3 );
					} else {
						this.create_automatic_decorative_corner( Map13.GetStep( this.loc, ((int)( GlobalVars.SOUTH )) ), direction ^ 3 );
					}

					if ( Lang13.Bool( direction & 4 ) ) {
						this.create_automatic_decorative_corner( Map13.GetStep( this.loc, ((int)( GlobalVars.EAST )) ), direction ^ 12 );
					} else {
						this.create_automatic_decorative_corner( Map13.GetStep( this.loc, ((int)( GlobalVars.WEST )) ), direction ^ 12 );
					}
				}
			}
			return;
		}

		// Function from file: transit_tubes.dm
		public void select_automatic_icon_state( ByTable directions = null ) {
			
			if ( Lang13.Length( directions ) == 2 ) {
				this.icon_state = "" + this.dir2text_short( directions[1] ) + "-" + this.dir2text_short( directions[2] );
			}
			return;
		}

		// Function from file: transit_tubes.dm
		public ByTable select_automatic_dirs( ByTable connected = null ) {
			int? i = null;
			int? j = null;
			int d1 = 0;
			dynamic d2 = null;

			
			if ( Lang13.Length( connected ) < 1 ) {
				return new ByTable();
			}
			i = null;
			i = 1;

			while (( i ??0) <= Lang13.Length( connected )) {
				j = null;
				j = ( i ??0) + 1;

				while (( j ??0) <= Lang13.Length( connected )) {
					d1 = Convert.ToInt32( connected[i] );
					d2 = connected[j];

					if ( d1 == Num13.Rotate( d2, 135 ) || d1 == Num13.Rotate( d2, 180 ) || d1 == Num13.Rotate( d2, 225 ) ) {
						return new ByTable(new object [] { d1, d2 });
					}
					j++;
				}
				i++;
			}
			return new ByTable(new object [] { connected[1], Num13.Rotate( connected[1], 180 ) });
		}

		// Function from file: transit_tubes.dm
		public void init_dirs_automatic(  ) {
			ByTable connected = null;
			ByTable connected_auto = null;
			dynamic direction = null;
			Tile location = null;
			Obj_Structure_TransitTube tube = null;

			connected = new ByTable();
			connected_auto = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.tube_dir_list )) {
				direction = _b;
				
				location = Map13.GetStep( this.loc, Convert.ToInt32( direction ) );

				foreach (dynamic _a in Lang13.Enumerate( location, typeof(Obj_Structure_TransitTube) )) {
					tube = _a;
					

					if ( tube.directions() == null && tube.icon_state == "auto" ) {
						connected_auto.Add( direction );
						break;
					} else if ( tube.directions().Contains( Num13.Rotate( direction, 180 ) ) ) {
						connected.Add( direction );
						break;
					}
				}
			}
			connected.Add( connected_auto );
			this.tube_dirs = this.select_automatic_dirs( connected );

			if ( Lang13.Length( this.tube_dirs ) == 2 && GlobalVars.tube_dir_list.Find( this.tube_dirs[1] ) > GlobalVars.tube_dir_list.Find( this.tube_dirs[2] ) ) {
				this.tube_dirs.Swap( 1, 2 );
			}
			this.generate_automatic_corners( this.tube_dirs );
			this.select_automatic_icon_state( this.tube_dirs );
			return;
		}

		// Function from file: transit_tubes.dm
		public virtual void init_dirs(  ) {
			
			if ( this.icon_state == "auto" ) {
				Task13.Schedule( 1, (Task13.Closure)(() => {
					this.init_dirs_automatic();
					return;
				}));
			} else {
				this.tube_dirs = this.parse_dirs( this.icon_state );

				if ( String13.SubStr( this.icon_state, 1, 3 ) == "D-" || String13.Find( this.icon_state, "Pass", 1, 0 ) != 0 ) {
					this.density = false;
				}
			}
			return;
		}

		// Function from file: transit_tubes.dm
		[VerbInfo( name: "enter delay" )]
		public int f_enter_delay( Obj_Structure_TransitTubePod pod = null, dynamic to_dir = null ) {
			return this.enter_delay;
		}

		// Function from file: transit_tubes.dm
		[VerbInfo( name: "exit delay" )]
		public int f_exit_delay( Obj_Structure_TransitTubePod pod = null, int to_dir = 0 ) {
			return this.exit_delay;
		}

		// Function from file: transit_tubes.dm
		public dynamic get_exit( int in_dir = 0 ) {
			dynamic near_dir = null;
			int in_dir_cw = 0;
			int in_dir_ccw = 0;
			dynamic direction = null;

			near_dir = 0;
			in_dir_cw = Num13.Rotate( in_dir, -45 );
			in_dir_ccw = Num13.Rotate( in_dir, 45 );

			foreach (dynamic _a in Lang13.Enumerate( this.directions() )) {
				direction = _a;
				

				if ( direction == in_dir ) {
					return direction;
				} else if ( direction == in_dir_cw ) {
					near_dir = direction;
				} else if ( direction == in_dir_ccw ) {
					near_dir = direction;
				}
			}
			return near_dir;
		}

		// Function from file: transit_tubes.dm
		public bool has_exit( double? in_dir = null ) {
			dynamic direction = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.directions() )) {
				direction = _a;
				

				if ( direction == in_dir ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: transit_tubes.dm
		public bool has_entrance( dynamic from_dir = null ) {
			dynamic direction = null;

			from_dir = Num13.Rotate( from_dir, 180 );

			foreach (dynamic _a in Lang13.Enumerate( this.directions() )) {
				direction = _a;
				

				if ( direction == from_dir ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: transit_tubes.dm
		public ByTable directions(  ) {
			return this.tube_dirs;
		}

		// Function from file: transit_tubes.dm
		public virtual void pod_stopped( Obj_Structure_TransitTubePod pod = null, int from_dir = 0 ) {
			return;
		}

		// Function from file: transit_tubes.dm
		public virtual bool should_stop_pod( Obj_Structure_TransitTubePod pod = null, dynamic from_dir = null ) {
			return false;
		}

		// Function from file: transit_tubes.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			dynamic tube = null;
			dynamic T = null;
			ByTable large_dense = null;
			Ent_Dynamic border_obstacle = null;
			Ent_Dynamic obstacle = null;

			tube = Lang13.FindIn( typeof(Obj_Structure_TransitTube), AM.loc );

			if ( Lang13.Bool( tube ) ) {
				GlobalFuncs.to_chat( AM, "<span class='warning'>The tube's support pylons block your way.</span>" );
				return base.Bumped( AM, (object)(yes) );
			} else {
				T = GlobalFuncs.get_turf( this );
				large_dense = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( T, typeof(Ent_Dynamic) )) {
					border_obstacle = _a;
					

					if ( Lang13.Bool( border_obstacle.flags & 512 ) ) {
						
						if ( !border_obstacle.CanPass( AM, AM.loc ) && AM != border_obstacle ) {
							return base.Bumped( AM, (object)(yes) );
						}
					} else if ( border_obstacle != this ) {
						large_dense.Add( border_obstacle );
					}
				}

				if ( !((Ent_Static)T).CanPass( AM, T ) ) {
					return base.Bumped( AM, (object)(yes) );
				}

				foreach (dynamic _b in Lang13.Enumerate( large_dense, typeof(Ent_Dynamic) )) {
					obstacle = _b;
					

					if ( !obstacle.CanPass( AM, AM.loc ) && AM != obstacle ) {
						return base.Bumped( AM, (object)(yes) );
					}
				}
				AM.loc = this.loc;
				GlobalFuncs.to_chat( AM, "<span class='info'>You slip under the tube.</span>" );
			}
			return false;
		}

	}

}